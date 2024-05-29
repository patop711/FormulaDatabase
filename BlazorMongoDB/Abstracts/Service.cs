using FormulaDatabase.Data;
using MongoDB.Driver;

namespace FormulaDatabase.Abstracts
{
    /// <summary>
    /// Interface pre CRUD operácie
    /// </summary>
    /// <typeparam name="T">Typ objektu</typeparam>
    /// <typeparam name="O">Typ iného objektu</typeparam>
    public abstract class Service<T,O>
    {
        private readonly MongoClient _mongoClient = null!;
        private readonly IMongoDatabase _database = null!;
        private readonly IMongoCollection<T> _thisCollection = null!;
        private readonly IMongoCollection<O> _otherCollection = null!;

        public Service(string connectionString, string databaseName, string thisCollection, string otherCollection)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            _thisCollection = _database.GetCollection<T>(thisCollection);
            _otherCollection = _database.GetCollection<O>(otherCollection);
        }

        public MongoClient GetMongoClient()
        {
            return _mongoClient;
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public IMongoCollection<T> GetThisTable()
        {
            return _thisCollection;
        }

        public IMongoCollection<O> GetOtherTable()
        {
            return _otherCollection;
        }

        public List<T> GetAllObjects()
        {
            return _thisCollection.Find(FilterDefinition<T>.Empty).ToList();
        }

        public List<O> GetOtherList()
        {
            return _otherCollection.Find(FilterDefinition<O>.Empty).ToList();
        }

        public abstract void SaveOrUpdate(byte[] fileBytes, string imageUrl, T obj);
        public abstract T GetData(string id);
        public abstract void Delete(string id);

        public byte[] ConvertImage(string base64String)
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
