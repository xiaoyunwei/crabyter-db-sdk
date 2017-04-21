using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    public class PatientCrfDetails
    {
        public PatientCrfDetails()
        {
            this.Fields = new List<CrfField>();
        }

        /// <summary>
        /// 子Crf的标题（Y轴名称）
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// P_study_patient_crfdata.Id
        /// </summary>
        public int PatientCrfId { get; set; }

        /// <summary>
        /// 课题 Id
        /// </summary>
        public int StudyId { get; set; }

        /// <summary>
        /// 课题中心 Id
        /// </summary>
        public int? StudySiteId { get; set; }

        /// <summary>
        /// 病例 Id
        /// </summary>
        public int StudyPatientId { get; set; }

        /// <summary>
        /// 访视 Id
        /// </summary>
        public int VisitId { get; set; }

        /// <summary>
        /// P_study_patient_crfdata.Crf_id
        /// </summary>
        public int CrfId { get; set; }

        /// <summary>
        /// CRF表类型
        /// </summary>
        public int CrfType { get; set; }

        /// <summary>
        /// 作为弹窗的子CRF表的TableFieldId，对应原Table_field_id
        /// </summary>
        public int TableFieldId { get; set; }

        /// <summary>
        /// 作为列表的CrfSection的TableId，对于原Df_tableid
        /// </summary>
        public string RowTableId { get; set; }

        /// <summary>
        /// 作为列表的CrfSection的FieldId，对应原Table_field_id。非列表的CrfSection该字段为0
        /// </summary>
        public int RowFieldId { get; set; }

        /// <summary>
        /// 作为列表的CrfSection的FieldCode
        /// </summary>
        public string RowFieldCode { get; set; }

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

        /// <summary>
        /// 状态，enmCrfStatusDL
        /// </summary>
        /*
        未录入 = 0,
        录入中 = 1,
        录入完成 = 5,
        已锁定 = 7,
        质疑 = 8
        */
        public int? Status { get; set; }

        /// <summary>
        /// 查看模式
        /// </summary>
        public bool IsViewOnly { get; set; }

        /// <summary>
        /// 是否缺少图片
        /// </summary>
        public bool IsImageMissing { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? UpdatedBy { get; set; }

        /// <summary>
        /// 字段列表
        /// </summary>
        public List<CrfField> Fields { get; set; }

        public CrfField this[string fieldId]
        {
            get
            {
                return this.Fields.First(p => p.FieldId == fieldId);
            }
        }

        public CrfField FindTableField(string tableId)
        {
            return this.Fields.FirstOrDefault(p => p.ElementType.StartsWith(ConstCamp.ELEMENT_TYPE_TABLE) && p.TableId == tableId);
        }

        /// <summary>
        /// 处理子Crf的情况
        /// </summary>
        public List<PatientCrfDetails> Children { get; set; }
    }

    public class CrfField
    {
        public CrfField()
        {
            this.Settings = new CrfFieldSettings();
            this.Children = new List<CrfField>();
        }

        /// <summary>
        /// 字段Id，如Birthday
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// 表Id
        /// </summary>
        public string TableId { get; set; }

        /// <summary>
        /// 行标记Id
        /// </summary>
        public int TableRowId { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段英文名称
        /// </summary>
        public string FieldNameEnglish { get; set; }

        /// <summary>
        /// 中文别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 英文别名
        /// </summary>
        public string AliasEnglish { get; set; }

        /// <summary>
        /// 对应界面显示用的自增序号
        /// </summary>
        public string FieldCode { get; set; }

        /// <summary>
        /// 课题字段Id
        /// </summary>
        public int StudyCrfFieldId { get; set; }

        /// <summary>
        /// 如果是列表字段，是否在列表中显示
        /// </summary>
        public bool ShowInList { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        /*
        field,
        labelfield,
        label,
        table,
        tableandwindow,
        group,
        file,
        button,
        remark,
        line
        */
        public string ElementType { get; set; }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        /*
        字符 = 0,
        序列 = 1,
        数字 = 2,
        日期 = 3
        */
        public int FieldDataType { get; set; }

        /// <summary>
        /// 输入控件类型
        /// </summary>
        /*
        checkbox
        combox
        datepicker
        datetext
        dropdownlist
        file
        hidden
        number
        radio
        text
        textarea，多行文本
        */
        public string InputType { get; set; }

        /// <summary>
        /// 字段状态，在enmFielddataStatus中定义
        /// </summary>
        /*
        normal = 0,
        disabled = 1,
        hidden = 2
        */
        public int Status { get; set; }

        /// <summary>
        /// 质疑状态，在enmCrfQueryStatus中定义
        /// </summary>
        /*
        待处理 = 0,
        已回复 = 1,
        已撤销 = 2,
        未开放 = 3,
        已开放 = 4,
        已重启 = 5,
        已关闭 = 9
        */
        public int? QueryStatus { get; set; }

        /// <summary>
        /// 是否加密
        /// </summary>
        public bool IsEncrypted { get; set; }

        /// <summary>
        /// 选项列表
        /// </summary>
        public List<FieldSelectOption> SelectOptions { get; set; }

        /// <summary>
        /// 联动字段信息
        /// </summary>
        public RelatedActionFieldInfo RelatedActionField { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public CrfFieldSettings Settings { get; set; }

        /// <summary>
        /// 作为列表内的字段集合
        /// </summary>
        public List<CrfField> Children { get; private set; }

        public CrfField this[string fieldId]
        {
            get
            {
                return this.Children.First(p => p.FieldId == fieldId);
            }
        }
    }

    /// <summary>
    /// 字段选项
    /// </summary>
    public class FieldSelectOption
    {
        /// <summary>
        /// 项目值
        /// </summary>
        public string ItemValue { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderIndex { get; set; }

        /// <summary>
        /// 是否常用字段
        /// </summary>
        public bool IsGeneral { get; set; }

        /// <summary>
        /// 作为某字段的备注字段
        /// </summary>
        public CrfField RemarkField { get; set; }
    }

    /// <summary>
    /// 用于控制显示的关联字段信息
    /// </summary>
    public class RelatedActionFieldInfo
    {
        /// <summary>
        /// 关联字段Id
        /// </summary>
        public string FieldCode { get; set; }

        /// <summary>
        /// 关联动作值
        /// </summary>
        public string ActionValue { get; set; }

        /// <summary>
        /// 关联动作
        /// </summary>
        /*
        disable
        enable
        hide
        show
        */
        public string ActionType { get; set; }
    }

    public class CrfFieldSettings
    {
        /// <summary>
        /// 是否在新一行中显示
        /// </summary>
        public bool StartFromNewRow { get; set; }

        /// <summary>
        /// 字段是否显示
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 字段名是否显示
        /// </summary>
        public bool IsFieldNameVisible { get; set; }

        /// <summary>
        /// 输入型字段输入框是否显示
        /// </summary>
        public bool IsInputVisible { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// 标题（适用于group、table、tableandwindow）
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 左标签
        /// </summary>
        public string LeftLabel { get; set; }

        /// <summary>
        /// 右标签
        /// </summary>
        public string RightLabel { get; set; }

        /// <summary>
        /// 列表的设置信息
        /// </summary>
        public TableFieldSettings TableSettings { get; set; }

        /// <summary>
        /// 如果是文件/图片字段，是否允许上传多张图片
        /// </summary>
        public bool IsMultipleFilesAllowed { get; set; }
    }

    /// <summary>
    /// 列表的设置信息
    /// </summary>
    public class TableFieldSettings
    {
        /// <summary>
        /// 显示列标题
        /// </summary>
        public bool ShowcColumnHeader { get; set; }

        /// <summary>
        /// 显示行号
        /// </summary>
        public bool ShowLineNumber { get; set; }

        /// <summary>
        /// 允许添加行
        /// </summary>
        public bool AllowAddLine { get; set; }

        /// <summary>
        /// 允许删除行
        /// </summary>
        public bool AllowDeleteLine { get; set; }

        /// <summary>
        /// 允许拖拽（上移下移）
        /// </summary>
        //public bool AllowDrag { get; set; }

        /// <summary>
        /// 允许删除预设行
        /// </summary>
        public bool AllowDeleteDefaultLine { get; set; }

        /// <summary>
        /// 显示重置默认值的按钮
        /// </summary>
        public bool ShowResetButton { get; set; }

        /// <summary>
        /// 是否显示“从异常检查添加不良事件”按钮
        /// </summary>
        //public bool ShowAddAdverseEventButton { get; set; }

        /// <summary>
        /// 是否显示“从病灶表选择”按钮
        /// </summary>
        //public bool ShowSelectFromFocusTableButton { get; set; }

        /// <summary>
        /// 是否显示“自动计算结果”按钮
        /// </summary>
        //public string ShowAutoCalculateButton { get; set; }

    }

    public class FieldSelectOptionInfo
    {
        /// <summary>
        /// 字段Id
        /// </summary>
        public int StudyCrfFieldId { get; set; }

        /// <summary>
        /// 用户输入关键字
        /// </summary>
        public string SearchKey { get; set; }

    }

    /// <summary>
    /// 唯一确定一张CRF表的信息
    /// </summary>
    public class CrfInfo
    {
        /// <summary>
        /// 病例Id
        /// </summary>
        public int StudyPatientId { get; set; }

        /// <summary>
        /// CRF的Id
        /// </summary>
        public int CrfId { get; set; }

        /// <summary>
        /// 访视Id
        /// </summary>
        public int VisitId { get; set; }
    }

    /// <summary>
    /// 列表默认行信息
    /// </summary>
    public class DefaultTableRow
    {
        public int Rowindex { get; set; }
        public string Irow_id { get; set; }
        public Dictionary<string, string> FieldDatas { get; set; }
    }
}
