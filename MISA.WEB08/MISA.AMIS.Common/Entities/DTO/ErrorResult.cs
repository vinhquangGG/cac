namespace MISA.AMIS.Common
{

    public class ErrorResult
    {
        public ErrorResult(AmisErrorCode errorCode, string devMsg, string userMsg, object moreInfo, string? traceId = null)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }

        public AmisErrorCode ErrorCode { get; set; }
        public string DevMsg { get; set; }
        public string UserMsg { get; set; }
        public object MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}