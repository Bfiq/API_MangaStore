using API_Manga_ecommerce.DTOs.OrdersDetails;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.OrdersDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[controller]")]
public class OrderDeatailsController: ControllerBase
{
    private IOrdersDetailsService _ordersDetailsService;

    public OrderDeatailsController(IOrdersDetailsService ordersDetailsService)
    {
        _ordersDetailsService = ordersDetailsService;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _ordersDetailsService.GetAllOrderDetails());
        }
        catch
        {
            return StatusCode(500, "Error");
        }
    }

    //Buscar ordenes por usuario

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            await _ordersDetailsService.CheckIfOrderDetailsExist(id);
            return Ok(await _ordersDetailsService.GetAllOrderDetails());
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] OrderDetails orderDetails)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ordersDetailsService.SaveOrderDetails(orderDetails);
            return Created();
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Put([FromBody] OrderDetails orderDetails, int id)
    {
        try
        {
            await _ordersDetailsService.CheckIfOrderDetailsExist(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ordersDetailsService.UpdateOrderDetails(orderDetails, id);
            return Ok("Detalles Actualizados");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> Patch([FromBody] OrderDetailsPatchDto orderDetailsPatchDto, int id)
    {
        try
        {
            await _ordersDetailsService.CheckIfOrderDetailsExist(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ordersDetailsService.PartialUpdateOrderDetails(orderDetailsPatchDto, id);
            return Ok("Detalles Actualizados");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _ordersDetailsService.CheckIfOrderDetailsExist(id);
            await _ordersDetailsService.DeleteOrderDetails(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }
}
