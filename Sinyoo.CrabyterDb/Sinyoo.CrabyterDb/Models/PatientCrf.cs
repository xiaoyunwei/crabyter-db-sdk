using System;
using System.Collections.Generic;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// 病例CRF
    /// </summary>
    public class PatientCrf
    {
        /// <summary>
        /// CrfID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 课题ID
        /// </summary>
        public int Study_id { get; set; }
        /// <summary>
        /// Crf名称
        /// </summary>
        public string Crfname { get; set; }
        /// <summary>
        /// 录入状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 访视Id
        /// </summary>
        public int VisitId { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public bool IsEmpty { get; set; }

        /// <summary>
        /// 完成
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// 锁定
        /// </summary>
        public bool IsLocked { get; set; }
    }

    public class PatientCrfDataStatusInfo
    {
        public int PatientId { get; set; }

        public int CrfId { get; set; }

        public int VisitId { get; set; }

        //UpdateImageMissing = 0,
        //UpdateStatus = 1
        public OperationType Operation { get; set; }

        public bool IsImageMissing { get; set; }

        //录入完成 = 5,
        //已锁定 = 7,
        //CRF状态的改变只有这两种合法参数
        public string CrfStatus { get; set; }
    }

    /// <summary>
    /// 病例CRF的树形结构
    /// </summary>
    public class PatientCrfTree
    {
        // 节点标题
        public string Text { get; set; }

        // 节点属性
        public CrfTreeNodeAttributes Attributes { get; set; }

        // 子节点
        public List<PatientCrfTree> Children { get; set; }
    }

    public class CrfTreeNodeAttributes
    {
        //根据nodetype确定该Id是Crf Id或者X Id
        public int Id { get; set; }

        //访视Id
        public int VisitId { get; set; }

        //文本信息，示例"术前化疗第1周期 - 临床症状"
        public string NodeCode { get; set; }

        //父节点"studyx"或子节点"crf"
        public string NodeType { get; set; }

        //仅在父节点中使用
        public string IsTemplate { get; set; }

        //CRF状态
        public string CrfStatus { get; set; }

        //是否被标记照片缺失
        public bool IsImageMissing { get; set; }
    }


}
