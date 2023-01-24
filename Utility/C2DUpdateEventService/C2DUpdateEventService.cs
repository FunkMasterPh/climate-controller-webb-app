using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.C2DUpdateEventService.Interfaces;

namespace Utility.C2DUpdateEventService
{
    //Service class for population a new C2DUpdateEvent to be saved to the database
    public class C2DUpdateEventService : IC2DUpdateEventService
    {
        public C2DUpdateEvent PopulateEvent(C2DUpdateEvent updateEvent, string userId, int lowerThreshold, int upperThreshold)
        {
            updateEvent.UpdatedAtTime = DateTime.Now;
            updateEvent.UpdatedDoneBy = userId;
            updateEvent.UpdateType = SD.Humidity;
            updateEvent.LowerThreshold = lowerThreshold;
            updateEvent.UpperThreshold = upperThreshold;

            return updateEvent;
        }
    }
}
