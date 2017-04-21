using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.Authenticators;
using Sinyoo.CrabyterDb.Models;
using System.Net.Http;
using System.Net;

namespace Sinyoo.CrabyterDb
{
    public abstract class CrabyterClientBase : ICrabyterServiceProvider
    {
        protected RestHelper restHelper;

        public CrabyterClientBase(CrabyterAccount account)
        {
            this.Account = account;

            restHelper = new RestHelper(this);
        }

        protected CrabyterAccount Account { get; private set; }

        public IAuthenticator GetAuthenticator(bool guest)
        {
            return this.Account.GetAuthenticator(guest);
        }

        public void OnErrorOccured(Exception ex)
        {
            this.Account.OnErrorOccured(ex);
        }

        public string ServiceEndpoint
        {
            get
            {
                return this.Account.ServiceEndpoint;
            }
        }

    }
}
