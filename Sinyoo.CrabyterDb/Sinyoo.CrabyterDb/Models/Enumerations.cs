using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// 照片分类
    /// </summary>
    public enum ImageCategory
    {
        /// <summary>
        /// 临床病例
        /// </summary>
        MedicalDocument = 1,

        /// <summary>
        /// CRF表
        /// </summary>
        CaseReportForm
    }

    /// <summary>
    /// 课题中心分类，同 Crabyter.BLL.enmSiteType
    /// </summary>
    public enum StudySiteType
    {
        主中心 = 0,
        分中心 = 1,
        CRO = 3
    }

    /// <summary>
    /// 课题病例状态（for前瞻性）
    /// </summary>
    public enum StudyPatientStatus
    {
        待入组 = 0,
        试验中 = 1,
        已锁定 = 2,
        已退出 = 7,
        已剔除 = 8,
        筛选未通过 = 9
    }

    /// <summary>
    /// CRF表录入状态（双录）
    /// </summary>
    public enum CrfStatus
    {
        未录入 = 0,
        首录中 = 1,
        首录完成 = 2,
        二录未通过 = 4,
        录入完成 = 5,
        已锁定 = 7,
        质疑 = 8
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {
        UpdateImageMissing = 0,
        UpdateStatus = 1
    }

    /// <summary>
    /// 质疑状态
    /// </summary>
    public enum QueryStatus
    {
        已开放 = 0,
        已回复 = 1,
        已撤销 = 2,

        /// <summary>
        ///     未开放【Draft状态】
        /// </summary>
        未开放 = 3,

        /// <summary>
        ///     已重启
        /// </summary>
        已重启 = 5,

        已关闭 = 9
    }

    /// <summary>
    /// 质疑类型
    /// </summary>
    public enum QueryType
    {
        /// <summary>
        /// 系统
        /// </summary>
        System = 0,

        /// <summary>
        /// 手工
        /// </summary>
        Manual = 1
    }

    public enum SVOPEventType
    {
        入院 = 10,
        出院 = 11,
        门诊 = 12,
        化疗 = 20,
        放疗 = 21,
        手术 = 22,
        评估 = 30,
        随访 = 40,
        身故 = 90
    }

}
