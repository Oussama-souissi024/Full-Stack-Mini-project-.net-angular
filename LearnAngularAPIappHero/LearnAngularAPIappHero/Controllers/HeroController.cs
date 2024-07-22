using BLL;
using DAL;
using DAL.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System;
using LearnAngularAPIappHero.Code;

namespace LearnAngularAPIappHero.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HeroController : ControllerBase
	{
		private readonly IDataHelper<Hero> dataHelper;
		private readonly IUploadFileService uploadFileService;
		private readonly IWebHostEnvironment _env;
		private readonly ILogger<HeroController> _logger;

		public HeroController(IDataHelper<Hero> dataHelper, IUploadFileService uploadFileService, IWebHostEnvironment env, ILogger<HeroController> logger)
		{
			this.dataHelper = dataHelper;
			this.uploadFileService = uploadFileService;
			_env = env;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetListHeros()
		{
			try
			{
				var heroes = dataHelper.GetAllData().ToList();

				foreach (var hero in heroes)
				{
					if (!string.IsNullOrEmpty(hero.ImageUrl))
					{
						var imagePath = Path.Combine(Directory.GetCurrentDirectory(), hero.ImageUrl);
						if (System.IO.File.Exists(imagePath))
						{
							byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
							hero.ImageBase64 = Convert.ToBase64String(imageBytes);
						}
					}
				}

				return Ok(heroes);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while retrieving heroes");
				return StatusCode(500, new { message = "Internal server error" });
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetHero(int id)
		{
			try
			{
				var hero = dataHelper.Find(id);
				if (hero == null)
				{
					return NotFound(new { message = "Hero not found." });
				}

				if (!string.IsNullOrEmpty(hero.ImageUrl))
				{
					var imagePath = Path.Combine(Directory.GetCurrentDirectory(), hero.ImageUrl);
					if (System.IO.File.Exists(imagePath))
					{
						byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
						hero.ImageBase64 = Convert.ToBase64String(imageBytes);
					}
				}

				return Ok(hero);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while retrieving the hero");
				return StatusCode(500, new { message = "Internal server error" });
			}
		}

		[HttpPost, DisableRequestSizeLimit]
		public IActionResult AddHero([FromForm] HeroPostModel model)
		{
			try
			{
				var file = model.ImageFile;

				// Call UploadFileService to handle file upload
				var dbPath = uploadFileService.UploadFile(file);

				var newHero = new Hero
				{
					Name = model.Name,
					Power = model.Power,
					ImageUrl = dbPath
				};

				if (dataHelper.Add(newHero) == 1)
				{
					return StatusCode(200, new { message = "Hero Added Successfully" });
				}
				else
				{
					return StatusCode(500, new { message = "An error occurred while adding the Hero." });
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while adding the hero");
				return StatusCode(500, $"Internal server error: {ex}");
			}
		}

		[HttpPut("{id}")]
		public IActionResult EditHero(int id, [FromForm] HeroPostModel model)
		{
			try
			{
				var hero = dataHelper.Find(id);
				if (hero == null)
				{
					return NotFound(new { message = "Hero not found." });
				}

				var file = model.ImageFile;
				if (file != null)
				{
					// Delete the old image file
					var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), hero.ImageUrl);
					if (System.IO.File.Exists(oldImagePath))
					{
						System.IO.File.Delete(oldImagePath);
					}

					// Upload the new image file
					var dbPath = uploadFileService.UploadFile(file);
					hero.ImageUrl = dbPath;
				}

				hero.Name = model.Name;
				hero.Power = model.Power;

				if (dataHelper.Edit(id, hero) == 1)
				{
					return Ok(new { message = "Hero updated successfully." });
				}
				else
				{
					return StatusCode(500, new { message = "An error occurred while updating the hero." });
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while updating the hero");
				return StatusCode(500, $"Internal server error: {ex}");
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteHero(int id)
		{
			try
			{
				var hero = dataHelper.Find(id);
				if (hero == null)
				{
					return NotFound(new { message = "Hero not found." });
				}

				// Delete the image file
				var imagePath = Path.Combine(Directory.GetCurrentDirectory(), hero.ImageUrl);
				if (System.IO.File.Exists(imagePath))
				{
					System.IO.File.Delete(imagePath);
				}

				if (dataHelper.Delete(id) == 1)
				{
					return Ok(new { message = "Hero deleted successfully." });
				}
				else
				{
					return StatusCode(500, new { message = "An error occurred while deleting the hero." });
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while deleting the hero");
				return StatusCode(500, $"Internal server error: {ex}");
			}
		}
	}

	public class HeroPostModel
	{
		public string Name { get; set; }
		public int Power { get; set; }
		public IFormFile ImageFile { get; set; }
	}
}
