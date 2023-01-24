using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;
using Utility.C2DUpdateEventService.Interfaces;
using Utility.CloudCommunication.Interfaces;

namespace ExamensArbeteMVCApp2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class C2DUpdateEventController : Controller
    {
        private readonly IC2DUpdateEventService _c2dus;
        private readonly ICloudCommunicationService _ccs;
        private readonly IUnitOfWork _uow;

        public C2DUpdateEventController(IC2DUpdateEventService cc2dus, ICloudCommunicationService ccs, IUnitOfWork uow)
        {
            _c2dus = cc2dus;
            _ccs = ccs;
            _uow = uow;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert()
        {
            C2DUpdateEventViewModel msg = new C2DUpdateEventViewModel();
            return View(msg);
        }

        [HttpPost]
        public IActionResult Upsert(C2DUpdateEventViewModel msg)
        {
            //Validation checks
            if (msg.LowerThreshold <= 0)
            {
                ModelState.AddModelError("CustomError", "Threshold must be greater than 0");
            }
            else if(msg.LowerThreshold > 100)
            {
                ModelState.AddModelError("CustomError", "Threshold must be lower than 0");
            }
            else if(msg.LowerThreshold > msg.UpperThreshold) 
            {
                ModelState.AddModelError("CustomError2", "Lower threshold can´t be higher than the upper threshold.");
            }

            if (msg.UpperThreshold <= 0)
            {
                ModelState.AddModelError("CustomError", "Threshold must be greater than 0");
            }
            else if (msg.UpperThreshold > 100)
            {
                ModelState.AddModelError("CustomError", "Threshold must be lower than 0");
            }
            else if (msg.UpperThreshold < msg.LowerThreshold)
            {
                ModelState.AddModelError("CustomError2", "Upper threshold can´t be lower than the lower threshold.");
            }

            if (!ModelState.IsValid) //check if input from user is empty or not a number
            {
                return View(msg);
            }
            //Validation checks end

            ClaimsPrincipal currentUser = this.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value; //get logged in users ID 

            _ccs.UpdateThresholdValues(msg.LowerThreshold.ToString(), msg.UpperThreshold.ToString()); //send new threshold value to IoT Device

            C2DUpdateEvent newEvent = new C2DUpdateEvent();
            newEvent = _c2dus.PopulateEvent(newEvent, userId, msg.LowerThreshold, msg.UpperThreshold); //populate C2DUpdateEvent

            _uow.DeviceUpdateEvent.Add(newEvent); //save event to database
            return Redirect("/User/DHT11Reading");
        }

        //API call to send toggle to IoT Device
        #region
        [Route("/Admin/C2DUpdateEvent/ToggleUltraSonicMister/{ultrasonicMisterState}")]
        public IActionResult ToggleUltraSonicMister([FromRoute]string ultrasonicMisterState)
        {
            _ccs.ToggleMister(ultrasonicMisterState);
            return Redirect("/User/DHT11Reading");
        }
        #endregion
    }
}
