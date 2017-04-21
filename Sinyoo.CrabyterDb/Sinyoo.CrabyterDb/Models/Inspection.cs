using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// 检查套餐
    /// </summary>
    public class InspectionPackage
    {
        public int Id { get; set; }

        /// <summary>
        /// 检查类型
        /// </summary>
        public string InspectionType { get; set; }

        /// <summary>
        /// 套餐代码
        /// </summary>
        public string PackageCode { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// 是否自定义
        /// </summary>
        public bool IsUserDefined { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 版本名称
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public Nullable<int> VersionNumber { get; set; }

        /// <summary>
        /// 子项列表
        /// </summary>
        public List<InspectionItem> Items { get; set; }
    }

    /// <summary>
    /// 检查套餐子项
    /// </summary>
    public class InspectionItem
    {
        /// <summary>
        /// 项目代码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 项目中文名
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 字段类型：0=数值；1=序列
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public Nullable<decimal> MinValue { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public Nullable<decimal> MaxValue { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 以逗号分隔的序列选项列表，如：+,-,+/-,2+,3+,4+,局灶+
        /// </summary>
        public string OptionList { get; set; }

        /// <summary>
        /// 正常值，如阴性
        /// </summary>
        public string NormalValue { get; set; }

        /// <summary>
        /// 辅助分类，如：神经内分泌肿瘤，用药及预后相关，其它方面检测
        /// </summary>
        public string ItemCategory { get; set; }

        /// <summary>
        /// 正常值范围
        /// </summary>
        public string ReferenceRange { get; set; }
    }
}
