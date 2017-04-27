using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Services
{
    public interface ICrabyterDbServiceProvider
    {
        string UserName { get; set; }

        string Token { get; set; }

        Task<bool> LoginAsync(string userName, string password);

        Task<IEnumerable<CrabyterDb.Models.Study>> GetStudyList();
    }
}
