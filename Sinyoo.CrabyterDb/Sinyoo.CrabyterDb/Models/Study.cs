using System;

namespace Sinyoo.CrabyterDb.Models
{
    public class Study
    {
        public int Id { get; set; }

        /// <summary>
        /// 课题类型
        /// </summary>
        public string StudyType { get; set; }

        /// <summary>
        /// 课题类型描述
        /// </summary>
        public string StudyTypeDescription { get; set; }

        /// <summary>
        /// 课题编码
        /// </summary>
        public string StudyCode { get; set; }

        /// <summary>
        /// 课题名称
        /// </summary>
        public string StudyName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 是否多中心
        /// </summary>
        public string IsMuiltiCenter { get; set; }

        /// <summary>
        /// 是否分组
        /// </summary>
        public string IsGroupExperiment { get; set; }

        /// <summary>
        /// 是否开启系统随机
        /// </summary>
        public string IsSystemRandom { get; set; }

        /// <summary>
        /// 是否已锁定
        /// </summary>
        public string IsLocked { get; set; }

        /// <summary>
        /// 课题状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 课题状态描述
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// 是否CRF已发布
        /// </summary>
        public string IsCrfPublished { get; set; }

        /// <summary>
        /// 图标地址
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// 总病例数需求
        /// </summary>
        public int RequiredPatientCount { get; set; }

        /// <summary>
        /// 当前用户在此课题中的角色
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// 当前用户在此课题中是否为课题负责人
        /// </summary>
        public bool IsPI { get; set; }

        /// <summary>
        /// 当前用户在此课题中是否为课题分中心负责人
        /// </summary>
        public bool IsSI { get; set; }

        /// <summary>
        /// 已入组病例数（包括进行中、锁定、剔除、退出）
        /// </summary>
        public int InGroupPatientCount { get; set; }

        /// <summary>
        /// 待入组病例数
        /// </summary>
        public int InQueuePatientCount { get; set; }

        /// <summary>
        /// 已锁定病例数
        /// </summary>
        public int LockedPatientCount { get; set; }

        /// <summary>
        /// 是否为演示课题
        /// </summary>
        public bool IsForDemo { get; set; }

        /// <summary>
        /// 课题介绍页面地址
        /// </summary>
        public string IntroductionUrl { get; set; }

        /// <summary>
        /// 最后一次更新病例数据的时间
        /// </summary>
        public DateTime? LastPatientUpdateTime { get; set; }

        /// <summary>
        /// (完成+锁定病例数)/RequiredPatientCount(总病例数需求)
        /// </summary>
        public int CompletionPercentage { get; set; }

    }

    /// <summary>
    /// 照片子类
    /// </summary>
    public class ImageSubCategory
    {
        /// <summary>
        /// 照片分类
        /// </summary>
        public ImageCategory Category { get; set; }

        /// <summary>
        /// 子类名称
        /// </summary>
        public string SubCategoryName { get; set; }
    }

    /// <summary>
    /// 课题中心
    /// </summary>
    public class StudySite
    {
        /// <summary>
        /// 中心Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 中心编码
        /// </summary>
        public string SiteCode { get; set; }

        /// <summary>
        /// 中心名称
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// 中心类型
        /// </summary>
        public StudySiteType SiteType { get; set; }

        /// <summary>
        /// 已入组病例数（包括进行中、锁定、剔除、退出）
        /// </summary>
        public int InGroupPatientCount { get; set; }

        /// <summary>
        /// 待入组病例数
        /// </summary>
        public int InQueuePatientCount { get; set; }

        /// <summary>
        /// 已锁定病例数
        /// </summary>
        public int LockedPatientCount { get; set; }

        /// <summary>
        /// 最后一次更新病例数据的时间
        /// </summary>
        public DateTime? LastPatientUpdateTime { get; set; }
    }
}
