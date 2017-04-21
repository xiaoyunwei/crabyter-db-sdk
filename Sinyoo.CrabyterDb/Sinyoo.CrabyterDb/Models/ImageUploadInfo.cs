using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// 照片上传信息
    /// </summary>
    public class ImageUploadInfo
    {
        /// <summary>
        /// 课题Id
        /// </summary>
        public int StudyId { get; set; }

        /// <summary>
        /// 课题中心Id
        /// </summary>
        public int? SiteId { get; set; }

        /// <summary>
        /// 自动生成的病人编码，如20150808001,注册时不使用该参数
        /// </summary>
        public string PatientCode { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public ImageCategory Category { get; set; }

        /// <summary>
        /// 子类
        /// </summary>
        public string SubCategory { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// 上传到服务器后最终的文件名
        /// </summary>
        public string UploadedFileName { get; set; }

        /// <summary>
        /// 图片状态
        /// </summary>
        public ImageStatus Status { get; set; }

        /// <summary>
        /// 从阿里云返回的临时位置
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 从阿里云返回的临时缩略图位置
        /// </summary>
        public string ThumbnailUrl { get; set; }
    }

    public enum ImageStatus
    {
        /// <summary>
        /// 在Web端已删除
        /// </summary>
        Deleted = -1,

        /// <summary>
        /// 新上传，未录入
        /// </summary>
        New = 0,

        /// <summary>
        /// 已录入
        /// </summary>
        Input = 1,

        /// <summary>
        /// 作废的
        /// </summary>
        Obsolete = 2
    }

    public class DataSourceRetrievalInfo
    {
        public int StudyId { get; set; }

        public int? SiteId { get; set; }

        public string[] PatientCodes { get; set; }

        public DateTime? FromDate { get; set; }
    }

    public class PatientDataSourceInfo
    {
        public int StudyId { get; set; }

        public Nullable<int> StudySiteId { get; set; }

        public string PatientCode { get; set; }

        public int Status { get; set; }

        public Nullable<System.DateTime> InputTime { get; set; }

        public int StudyPatientId { get; set; }

        public Nullable<System.DateTime> CreateTime { get; set; }

        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> UpdateTime { get; set; }

        public string UpdatedBy { get; set; }

        /// <summary>
        /// 最后一张照片的上传时间
        /// </summary>
        public Nullable<DateTime> LastUploadTime { get; set; }
    }

    public class DataSourceEntryInfo
    {
        public int StudyId { get; set; }

        public Nullable<int> StudySiteId { get; set; }

        public string PatientCode { get; set; }

        public bool? EntryNotRequired { get; set; }

        public bool? IsImageMissing { get; set; }
    }

    public class PatientImageUploadInfo
    {
        /// <summary>
        /// 课题Id
        /// </summary>
        public int StudyPatientId { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public ImageCategory Category { get; set; }

        /// <summary>
        /// 子类
        /// </summary>
        public string SubCategory { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// 上传到服务器后最终的文件名
        /// </summary>
        public string UploadedFileName { get; set; }

    }

    public class MakeUpImageInfo
    {
        public int StudyId { get; set; }

        public string CustCode { get; set; }
    }

    /// <summary>
    /// 图片/附件类型的字段文件上传信息
    /// </summary>
    public class FileUploadInfo
    {
        /// <summary>
        /// 病例Id
        /// </summary>
        public int StudyPatientId { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// 上传到服务器后最终的文件名
        /// </summary>
        public string UploadedFileName { get; set; }
    }
}
