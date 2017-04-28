using System.Threading.Tasks;
using System.Collections.Generic;
using Sinyoo.CrabyterDb.Models;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Services
{
    public interface ICrabyterDbServiceProvider
    {
        string UserName { get; set; }

        string Token { get; set; }

        User User { get; }

        Task<bool> LoginAsync(string userName, string password);

        Task<bool> LogoutAsync();

        Task<IEnumerable<CrabyterDb.Models.Study>> GetStudyList();

        Task<CrabyterDb.Models.Study> GetStudyById(int studyId);
    }
}
