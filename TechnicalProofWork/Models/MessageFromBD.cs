using Radzen;

namespace TechnicalProofWork.Models
{
    public class MessageFromBD
    {
        public string Message { get; set; }
        public string State { get; set; }
        public object Data { get; set; }
        public NotificationSeverity Severity { get; set; }
    }
}
