namespace DatingAPP.Error
{
    public class ApiException
    {
        public ApiException(int satusCode, string message, string details)
        {
            SatusCode = satusCode;
            Message = message;
            Details = details;
        }

        public int SatusCode { get; set; }
        public string Message { get; set; }

        public string Details { get; set; }
    }
}
