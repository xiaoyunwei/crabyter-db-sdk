using System.Threading.Tasks;
using Sinyoo.CrabyterDb.Models;

namespace Sinyoo.CrabyterDb.Library
{
    public class LibraryClient : CrabyterClientBase
    {
        public LibraryClient(CrabyterAccount account) : base(account)
        {
        }

        /// <summary>
        /// 根据检查套餐代码获取套餐信息
        /// </summary>
        /// <param name="套餐代码"></param>
        /// <returns></returns>
        public async Task<InspectionPackage> GetInspectionPackageByCode(string packageCode)
        {
            var result = await restHelper.ExecuteRequestAsync<InspectionPackage>("library/inspection/{packageCode}", "packageCode", packageCode);
            return result;
        }
    }
}
