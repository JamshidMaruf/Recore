using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;

namespace Recore.WebApi.Controllers;

public class CartItemsController : BaseController
{
    [HttpGet]
    public ActionResult<string> GetUserIdFromToke()
    {
        return User.Claims.First(t => t.Type == "Id").Value;
    } 
}