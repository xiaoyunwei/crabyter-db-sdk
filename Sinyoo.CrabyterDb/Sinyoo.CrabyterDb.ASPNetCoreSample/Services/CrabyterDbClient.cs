using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Sinyoo.CrabyterDb.Models;
using Sinyoo.CrabyterDb.Study;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Services
{
    public class CrabyterDbClient : ICrabyterDbServiceProvider
    {
        private readonly CrabyterApiOptions apiOptions;
        private readonly ILogger clientLogger;
        private CrabyterAccount account;

        public CrabyterDbClient(IOptions<CrabyterApiOptions> optionsAccessor, ILogger<CrabyterDbClient> logger, IHttpContextAccessor httpContextAccessor)
        {
            apiOptions = optionsAccessor.Value;
            clientLogger = logger;

            account = new CrabyterAccount(apiOptions.Endpoint, apiOptions.AccountName, apiOptions.Key);
            account.ErrorOccured += OnErrorOccured;

            this.GetAuthenticationInfo(httpContextAccessor.HttpContext);
        }

        private async void GetAuthenticationInfo(HttpContext httpContext)
        {
            var authenticateInfo = await httpContext.Authentication.GetAuthenticateInfoAsync(ConstantDefinitions.AUTH_SCHEME_NAME);
            if(authenticateInfo != null && authenticateInfo.Principal != null)
            {
                List<Claim> claims = authenticateInfo.Principal.Claims.ToList();
                this.UserName = claims.First(p => p.Type == ConstantDefinitions.AUTH_USER_NAME).Value;
                this.Token = claims.First(p => p.Type == ConstantDefinitions.AUTH_USER_TOKEN).Value;

                try
                {
                    UserClient userClient = account.CreateUserClient();
                    currentUser = await userClient.GetCurrentUser();
                }
                catch
                {
                    // Invalid UserName or Token
                    // Logout
                    this.UserName = "";
                    this.Token = "";
                    await httpContext.Authentication.SignOutAsync(ConstantDefinitions.AUTH_SCHEME_NAME);
                }
            }
        }

        public string UserName
        {
            get
            {
                return account.UserName;
            }
            set
            {
                account.UserName = value;
            }
        }

        public string Token
        {
            get
            {
                return account.Token;
            }
            set
            {
                account.Token = value;
            }
        }

        private User currentUser;
        public User User
        {
            get
            {
                return currentUser;
            }
        }

        private void OnErrorOccured(object sender, ServiceErrorArgs e)
        {
            clientLogger.LogError(e.Exception.Message);

            e.IsHandled = true;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            bool result = await account.LoginAsync(userName, password);

            if(result)
            {
                UserClient client = account.CreateUserClient();
                currentUser = await client.GetCurrentUser();
            }

            return result;
        }

        public async Task<bool> LogoutAsync()
        {
            bool result = await account.LogoutAsync();
            currentUser = null;
            return result;
        }

        public async Task<IEnumerable<CrabyterDb.Models.Study>> GetStudyList()
        {            
            StudyClient client = account.CreateStudyClient();
            var result = await client.GetStudies();
            return result;
        }

        public async Task<CrabyterDb.Models.Study> GetStudyById(int studyId)
        {
            StudyClient client = account.CreateStudyClient();
            var result = await client.GetStudy(studyId);
            return result;
        }
    }

    public class CrabyterApiOptions
    {
        public string Endpoint { get; set; }
        public string AccountName { get; set; }
        public string Key { get; set; }
    }
}
