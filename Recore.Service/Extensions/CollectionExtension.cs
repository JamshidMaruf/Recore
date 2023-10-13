using Newtonsoft.Json;
using Recore.Domain.Commons;
using Recore.Service.Helpers;
using Recore.Service.Exceptions;
using Recore.Domain.Configurations;
using Recore.Domain.Configurations.Pagination;
using System.Linq.Expressions;

namespace Recore.Service.Extensions;

public static class CollectionExtension
{
	public static IQueryable<T> ToPaginate<T>(this IQueryable<T> values, PaginationParams @params)
	{
		var source = values.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
		return source;
	}

    public static IEnumerable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> entities, PaginationParams @params)
        where TEntity : Auditable
    {
        if (@params.PageSize == 0 && @params.PageIndex == 0)
        {
            @params = new PaginationParams()
            {
                PageSize = 10,
                PageIndex = 1
            };
        }
        var metaData = new PaginationMetaData(entities.Count(), @params);

        var json = JsonConvert.SerializeObject(metaData);

        if (HttpContextHelper.ResponseHeaders != null)
        {
            if (HttpContextHelper.ResponseHeaders.ContainsKey("X-Pagination"))
                HttpContextHelper.ResponseHeaders.Remove("X-Pagination");

            HttpContextHelper.ResponseHeaders.Add("X-Pagination", json);
        }

        return @params.PageIndex > 0 && @params.PageSize > 0 ?
            entities.OrderBy(e => e.Id)
                .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize) :
                    throw new CustomException(400, "Please, enter valid numbers");
    }

    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, Filter filter)
    {
        var expression = source.Expression;

        var parameter = Expression.Parameter(typeof(T), "x");
        MemberExpression selector;
        try
        {
            selector = Expression.PropertyOrField(parameter, filter?.OrderBy ?? "Id");
        }
        catch
        {
            throw new CustomException(400, "Specified property is not found");
        }
        var method = string.Equals(filter?.OrderType ?? "asc", "desc", StringComparison.OrdinalIgnoreCase) ? "OrderByDescending" : "OrderBy";

        expression = Expression.Call(typeof(Queryable), method,
            new Type[] { source.ElementType, selector.Type },
            expression, Expression.Quote(Expression.Lambda(selector, parameter)));

        return source.Provider.CreateQuery<T>(expression);
    }
}
