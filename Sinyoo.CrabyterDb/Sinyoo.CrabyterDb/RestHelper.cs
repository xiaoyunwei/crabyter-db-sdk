using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System.Net.Http;
using System.Net;

namespace Sinyoo.CrabyterDb
{
    public class RestHelper
    {
        IRestClient restClient;

        public RestHelper(IRestService serviceProvider)
        {
            this.ServiceProvider = serviceProvider;

            restClient = new RestClient(serviceProvider.ServiceEndpoint);
        }

        public IRestService ServiceProvider { get; private set; }

        public async Task<T> ExecuteRequestAsync<T>(string url, Dictionary<string, object> parameters = null, Method method = Method.GET, bool guest = false)
        {
            restClient.Authenticator = this.ServiceProvider.GetAuthenticator(guest);

            RestRequest request = new RestRequest(url, method);

            // 根据协议传递参数
            if (parameters != null)
            {
                foreach (var para in parameters)
                {
                    string strPara = "{" + para.Key + "}";

                    if (url.Contains(strPara))
                    {
                        request.AddUrlSegment(para.Key, para.Value);
                    }
                    else
                    {
                        if (method == Method.GET || method == Method.DELETE)
                            request.AddQueryParameter(para.Key, para.Value);
                        else if (method == Method.POST || method == Method.PUT)
                            request.AddParameter(para.Key, para.Value, ParameterType.RequestBody);
                    }
                }
            }

            Exception execException = null;
            T result = default(T);

            try
            {
                var response = await restClient.Execute<T>(request);
                result = response.Data;
            }
            catch (HttpRequestException requestException)
            {
                // 无效的Token，或者请求的路径错误
                execException = new Exception("访问被拒绝", requestException);
            }
            catch (WebException webException)
            {
                // 网络问题
                execException = new Exception("网络连接失败", webException);
            }
            catch (Exception ex)
            {
                execException = ex;
            }

            if (execException != null)
            {
                this.ServiceProvider.OnErrorOccured(execException);
            }

            return result;
        }

        public async Task<T> ExecuteRequestAsync<T>(string url, string paraName, object paraValue, Method method = Method.GET, bool guest = false)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(paraName))
                parameters.Add(paraName, paraValue);

            return await this.ExecuteRequestAsync<T>(url, parameters, method, guest);
        }
    }
}
