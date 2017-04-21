using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sinyoo.CrabyterDb;
using Sinyoo.CrabyterDb.Models;
using RestSharp.Portable;
using Sinyoo.CrabyterDb.Library;

namespace Sinyoo.CrabyterDb.Study
{
    public class PatientClient : CrabyterClientBase
    {
        public PatientClient(CrabyterAccount account) : base(account)
        {

        }

        /// <summary>
        /// 获取病例基本信息
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <returns></returns>
        public async Task<StudyPatient> GetPatient(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<StudyPatient>("patient/{studyPatientId}", "studyPatientId", id);
            return result;
        }

        /// <summary>
        /// 获取病例Crf列表
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<PatientCrf>> GetPatientCrfList(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<IEnumerable<PatientCrf>>("patient/{studyPatientId}/crflist", "studyPatientId", id);
            return result;
        }

        /// <summary>
        /// 获取用于病例CRF模板详细信息
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <param name="crfId">CRF Id</param>
        /// <param name="visitId">访视Id</param>
        /// <param name="tableFieldId">如果是列表，列表字段Id</param>
        /// <returns></returns>
        public async Task<PatientCrfDetails> GetCrfDetails(int id, int crfId, int visitId, int? tableFieldId = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studyPatientId", id);
            parameters.Add("crfId", crfId);
            parameters.Add("visitId", visitId);
            if (tableFieldId.HasValue)
                parameters.Add("tableFieldId", tableFieldId);

            var result = await restHelper.ExecuteRequestAsync<PatientCrfDetails>("patient/{studyPatientId}/crfdetails", parameters);

            return result;
        }

        /// <summary>
        /// 通过病例、CRF、访视和列表的ID，获取某指定CRF的数据
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <param name="crfId">CRF Id</param>
        /// <param name="visitId">访视Id</param>
        /// <param name="tableFieldId">如果是列表，列表字段Id</param>
        /// <param name="rowId">如果是列表中某一行的CRF表，rowId是该行在系统中的编号</param>
        /// <param name="autoGenerateFieldItems">是否自动为缺少的字段补齐FieldItem对象</param>
        /// <returns></returns>
        private async Task<IEnumerable<CrfSection>> GetCrfData(int id, int crfId, int visitId, int? tableFieldId = null, int? rowId = null, bool autoMakeup = false)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studyPatientId", id);
            parameters.Add("crfId", crfId);
            parameters.Add("visitId", visitId);
            if (tableFieldId.HasValue)
                parameters.Add("tableFieldId", tableFieldId);
            if (rowId.HasValue)
                parameters.Add("rowId", rowId);
            parameters.Add("autoMakeup", autoMakeup);

            var result = await restHelper.ExecuteRequestAsync<IEnumerable<CrfSection>>("patient/{studyPatientId}/data", parameters);

            // 一张CRF表对应返回数据的一个CrfSection对象。如果一张CRF表上包含n个二级CRF表，则返回的CrfSection数量为n + 1个。
            // 这些CrfSection在返回的数组中在同一层，其中第一个为一级CRF，其余为二级；
            // 如果CRF表中包含列表，则列表中每一行是一个CrfSection，这些CrfSection在CRF表CrfSection的Children集合中
            // CRF表中列表每行的CrfSection，仅在FieldItems中包含行数据，行的CRF中还有列表，不会包含在行的CrfSection.Children中

            return result;
        }

        /// <summary>
        /// 通过病例、CRF、访视和列表的ID，获取某指定CRF的数据
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <param name="crfId">CRF Id</param>
        /// <param name="visitId">访视Id</param>
        /// <param name="autoMakeup">是否自动为缺少的字段补齐FieldItem对象</param>
        /// <returns></returns>
        public async Task<IEnumerable<CrfSection>> GetCrfData(int id, int crfId, int visitId, bool autoMakeup = false)
        {
            return await this.GetCrfData(id, crfId, visitId, null, null, autoMakeup);
        }

        /// <summary>
        /// 通过病例、CRF、访视和列表的ID，获取某指定CRF的数据
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <param name="crfId">CRF Id</param>
        /// <param name="visitId">访视Id</param>
        /// <param name="tableFieldId">如果是列表，列表字段Id</param>
        /// <param name="rowId">如果是列表中某一行的CRF表，rowId是该行在系统中的编号</param>
        /// <param name="autoMakeup">是否自动为缺少的字段补齐FieldItem对象</param>
        /// <returns></returns>
        public async Task<IEnumerable<CrfSection>> GetCrfData(int id, int crfId, int visitId, int tableFieldId, int rowId, bool autoMakeup = true)
        {
            return await this.GetCrfData(id, crfId, visitId, tableFieldId, rowId, autoMakeup);
        }

        /// <summary>
        /// 保存一个大CRF表上的一系列CRF表数据，包括二级CRF表或CRF表上的列表行
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public async Task<bool> SaveCrfData(IEnumerable<CrfSection> sections)
        {
            var result = await restHelper.ExecuteRequestAsync<CallResultInfo>("patient/savecrfdata", "sections", sections, Method.POST);

            if (result.CallResult == CallResultType.Success)
            {
                return true;
            }
            else
            {
                Exception ex = new Exception(result.ErrorMessage);
                throw ex;
            }
        }

        /// <summary>
        /// 保存单个CRF
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public async Task<bool> SaveCrfData(CrfSection section)
        {
            return await this.SaveCrfData(new CrfSection[] { section });
        }

        /// <summary>
        /// 根据检查套餐代码产生行
        /// </summary>
        /// <param name="parentCrfSection">列表所在的CRF表</param>
        /// <param name="tableField">检查子项目列表字段</param>
        /// <param name="inspectionPackageCode">检查套餐代码</param>
        /// <returns></returns>
        public async Task<IEnumerable<CrfSection>> GenerateInspectionRows(CrfSection parentCrfSection, CrfField tableField, string inspectionPackageCode)
        {
            LibraryClient libClient = this.Account.CreateLibraryClient();
            InspectionPackage package = await libClient.GetInspectionPackageByCode(inspectionPackageCode);

            if (package == null || string.IsNullOrEmpty(package.PackageCode))
                throw new ArgumentException("无效的检查套餐代码");

            var result = parentCrfSection.AddInpectionDetailRows(tableField, package);

            return result;
        }

        /// <summary>
        /// 创建新病例
        /// </summary>
        /// <param name="info">病例创建信息</param>
        /// <returns></returns>
        public async Task<int> AddPatient(PatientCreationInfo info)
        {
            var result = await restHelper.ExecuteRequestAsync<CallResultInfo>("patient", "info", info, Method.POST);

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
        /// 为向导式数据库中的病例添加访视
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<int> AddVisit(VisitCreationInfo info)
        {
            var result = await restHelper.ExecuteRequestAsync<CallResultInfo>("patient/addvisit", "info", info, Method.POST);

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
        /// 获取病例SVOP视图模型
        /// </summary>
        /// <param name="id">病例Id</param>
        /// <returns></returns>
        public async Task<SVOPModel> GetSVOPData(int id)
        {
            var result = await restHelper.ExecuteRequestAsync<SVOPModel>("patient/{id}/svop", "id", id);
            return result;
        }
    }
}
