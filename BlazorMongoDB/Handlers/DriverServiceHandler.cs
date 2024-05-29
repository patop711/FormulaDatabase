using FormulaDatabase.Data;
using FormulaDatabase.IService;
using FormulaDatabase.Abstracts;

namespace FormulaDatabase.Handler
{
    public class DriverServiceHandler(IService<Driver, FormulaTeam> driverService) : Handler<Driver>
	{
        readonly IService<Driver, FormulaTeam> _driverService = driverService;
        public override void SaveInformation(byte[] fileBytes, string imageUrl, Driver driver)
        {
            driver.ImageUrl = imageUrl;
            driver.Photo = fileBytes;
            _driverService.SaveOrUpdate(driver);
        }

        public override Driver GetObject(string id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string id)
        {
			_driverService.Delete(id);
        }
    }
}
