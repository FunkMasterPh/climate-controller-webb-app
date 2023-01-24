namespace Utility.CloudCommunication.Interfaces
{
    public interface ICloudCommunicationService
    {
        public void UpdateThresholdValues(string lowerThreshold, string upperThreshold);
        public void ToggleMister(string isChecked);
    }
}
