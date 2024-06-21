using FormulaDatabase.Abstracts;
using FormulaDatabase.Data;
using MongoDB.Driver;

namespace FormulaDatabase.Service
{
    public class TeamService : Service<FormulaTeam, Driver>
    {
        private const string MONGO_URL = "mongodb://localhost:27017/";
        private const string MONGO_DATABASE = "FormulaDB";
        private const string MONGO_THIS_COLLECTION = "FormulaTeams";
        private const string MONGO_OTHER_COLLECTION ="Drivers";

        public TeamService() : base(MONGO_URL, MONGO_DATABASE, MONGO_THIS_COLLECTION, MONGO_OTHER_COLLECTION)
        {
        }

        public override void Delete(string id)
        {
            GetThisTable().DeleteOne(x => x.Id == id);
        }


        public override FormulaTeam GetData(string id)
        {
            return GetThisTable().Find(x => x.Id == id).FirstOrDefault();
        }

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
