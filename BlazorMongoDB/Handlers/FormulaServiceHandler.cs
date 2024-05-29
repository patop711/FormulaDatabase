using FormulaDatabase.Data;
using FormulaDatabase.IService;
using FormulaDatabase.Abstracts;

namespace FormulaDatabase.Handler
{
    public class FormulaServiceHandler(IService<FormulaTeam, Driver> teamService) : Handler<FormulaTeam>
	{
        readonly IService<FormulaTeam, Driver> _teamService = teamService;

        public override void SaveInformation(byte[] fileBytes, string imageUrl, FormulaTeam team)
        {
            team.ImageUrl = imageUrl;
            team.Photo = fileBytes;
            _teamService.SaveOrUpdate(team);
        }

        public override FormulaTeam GetObject(string id)
        {
            var team = _teamService.GetData(id);
            if (team.Photo != null)
            {
                team.Photo = GetImage(Convert.ToBase64String(team.Photo));
                team.ImageUrl = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(team.Photo));
            }
            return team;
        }

        public override void Delete(string id)
        {
            _teamService.Delete(id);
        }
    }
}
