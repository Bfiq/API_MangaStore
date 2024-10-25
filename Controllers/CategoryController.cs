using API_Manga_ecommerce.DTOs;
using API_Manga_ecommerce.DTOs.Categories;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.Categories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[controller]")]
public class CategoryController: ControllerBase
{
    private ICategoryServices _categoryServices;

    public CategoryController(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _categoryServices.GetAllCategories());
        }
        catch (Exception ex)
        {
            //agregar log
            return StatusCode(500, "Error al obtener las categorias");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            await _categoryServices.CheckIfCategoryExists(id);
            var category = await _categoryServices.GetCategoryById(id);
            return Ok(category);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            //agregar log
            return StatusCode(500, "Error al obtener las categorias");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Category category)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryServices.SaveCategory(category);
            return Created();
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error al crear la categoria");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromBody] CategoryPutDto categoryPutDto, int id)
    {
        try
        {
            //Validar objeto de entrada
            await _categoryServices.CheckIfCategoryExists(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryServices.UpdateCategory(categoryPutDto, id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error al actualizar la categoria");
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch([FromBody] CategoryPatchDto categoryPatchDto, int id)
    {
        try
        {
            if (categoryPatchDto == null)
            {
                return BadRequest("El objeto de entrada no puede ser nulo.");
            }

            await _categoryServices.CheckIfCategoryExists(id);

            await _categoryServices.PartialUpdateCategory(categoryPatchDto, id);
            return Ok();
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error al actualizar la categoria");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryServices.CheckIfCategoryExists(id);
            await _categoryServices.DeleteCategory(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error al eliminar la categoria");
        }
    }
}
