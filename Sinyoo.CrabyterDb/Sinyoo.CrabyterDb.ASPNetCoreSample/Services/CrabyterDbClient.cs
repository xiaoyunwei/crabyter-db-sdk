﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
            if(authenticateInfo != null)
            {
                List<Claim> claims = authenticateInfo.Principal.Claims.ToList();
                this.UserName = claims.First(p => p.Type == ConstantDefinitions.AUTH_USER_NAME).Value;
                this.Token = claims.First(p => p.Type == ConstantDefinitions.AUTH_USER_TOKEN).Value;
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

        private void OnErrorOccured(object sender, ServiceErrorArgs e)
        {
            clientLogger.LogError(e.Exception.Message);

            e.IsHandled = true;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            bool result = await account.LoginAsync(userName, password);
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