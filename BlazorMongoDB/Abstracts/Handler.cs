using FormulaDatabase.Data;
using FormulaDatabase.Service;

namespace FormulaDatabase.Abstracts
{
    public abstract class Handler<T>
    {
        public abstract void SaveInformation(byte[] fileBytes, string imageUrl, T obj);

        public abstract T GetObject(string id);

        public abstract void Delete(string id);

        public byte[] GetImage(string base64String)
        {
            byte[] imageBytes = null!;
            if (!string.IsNullOrEmpty(base64String))
            {
                imageBytes = Convert.FromBase64String(base64String);
            }
            return imageBytes;
        }
    }
}
