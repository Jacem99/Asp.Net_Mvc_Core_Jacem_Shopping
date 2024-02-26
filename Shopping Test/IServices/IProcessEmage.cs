namespace Shopping_Test.IServices
{
    public interface IProcessImage
    {
        string Rootpath(string typeOfImage);
        string nameOfFile(IFormFile file);
        bool allowExtention(IFormFileCollection file);
        bool checkSizeImage(IFormFileCollection file);
        Task stream(string typeOfImage, IFormFile file , string nameOfFile);
    }
    
}
