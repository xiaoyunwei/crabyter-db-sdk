using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// 课题病例
    /// </summary>
    public class StudyPatient
    {
        public int Id { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 课题ID
        /// </summary>
        public int StudyId { get; set; }

        /// <summary>
        /// 课题中心ID
        /// </summary>
        public int StudySiteId { get; set; }

        /// <summary>
        /// 入组时间
        /// </summary>
        public DateTime? TakeInDate { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        public int ArmId { get; set; }

        /// <summary>
        /// 分组编号
        /// </summary>
        public string ArmCode { get; set; }

        /// <summary>
        /// 病例编号
        /// </summary>
        public string PatientNumber { get; set; }

        /// <summary>
        /// 病例姓名代码
        /// </summary>
        public string PatientNameInitials { get; set; }

        /// <summary>
        /// 随机号
        /// </summary>
        public string Randomnumber { get; set; }

        /// <summary>
        /// 筛选号
        /// </summary>
        public string FilterNumber { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 联系电话1
        /// </summary>
        public string Telephone1 { get; set; }

        /// <summary>
        /// 联系电话2
        /// </summary>
        public string Telephone2 { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 生存状态
        /// </summary>
        public string Survivalstatus { get; set; }

        /// <summary>
        /// 身故日期
        /// </summary>
        public DateTime? DeathDate { get; set; }

        /// <summary>
        /// 身故原因
        /// </summary>
        public string DeathCause { get; set; }

        /// <summary>
        /// 是否随访失联
        /// </summary>
        public bool? IsFollowUpLost { get; set; }

        /// <summary>
        /// 患者知情
        /// </summary>
        public bool? IsInformed { get; set; }

        /// <summary>
        /// 末次治疗时间
        /// </summary>
        public DateTime? LastTreatmentDate { get; set; }

        /// <summary>
        /// 末次随访日期
        /// </summary>
        public DateTime? LastFollowUpDate { get; set; }

        /// <summary>
        /// 研究结束日期
        /// </summary>
        public DateTime? ResearchEndDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建用户名
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新用户名
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// 照片缺失
        /// </summary>
        public bool IsImageMissing { get; set; }

        /// <summary>
        /// 是否有照片
        /// </summary>
        public bool HasImage { get; set; }
    }

    /// <summary>
    /// 病例创建信息
    /// </summary>
    public class PatientCreationInfo
    {
        public int StudyId { get; set; }

        public int? SiteId { get; set; }

        public string PatientName { get; set; }

        /// <summary>
        /// 病例编号
        /// </summary>
        public string PatientNumber { get; set; }

        /// <summary>
        /// 病例姓名代码
        /// </summary>
        public string PatientNameInitials { get; set; }

        /// <summary>
        /// 入组时间
        /// </summary>
        public DateTime? TakeInDate { get; set; }
    }

    public class PatientStatusInfo
    {
        public int StudyPatientId { get; set; }

        //UpdateImageMissing = 0,
        //UpdateStatus = 1
        public OperationType Operation { get; set; }

        public bool IsImageMissing { get; set; }

        //待入组 = 0,
        //试验中 = 1,
        //已锁定 = 2,
        //已退出 = 7,
        //已剔除 = 8,
        //筛选未通过 = 9
        public string Status { get; set; }
    }

    /// <summary>
    /// 病例随机分组所需信息
    /// </summary>
    public class PatientArmInfo
    {
        public int StudyPatientId { get; set; }
    }

}
