using System.Threading.Tasks;
using Sinyoo.CrabyterDb.Models;

namespace Sinyoo.CrabyterDb
{
    public class UserClient : CrabyterClientBase
    {
        public UserClient(CrabyterAccount account) : base(account)
        {
        }

        public async Task<Sinyoo.CrabyterDb.Models.User> GetCurrentUser()
        {
            var result = await restHelper.ExecuteRequestAsync<User>("account/getuser");
            return result;
        }
    }
}
