using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinyoo.CrabyterDb.Models;
using RestSharp.Portable;

namespace Sinyoo.CrabyterDb.Study
{
    public class StudyClient : CrabyterClientBase
    {
        public StudyClient(CrabyterAccount account) : base(account)
        {

        }

        /// <summary>
        /// 获取课题列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Sinyoo.CrabyterDb.Models.Study>> GetStudies()
        {
            var result = await restHelper.ExecuteRequestAsync<IEnumerable<Sinyoo.CrabyterDb.Models.Study>>("study");
            return result;
        }

        /// <summary>
        /// 获取课题信息
        /// </summary>
        /// <returns></returns>
        public async Task<Sinyoo.CrabyterDb.Models.Study> GetStudy(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<Sinyoo.CrabyterDb.Models.Study>("study/{id}", "id", id);
            return result;
        }

        /// <summary>
        /// 获取向导式课题访视模板列表
        /// </summary>
        /// <param name="id">课题Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<VisitTemplate>> GetVisitTemplates(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<IEnumerable<VisitTemplate>>("study/{studyId}/visittemplates", "studyId", id);
            return result;
        }

        /// <summary>
        /// 获取课题图像类别
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ImageSubCategory>> GetImageCategories(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<IEnumerable<ImageSubCategory>>("study/{studyId}/imagecategories", "studyId", id);
            return result;
        }

        /// <summary>
        /// 获取可选课题模板列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Sinyoo.CrabyterDb.Models.Study>> GetTemplateStudies()
        {
            var result = await restHelper.ExecuteRequestAsync<IEnumerable<Sinyoo.CrabyterDb.Models.Study>>("study/availablestudies");
            return result;
        }

        /// <summary>
        /// 将模板课题添加为自己的课题
        /// </summary>
        /// <param name="study">模板课题</param>
        /// <returns></returns>
        public async Task<int> AddStudy(Sinyoo.CrabyterDb.Models.Study study)
        {
            var result = await restHelper.ExecuteRequestAsync<CallResultInfo>("study/addstudy", "study", study, Method.POST);

            if (result.CallResult == CallResultType.Success)
            {
                return int.Parse(result.ResultMessage);
            }
            else
            {
                Exception ex = new Exception(result.ErrorMessage);
                throw ex;
            }
        }

        /// <summary>
        /// 获取课题病例列表
        /// </summary>
        /// <param name="id">课题Id</param>
        /// <param name="siteId">中心Id</param>
        /// <param name="takeInFrom">起始入组时间</param>
        /// <param name="takeInTo">结束入组时间</param>
        /// <param name="patientName">病人姓名</param>
        /// <returns></returns>
        public async Task<IEnumerable<StudyPatient>> GetStudyPatients(int id, int? siteId = null, int skip = 0, int? count = null, DateTime? takeInFrom = null, DateTime? takeInTo = null, string patientName = "")
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studyId", id);
            if (siteId.HasValue)
                parameters.Add("siteId", siteId);
            if (takeInFrom.HasValue)
                parameters.Add("takeInFrom", takeInFrom);
            if (takeInTo.HasValue)
                parameters.Add("takeInTo", takeInTo);
            if (!string.IsNullOrEmpty(patientName))
                parameters.Add("patientName", patientName);
            if (skip > 0)
                parameters.Add("skip", skip);
            if (count.HasValue && count.Value > 0)
                parameters.Add("count", count);

            var result = await restHelper.ExecuteRequestAsync<IEnumerable<StudyPatient>>("study/{studyId}/patients", parameters);

            return result;
        }

        /// <summary>
        /// 获取课题中心列表
        /// </summary>
        /// <param name="id">课题Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<StudySite>> GetStudySites(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<IEnumerable<StudySite>>("study/{studyId}/sites", "studyId", id);
            return result;
        }

        /// <summary>
        /// 获取课题中心信息
        /// </summary>
        /// <param name="siteId">课题中心Id</param>
        /// <returns></returns>
        public async Task<StudySite> GetStudySite(int siteId)
        {
            var result = await restHelper.ExecuteRequestAsync<StudySite>("study/site/{id}", "studyId", siteId);
            return result;
        }
    }
}
