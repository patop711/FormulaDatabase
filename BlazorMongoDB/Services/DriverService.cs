using FormulaDatabase.Abstracts;
using FormulaDatabase.Data;
using FormulaDatabase.IService;
using MongoDB.Driver;

namespace FormulaDatabase.Service
{
    public class DriverService : Service<Driver, FormulaTeam>
    {
        private const string MONGO_URL = "mongodb://localhost:27017/";
        private const string MONGO_DATABASE = "FormulaDB";
        private const string MONGO_THIS_COLLECTION = "Drivers";
        private const string MONGO_OTHER_COLLECTION = "FormulaTeams";
        //private readonly MongoClient _mongoClient = null!;
        //private readonly IMongoDatabase _database = null!;
        //private readonly IMongoCollection<Driver> _driverTable = null!;
        //private readonly IMongoCollection<FormulaTeam> _teamTable = null!;

        public DriverService() : 
            base(MONGO_URL, MONGO_DATABASE, MONGO_THIS_COLLECTION, MONGO_OTHER_COLLECTION)
        {
        }

        //public void SaveOrUpdate(Driver obj)
        //{
        //    var driverObj = GetThisTable().Find(x => x.Id == obj.Id).FirstOrDefault();
        //    if (driverObj == null)
        //    {
        //        _driverTable.InsertOne(obj);
        //    }
        //    else
        //    {
        //        _driverTable.ReplaceOne(x => x.Id == obj.Id, obj);
        //    }

        //}

        //public void Delete(string id)
        //{
        //    _driverTable.DeleteOne(x => x.Id == id);
        //}

        //public List<Driver> GetAllObjects()
        //{
        //    return _driverTable.Find(FilterDefinition<Driver>.Empty).ToList();
        //}

        //public Driver GetData(string id)
        //{
        //    return _driverTable.Find(x => x.Id == id).FirstOrDefault();
        //}

        //public List<FormulaTeam> GetOtherList()
        //{
        //    return _teamTable.Find(FilterDefinition<FormulaTeam>.Empty).ToList();

        //}

        public override void SaveOrUpdate(byte[] fileBytes, string imageUrl, Driver driver)
        {
            driver.ImageUrl = imageUrl;
            driver.Photo = fileBytes;

            var driverObj = GetThisTable().Find(x => x.Id == driver.Id).FirstOrDefault();
            if (driverObj == null)
            {
                GetThisTable().InsertOne(driver);
            }
            else
            {
                GetThisTable().ReplaceOne(x => x.Id == driver.Id, driver);
            }
        }

        public override Driver GetData(string id)
        {
            return GetThisTable().Find(x => x.Id == id).FirstOrDefault();
        }

        public override void Delete(string id)
        {
            GetThisTable().DeleteOne(x => x.Id == id);
        }


    }
}
