
namespace Company.G04.DAL.Helper
{
    public interface IFormFile
    {
        object FileName { get; }

        void CopyTo(FileStream fileStream);
    }
}