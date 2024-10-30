using API_Manga_ecommerce.DTOs.Products;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[controller]")]
public class ProductController: ControllerBase
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _productService.GetAllProducts());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            await _productService.CheckIfCategoryExists(id);
            return Ok(await _productService.GetProductById(id));
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _productService.SaveProduct(product);
            return Created();
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Put([FromBody] ProductPutDto productPutDto, int id)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _productService.CheckIfCategoryExists(id);
            await _productService.UpdateProduct(productPutDto, id);
            return Ok("Producto Actualizado");
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

    [HttpPatch("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Patch([FromBody] ProductPatchDto productPatchDto, int id)
    {
        try
        {
            await _productService.CheckIfCategoryExists(id);
            await _productService.PartialUpdateProduct(productPatchDto, id);
            return Ok("Producto Actualizado");
        }
        catch(KeyNotFoundException ex)
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
            await _productService.CheckIfCategoryExists(id);
            await _productService.DeleteProduct(id);
            return NoContent();
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
