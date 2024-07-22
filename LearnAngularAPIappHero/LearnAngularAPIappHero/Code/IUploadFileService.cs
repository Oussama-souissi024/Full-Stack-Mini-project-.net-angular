using Microsoft.AspNetCore.Http;

namespace LearnAngularAPIappHero.Code
{
	public interface IUploadFileService
	{
		string UploadFile(IFormFile file);
	}
}
