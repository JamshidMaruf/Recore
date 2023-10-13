using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Recore.Service.DTOs.WareHouses;

namespace Recore.WebApi.Controllers
{
	public class WarehouseController : BaseController
	{
		private readonly IWarehouseService wareHouseService;
		public WarehouseController(IWarehouseService wareHouseService)
		{
			this.wareHouseService = wareHouseService;
		}

		/// <summary>
		/// Create new WareHouse
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost]
		public async ValueTask<IActionResult> PostAsync([FromBody] WareHouseCreationDto dto)
			=> Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await this.wareHouseService.AddAsync(dto)
			});

		/// <summary>
		/// Delete by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("id")]
		public async ValueTask<IActionResult> DeleteAsync(long id)
			 => Ok(new Response
			 {
				 StatusCode = 200,
				 Message = "Success",
				 Data = await this.wareHouseService.RemoveAsync(id)
			 });

		/// <summary>
		/// Get by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("id")]
		public async ValueTask<IActionResult> GetByIdAsync(long id)
			 => Ok(new Response
			 {
				 StatusCode = 200,
				 Message = "Success",
				 Data = await this.wareHouseService.RetrieveByIdAsync(id)
			 });


		/// <summary>
		/// Get all WareHouses
		/// </summary>
		/// <param name="params"></param>
		/// <returns></returns>
		[HttpGet("get-list")]
		public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
			=> Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await this.wareHouseService.RetrieveAllAsync()

			});
	}
}

