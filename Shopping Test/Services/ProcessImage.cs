
using Microsoft.EntityFrameworkCore;
using Shopping_Test.ViewModels;
using System.Configuration;
using System.Drawing.Text;
using System.IO;

namespace Shopping_Test.Services
{
    public class ProcessImage : IProcessImage
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;

        public ProcessImage(IUnitOfWork unitOfWork,
                            IWebHostEnvironment webHostEnvironment)
        {
             _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.imagePath}";
        }
        public string Rootpath(string typeOfImage)=> Path.Combine(_imagePath, typeOfImage);
        public string nameOfFile(IFormFile file) => $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        public bool checkSizeImage(IFormFileCollection file)
        {
            throw new NotImplementedException();
        }
        public bool allowExtention(IFormFileCollection file)
        {
           var ExtentionPath = Path.GetExtension(file[0].FileName.ToLower());
           return FileSettings.allowExtentenstions.Split(',').Contains(ExtentionPath) ?
                true: false;
        }
        public async Task stream(string typeOfImage,IFormFile file , string nameOfFile) { 
           
           var file_Stream = new FileStream(Path.Combine(Rootpath(typeOfImage),nameOfFile),
                FileMode.Create);
            await file.CopyToAsync(file_Stream);
            file_Stream.Close();
        }

    }
}
