using System.ComponentModel.DataAnnotations;

namespace BLL
{
	public class Hero
	{
		[Key]
		public int HeroId { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Power is required")]
		public int Power { get; set; }

		[Required(ErrorMessage = "Image URL is required")]
		public string ImageUrl { get; set; }

		public string? ImageBase64 { get; set; } // Add this property to store Base64 string
	}
}
