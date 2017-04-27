using System;

using RestSharp.Portable;

namespace Sinyoo.CrabyterDb
{
    public class ServiceErrorArgs : EventArgs
    {
        public ServiceErrorArgs(Exception ex)
        {
            this.Exception = ex;
        }

        public Exception Exception { get; set; }

        public bool IsHandled { get; set; }
    }

    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }

        public Exception ResponseException { get; set; }
    }

    public interface IRestService
    {
        string ServiceEndpoint { get; }

        IAuthenticator GetAuthenticator(bool guest);

        void OnErrorOccured(Exception ex);
    }
}
