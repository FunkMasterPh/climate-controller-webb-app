using System.Configuration;
using System.Text;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;
using Utility.CloudCommunication.Interfaces;

namespace Utility.CloudCommunication
{
    //Service class for handling communication with Azure
    public class CloudCommunicationService : ICloudCommunicationService
    {
        private readonly IConfiguration _configuration;

        public CloudCommunicationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void UpdateThresholdValues(string lowerThreshold, string upperThreshold)
        {
            ServiceClient serviceClient;
            string connectionString = _configuration.GetConnectionString("IoTHubConnectionString");
            string deviceId = _configuration.GetConnectionString("IoTHubDeviceId");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            string msg = lowerThreshold + " " + upperThreshold;
            var commandMsg = new Message(Encoding.ASCII.GetBytes(msg));
            await serviceClient.SendAsync(deviceId, commandMsg);
        }

        public async void ToggleMister(string isChecked)
        {
            ServiceClient serviceClient;
            string connectionString = _configuration.GetConnectionString("IoTHubConnectionString");
            string deviceId = _configuration.GetConnectionString("IoTHubDeviceId");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);;
            var commandMsg = new Message(Encoding.ASCII.GetBytes(isChecked));
            await serviceClient.SendAsync(deviceId, commandMsg);
        }
    }
}
