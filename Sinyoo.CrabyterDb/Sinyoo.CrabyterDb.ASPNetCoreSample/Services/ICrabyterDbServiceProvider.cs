using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinyoo.CrabyterDb;
using Sinyoo.CrabyterDb.Models;
using Sinyoo.CrabyterDb.Study;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Services
{
    public interface ICrabyterDbServiceProvider
    {
        string UserName { get; set; }

        string Token { get; set; }

        Task<bool> LoginAsync(string userName, string password);
    }
}
