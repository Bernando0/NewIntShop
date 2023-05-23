﻿namespace InternetShop.Web.Services
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public readonly string imgPath;

        public ImageService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
            imgPath = _configuration["ImagePath"];
        }

        public string ImageLoad(IFormFileCollection files)
        {
            if (!files.Any())
            {
                return string.Empty;
            }

            string fullPath = _environment.WebRootPath + _configuration["ImagePath"];
            string nameImage = Guid.NewGuid().ToString() + Path.GetExtension(files[0].FileName);

            using var fileStream = new FileStream(Path.Combine(fullPath, nameImage), FileMode.Create);

            files[0].CopyTo(fileStream);

            return nameImage;
        }

        public void DeleteImage(string imageName)
        {
            string fullPath = _environment.WebRootPath + _configuration["ImagePath"]+ imageName;

            if (File.Exists(fullPath)) {
            File.Delete(fullPath);
            }
            
        }
    }
}
