using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Manga_ecommerce.DTOs.Products
{
    public class ProductPatchDto
    {
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Url { get; set; }
        public int? CategoryId { get; set; }
    }
}
