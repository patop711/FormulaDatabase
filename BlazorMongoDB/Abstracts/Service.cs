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

        /// <summary>
        /// Konštruktor pre Service
        /// </summary>
        /// <param name="connectionString">URL databázy</param>
        /// <param name="databaseName">Meno databázy</param>
        /// <param name="thisCollection">Kolekcia pre danný servis</param>
        /// <param name="otherCollection">Kolekcia iného servisu</param>
        public Service(string connectionString, string databaseName, string thisCollection, string otherCollection)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            _thisCollection = _database.GetCollection<T>(thisCollection);
            _otherCollection = _database.GetCollection<O>(otherCollection);
        }

        /// <summary>
        /// Getter pre MongoClient
        /// </summary>
        /// <returns>MongoClient</returns>
        public MongoClient GetMongoClient()
        {
            return _mongoClient;
        }

        /// <summary>
        /// Getter pre IMongoDatabase
        /// </summary>
        /// <returns>Vráti databázu</returns>
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        /// <summary>
        /// Getter pre kolekciu
        /// </summary>
        /// <returns>Vráti dannú kolekciu</returns>
        public IMongoCollection<T> GetThisTable()
        {
            return _thisCollection;
        }

        /// <summary>
        /// Getter pre inú kolekciu
        /// </summary>
        /// <returns>Vráti dannú kolekciu</returns>
        public IMongoCollection<O> GetOtherTable()
        {
            return _otherCollection;
        }

        /// <summary>
        /// Getter na vratenie všetkých kolekcii
        /// </summary>
        /// <returns>Vráti všetky objekty v danej kolekcie</returns>
        public List<T> GetAllObjects()
        {
            return _thisCollection.Find(FilterDefinition<T>.Empty).ToList();
        }

        /// <summary>
        /// Getter na vratenie všetkých objektov z iných kolekcii
        /// </summary>
        /// <returns>Vráti všetky objekty z iných kolekcii</returns>
        public List<O> GetOtherList()
        {
            return _otherCollection.Find(FilterDefinition<O>.Empty).ToList();
        }

        /// <summary>
        /// Abstraktná metoda pre CRUD operáciu create alebo update
        /// </summary>
        /// <param name="fileBytes"></param>
        /// <param name="imageUrl"></param>
        /// <param name="obj"></param>
        public abstract void SaveOrUpdate(byte[] fileBytes, string imageUrl, T obj);
        /// <summary>
        /// Getter na vratenie objektu T
        /// </summary>
        /// <param name="id">id v databaze</param>
        /// <returns>T</returns>
        public abstract T GetData(string id);
        /// <summary>
        /// Metoda na vymazanie objektu z databázy
        /// </summary>
        /// <param name="id"></param>
        public abstract void Delete(string id);

        /// <summary>
        /// Metoda na konverziu obrázku na base64
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
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
