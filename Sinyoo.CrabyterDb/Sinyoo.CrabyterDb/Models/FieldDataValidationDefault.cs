using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    public class FieldDataValidationDefault
    {
        public FieldDataValidationDefault()
        {
            this.ValidationDefaults = new List<ValidationDefault>();
        }

        public string FieldId { get; set;}

        public string FieldName { get; set; }

        public List<ValidationDefault> ValidationDefaults { get; private set; }
    }

    /// <summary>
    /// 对指定字段的规则验证结果
    /// </summary>
    public class ValidationDefault
    {
        /// <summary>
        /// 自定义验证规则记录Id
        /// </summary>
        public int RuleId { get; set; }

        /// <summary>
        /// 自定义验证规则名称
        /// </summary>
        public string RuleName { get; set; }

        /// <summary>
        /// 规则验证异常提示消息
        /// </summary>
        public string DefaultMessage { get; set; }

        public ValidationDefaultType Type { get; set; }
    }

    public enum ValidationDefaultType
    {
        Warning = 1,
        Error = 2
    }
}
