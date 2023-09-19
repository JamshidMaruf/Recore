using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Recore.Service.DTOs.Payments;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Payments;

namespace Recore.Service.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Payment> repository;
    private readonly IMapper mapper;
    public PaymentService(IRepository<Payment> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async ValueTask<PaymentResultDto> AddAsync(PaymentCreationDto dto)
    {
        var mappedPayment = mapper.Map<Payment>(dto);
        await this.repository.CreateAsync(mappedPayment);
        await this.repository.SaveAsync();

        return this.mapper.Map<PaymentResultDto>(mappedPayment);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existPayment = await this.repository.SelectAsync(p => p.Id == id)
            ?? throw new NotFoundException($"This payment is not found with ID = {id}");

        this.repository.Delete(existPayment);
        await repository.SaveAsync();

        return true;
    }

    public async ValueTask<PaymentResultDto> ModifyAsync(PaymentUpdateDto dto)
    {
        var existPayment = await this.repository.SelectAsync(p => p.Id == dto.Id)
            ?? throw new NotFoundException($"This payment is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existPayment);
        this.repository.Update(existPayment);

        await this.repository.SaveAsync();

        return this.mapper.Map<PaymentResultDto>(existPayment);
    }

    public async ValueTask<PaymentResultDto> RetrieveByIdAsync(long id)
    {
        var existPayment = await this.repository.SelectAsync(p => p.Id == id)
              ?? throw new NotFoundException($"This payment is not found with ID = {id}");

        return this.mapper.Map<PaymentResultDto>(existPayment);
    }

    public async ValueTask<IEnumerable<PaymentResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var payments = await this.repository.SelectAll()
            .ToPaginate(@params)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<PaymentResultDto>>(payments);
    }
}