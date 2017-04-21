using System;

namespace Sinyoo.CrabyterDb.Models
{
    public class CallResultInfo
    {
        public CallResultType CallResult { get; set; }

        public string ErrorMessage { get; set; }

        public string ResultMessage { get; set; }
    }

    public enum CallResultType
    {
        Fail = 0,
        Success = 1
    }
}
