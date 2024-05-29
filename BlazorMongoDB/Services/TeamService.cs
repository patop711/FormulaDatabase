using FormulaDatabase.Abstracts;
using FormulaDatabase.Data;
using FormulaDatabase.IService;
using MongoDB.Driver;

namespace FormulaDatabase.Service
{
    public class TeamService : Service<FormulaTeam, Driver>
    {
        private const string MONGO_URL = "mongodb://localhost:27017/";
        private const string MONGO_DATABASE = "FormulaDB";
        private const string MONGO_THIS_COLLECTION = "FormulaTeams";
        private const string MONGO_OTHER_COLLECTION ="Drivers";
        //private readonly MongoClient _mongoClient = null!;
        //private readonly IMongoDatabase _database = null!;
        //private readonly IMongoCollection<FormulaTeam> _teamTable = null!;
        //private readonly IMongoCollection<Driver> _driverTable = null!;

        public TeamService() : base(MONGO_URL, MONGO_DATABASE, MONGO_THIS_COLLECTION, MONGO_OTHER_COLLECTION)
        {
        }

        //public void Delete(string id)
        //{
        //    _teamTable.DeleteOne(x => x.Id == id);
        //}

        public override void Delete(string id)
        {
            GetThisTable().DeleteOne(x => x.Id == id);
        }

        //public List<FormulaTeam> GetAllObjects()
        //{
        //    return _teamTable.Find(FilterDefinition<FormulaTeam>.Empty).ToList();
        //}

        //public FormulaTeam GetData(string id)
        //{
        //    return _teamTable.Find(x => x.Id == id).FirstOrDefault();
        //}

        public override FormulaTeam GetData(string id)
        {
            return GetThisTable().Find(x => x.Id == id).FirstOrDefault();
        }

        //public List<Driver> GetOtherList()
        //{
        //    return _driverTable.Find(FilterDefinition<Driver>.Empty).ToList();
        //}

        //public void SaveOrUpdate(FormulaTeam obj)
        //{
        //    var teamObj = _teamTable.Find(x => x.Id == obj.Id).FirstOrDefault();
        //    if (teamObj == null)
        //    {
        //        _teamTable.InsertOne(obj);
        //    }
        //    else
        //    {
        //        _teamTable.ReplaceOne(x => x.Id == obj.Id, obj);
        //    }
        //}

        public override void SaveOrUpdate(byte[] fileBytes, string imageUrl, FormulaTeam formulaTeam)
        {
            formulaTeam.ImageUrl = imageUrl;
            formulaTeam.Photo = fileBytes;

            var teamObj = GetThisTable().Find(x => x.Id == formulaTeam.Id).FirstOrDefault();
            if (teamObj == null)
            {
                GetThisTable().InsertOne(formulaTeam);
            }
            else
            {
                GetThisTable().ReplaceOne(x => x.Id == formulaTeam.Id, formulaTeam);
            }
        }
    }
}
