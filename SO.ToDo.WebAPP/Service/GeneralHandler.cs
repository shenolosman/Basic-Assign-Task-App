namespace SO.ToDo.WebAPP.Service
{
    public class GeneralHandler
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public GeneralHandler(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task<string?> SaveImageFile(IFormFile? imageFile, string? currentImageName = "")
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName).ToLower();
                var extension = Path.GetExtension(imageFile.FileName).ToLower();
                var imageName = DateTime.Now.ToString("yymmssfff") + fileName + extension;

                //save new file
                var filePath = Path.Combine(_hostEnvironment.WebRootPath + "/img/" + imageName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);

                //delete old file when changing img
                if (!string.IsNullOrEmpty(currentImageName) && currentImageName != "default.png")
                {
                    var oldFilePath = Path.Combine(_hostEnvironment.WebRootPath + "/img/" + currentImageName);
                    File.Delete(oldFilePath);
                }
                return imageName;
            }
            return currentImageName;
        }
        public void DeleteImageFile(string currentImageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "img", currentImageName);
            if (File.Exists(imagePath) && currentImageName != "default.png")
                File.Delete(imagePath);
        }
    }
}
