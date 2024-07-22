using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace LearnAngularAPIappHero.Code
{
	public class UploadFileService : IUploadFileService
	{
		public string UploadFile(IFormFile file)
		{
			var folderName = Path.Combine("Resources", "Images");
			var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

			// Check if directory exists, create if not
			if (!Directory.Exists(pathToSave))
			{
				Directory.CreateDirectory(pathToSave);
			}

			// Generate a unique file name to prevent overwriting existing files
			var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			var fullPath = Path.Combine(pathToSave, fileName);

			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			// Return relative path to be stored in the database
			var dbPath = Path.Combine(folderName, fileName);
			return dbPath;
		}
	}
}
