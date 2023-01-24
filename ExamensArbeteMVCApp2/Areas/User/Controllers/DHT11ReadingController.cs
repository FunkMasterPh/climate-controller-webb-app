using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;
using Utility.CloudCommunication;

namespace ExamensArbeteMVCApp2.Areas.User.Controllers
{
    [Area("User")]
    public class DHT11ReadingController : Controller
    {
        private readonly IUnitOfWork _uow;
        
        public DHT11ReadingController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region
        //API method for getting data to populate data table with
        [HttpGet]
        public IActionResult GetAllForDataTable()
        {
            var list = _uow.DHT11Reading.GetAll();
            var orderedList = list.Result.OrderByDescending(r => r.TimeOfReading);
            return Json(new { data = orderedList });
        }
        #endregion
    }
}
