using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// 添加访视信息
    /// </summary>
    public class VisitCreationInfo
    {
        /// <summary>
        /// 病例编号
        /// </summary>
        public int StudyPatientId { get; set; }

        /// <summary>
        /// 模板CRF Id
        /// </summary>
        public int CrfXId { get; set; }
    }

    /// <summary>
    /// 访视模板
    /// </summary>
    public class VisitTemplate
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模板CRF Id
        /// </summary>
        public int CrfXId { get; set; }
    }
}
