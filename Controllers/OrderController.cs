using API_Manga_ecommerce.DTOs.Orders;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[controller]")]
public class OrderController:ControllerBase
{
    private IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _orderService.GetAllOrders());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            await _orderService.CheckIfOrderExists(id);
            return Ok(await _orderService.GetOrderById(id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            await _orderService.SaveOrder(order);
            return Created();
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch([FromBody] OrderPatchDto orderPatchDto, int id)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _orderService.CheckIfOrderExists(id);
            await _orderService.PartialUpdateOrder(orderPatchDto, id);
            return Ok("Orden Actualizada");
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }
}
