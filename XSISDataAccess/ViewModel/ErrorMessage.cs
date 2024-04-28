using System.Text.Json.Serialization;

namespace XSISDataAccess.ViewModel
{
    public class ErrorMessage
    {
        public string ErrorCode { get; set; } = "";
        public string Message { get; set; } = "";
        [JsonIgnore]
        public string TechnicalMessage { get; set; } = "";
    }
}
