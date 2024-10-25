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
            var category = await _categoryServices.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"No se encontro la categoria con el id {id}");
            }
            return Ok(category);
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
            var currentCategory = await _categoryServices.GetCategoryById(id);

            if (currentCategory == null)
            {
                return NotFound($"No se encontro la categoria con el id {id}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            currentCategory.Name = categoryPutDto.Name;
            currentCategory.Description = categoryPutDto.Description;

            await _categoryServices.UpdateCategory(currentCategory, id);
            return Ok();
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error al actualizar las categoria");
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

            var category = await _categoryServices.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"No se encontro la categoria con el id {id}");
            }

            if (!string.IsNullOrWhiteSpace(categoryPatchDto.Name))
            {
                category.Name = categoryPatchDto.Name;
            }

            if (!string.IsNullOrWhiteSpace(categoryPatchDto.Description))
            {
                category.Description = categoryPatchDto.Description;
            }

            await _categoryServices.UpdateCategory(category, id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error al actualizar las categoria");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var category = await _categoryServices.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"No se encontro la categoria con el id {id}");
            }
            await _categoryServices.DeleteCategory(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Error al eliminar la categoria");
        }
    }
}
