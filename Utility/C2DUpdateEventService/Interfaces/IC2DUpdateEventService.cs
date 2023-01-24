using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.C2DUpdateEventService.Interfaces
{
    public interface IC2DUpdateEventService
    {
        public C2DUpdateEvent PopulateEvent(C2DUpdateEvent updateEvent, string userId, int lowerThreshold, int upperThreshold);
    }
}
