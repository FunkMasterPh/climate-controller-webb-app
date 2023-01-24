using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Model for holding new threshold value for the CloudCommunicationSerivce class to send to IoT Device
    public class C2DUpdateEventViewModel
    {
        [DisplayName("Upper Threshold Value")]
        public int UpperThreshold { get; set; }
        [DisplayName("Lower Threshold Value")]
        public int LowerThreshold { get; set; }
    }
}
