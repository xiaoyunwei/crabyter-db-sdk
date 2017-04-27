using System;
using System.Threading.Tasks;
using Sinyoo.CrabyterDb.Study;
using Sinyoo.CrabyterDb.Library;
using Sinyoo.CrabyterDb.Models;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;

namespace Sinyoo.CrabyterDb
{
    public class CrabyterAccount: IRestService
    {
        private RestHelper restHelper;

        public event EventHandler<ServiceErrorArgs> ErrorOccured;

        public CrabyterAccount(string endpoint, string accountName, string key)
        {
            ServiceEndpoint = endpoint;
            AccountName = accountName;
            Key = key;

            restHelper = new RestHelper(this);
        }

        /// <summary>
        /// 服务地址
        /// </summary>
        public string ServiceEndpoint { get; set; }

        /// <summary>
        /// 接口账户名
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 接口账户序列号
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 科研宝登陆用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 动态密码
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LoginAsync(string userName, string password)
        {
            LoginInfo info = new LoginInfo() { UserName = userName, Password = password };

            var result = await restHelper.ExecuteRequestAsync<CallResultInfo>("account/login", "info", info, Method.POST, true);

            if (result.CallResult == CallResultType.Success)
            {
                //登陆成功，设置 UserName 和 Token
                this.UserName = userName;
                this.Token = result.ResultMessage;

                return true;
            }
            else
            {
                //登陆失败，抛出异常
                //用户名不存在或用户名密码不匹配，通过异常信息返回错误原因
                //如果只返回False，则无法告知登陆失败原因
                Exception ex= new Exception(result.ErrorMessage);
                throw ex;
            }
        }

        /// <summary>
        /// 创建课题管理客户端
        /// </summary>
        /// <returns></returns>
        public StudyClient CreateStudyClient()
        {
            StudyClient client = new StudyClient(this);
            return client;
        }

        /// <summary>
        /// 创建病例管理客户端
        /// </summary>
        /// <returns></returns>
        public PatientClient CreatePatientClient()
        {
            PatientClient client = new PatientClient(this);
            return client;
        }

        /// <summary>
        /// 创建用户管理客户端
        /// </summary>
        /// <returns></returns>
        public UserClient CreateUserClient()
        {
            UserClient client = new UserClient(this);
            return client;
        }

        /// <summary>
        /// 创建知识库管理客户端
        /// </summary>
        /// <returns></returns>
        public LibraryClient CreateLibraryClient()
        {
            LibraryClient client = new LibraryClient(this);
            return client;
        }

        public IAuthenticator GetAuthenticator(bool guest)
        {
            IAuthenticator auth;

            if (guest)
            {
                auth = new HttpBasicAuthenticator(this.AccountName, this.Key);
            }
            else
            {
                auth = new HttpBasicAuthenticator(this.UserName, this.Token);
            }

            return auth;
        }

        public void OnErrorOccured(Exception ex)
        {
            ServiceErrorArgs args = new ServiceErrorArgs(ex);
            this.ErrorOccured?.Invoke(this, args);

            // 如果未将错误标记处已处理状态，则抛出异常
            if (!args.IsHandled)
                throw ex;
        }
    }
}
