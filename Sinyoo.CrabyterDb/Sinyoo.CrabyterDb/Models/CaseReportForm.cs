using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Sinyoo.CrabyterDb.Models;

namespace Sinyoo.CrabyterDb.Models
{
    /// <summary>
    /// CRF段
    /// </summary>
    public class CrfSection
    {        
        /// <summary>
        /// 用于序列化的默认构造函数
        /// </summary>
        public CrfSection()
        {
            this.FieldItems = new List<FieldItem>();
            this.Children = new List<CrfSection>();
        }

        /// <summary>
        /// 列表行CrfSection构造函数
        /// </summary>
        /// <param name="parentSection"></param>
        /// <param name="field"></param>
        private CrfSection(CrfSection parentSection, CrfField field)
        {
            this.FieldItems = new List<FieldItem>();
            this.Children = new List<CrfSection>();

            StudyPatientId = parentSection.StudyPatientId;
            CrfId = parentSection.CrfId;
            VisitId = parentSection.VisitId;
            StudyId = parentSection.StudyId;
            StudySiteId = parentSection.StudySiteId;
            RandomId = parentSection.RandomId;
            TableFieldId = field.StudyCrfFieldId;
            RowFieldCode = field.FieldCode;
            RowTableId = field.TableId;
            RowFieldId = field.StudyCrfFieldId;
            CrfType = CrfSectionType.Row;
            Status = 0;

            parentSection.Children.Add(this);
        }

        /// <summary>
        /// 课题 Id
        /// </summary>
        public int StudyId { get; set; }

        /// <summary>
        /// 课题中心 Id
        /// </summary>
        public int StudySiteId { get; set; }

        /// <summary>
        /// 病例 Id
        /// </summary>
        public int StudyPatientId { get; set; }

        /// <summary>
        /// 访视 Id
        /// </summary>
        public int VisitId { get; set; }

        /// <summary>
        /// 访视名称
        /// </summary>
        public string VisitName { get; set; }

        /// <summary>
        /// P_study_patient_crfdata.Crf_id
        /// </summary>
        public int CrfId { get; set; }

        /// <summary>
        /// CRF名称
        /// </summary>
        public string CrfName { get; set; }

        /// <summary>
        /// CRF表类型
        /// </summary>
        public CrfSectionType CrfType { get; set; }

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
        /// 字段列表
        /// </summary>
        public List<FieldItem> FieldItems { get; private set; }

        /// <summary>
        /// 为普通字段或分组标签添加字段项
        /// </summary>
        /// <param name="field">字段定义</param>
        /// <returns></returns>
        public FieldItem AddFieldItem(CrfField field)
        {
            FieldItem newFieldItem = null;

            if (!string.IsNullOrEmpty(field.FieldId) && !this.FieldItems.Any(p => p.FieldId == field.FieldId))
            {
                // 普通字段，且Section中没有该字段
                newFieldItem = new FieldItem(field);

                if (!string.IsNullOrEmpty(field.Settings.DefaultValue))
                {
                    newFieldItem.Value = field.Settings.DefaultValue;
                    newFieldItem.Text = field.Settings.DefaultValue;
                }

                this.FieldItems.Add(newFieldItem);

                this.AddChildrenFields(field);

                this.AddRemarkFieldItem(field);
            }
            else if (field.ElementType == ConstCamp.ELEMENT_TYPE_GROUP)
            {
                this.AddChildrenFields(field);
            }

            return newFieldItem;
        }

        /// <summary>
        /// 添加字段的子字段
        /// </summary>
        /// <param name="field"></param>
        private void AddChildrenFields(CrfField field)
        {
            foreach (CrfField child in field.Children)
                this.AddFieldItem(child);
        }

        /// <summary>
        /// 添加备注字段
        /// </summary>
        /// <param name="section"></param>
        /// <param name="field"></param>
        private FieldItem AddRemarkFieldItem(CrfField field)
        {
            FieldItem remarkFieldItem = null;

            if (field.SelectOptions != null)
            {
                foreach (FieldSelectOption option in field.SelectOptions)
                {
                    if (option.RemarkField != null)
                    {
                        remarkFieldItem = new FieldItem(option.RemarkField);
                        // 备注字段没有默认值，所以不需要设置默认值

                        this.FieldItems.Add(remarkFieldItem);

                        // 多个选项，正常情况下只有一个有备注字段，如“其他”
                        break;
                    }
                }
            }

            return remarkFieldItem;
        }

        public FieldItem this[string fieldId]
        {
            get
            {
                return this.FieldItems.First(p => p.FieldId == fieldId);
            }
        }

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
        ///     未录入 = 0,
        ///     首录中 = 1,
        ///     首录完成 = 2,
        ///     二录未通过 = 4,
        ///     录入完成 = 5,
        ///     已锁定 = 7,
        ///     质疑 = 8
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 查看模式
        /// </summary>
        public bool IsViewOnly { get; set; }

        /// <summary>
        /// 在列表中的作为某一行的Id
        /// </summary>
        public int RowId { get; set; }

        /// <summary>
        /// 在列表中的行号，从1开始
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 随机数Id
        /// </summary>
        public string RandomId { get; set; }

        /// <summary>
        /// 根CRF中的列表数据，每行为一个CrfSection
        /// </summary>
        public List<CrfSection> Children { get; set; }

        /// <summary>
        /// 根据列表字段为列表创建新行
        /// </summary>
        /// <param name="field">列表字段</param>
        /// <returns></returns>
        public CrfSection AddCrfSectionRow(CrfField field)
        {
            if (!field.ElementType.StartsWith(ConstCamp.ELEMENT_TYPE_TABLE))
                throw new ArgumentException("仅能为列表创建CrfSection");
            
            int rowIndex = 1;
            if (this.Children.Any(p => p.TableFieldId == field.StudyCrfFieldId))
                rowIndex = this.Children.Where(p => p.TableFieldId == field.StudyCrfFieldId).Max(p => p.RowIndex) + 1;

            CrfSection rowSection = new CrfSection(this, field);
            rowSection.RowIndex = rowIndex;

            // 添加字段
            foreach (CrfField tableField in field.Children)
                rowSection.AddFieldItem(tableField);

            return rowSection;
        }

        /// <summary>
        /// 根据检查套餐代码，添加检查子项列表行
        /// </summary>
        /// <param name="detailsTablefield"></param>
        /// <param name="package"></param>
        /// <returns></returns>
        public IEnumerable<CrfSection> AddInpectionDetailRows(CrfField detailsTablefield, InspectionPackage package)
        {
            List<CrfSection> addedSections = new List<CrfSection>();

            if (detailsTablefield.TableId == ConstCamp.INSPECT_DETAILS_TABLE_ID)
            {
                foreach (InspectionItem item in package.Items)
                {
                    // 为每个检查子项创建一个 CrfSection
                    CrfSection rowSection = this.AddCrfSectionRow(detailsTablefield);
                    addedSections.Add(rowSection);

                    // 字段赋值
                    foreach (FieldItem rfi in rowSection.FieldItems)
                    {
                        switch (rfi.FieldId)
                        {
                            case "Ti_code":
                                rfi.Text = item.ItemCode;
                                rfi.Value = item.ItemCode;
                                break;

                            case "Ti_name":
                                rfi.Text = item.ItemName;
                                rfi.Value = item.ItemName;
                                break;

                            case "Ti_minval":
                                rfi.Text = item.MinValue.HasValue ? item.MinValue.ToString() : "";
                                rfi.Value = item.MinValue.HasValue ? item.MinValue.ToString() : "";
                                break;

                            case "Ti_maxval":
                                rfi.Text = item.MaxValue.HasValue ? item.MaxValue.ToString() : "";
                                rfi.Value = item.MaxValue.HasValue ? item.MaxValue.ToString() : "";
                                break;

                            case "Ti_unit":
                                rfi.Text = item.Unit;
                                rfi.Value = item.Unit;
                                break;

                            case "Ti_referencerange":
                                rfi.Text = item.ReferenceRange;
                                rfi.Value = item.ReferenceRange;
                                break;

                            case "Ti_normalvalue":
                                rfi.Text = item.NormalValue;
                                rfi.Value = item.NormalValue;
                                break;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException($"'{detailsTablefield.FieldName}'不是检查明细表字段");
            }

            return addedSections;
        }

        public DateTime? CreateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? UpdatedBy { get; set; }
    }

    /// <summary>
    /// 字段项目
    /// </summary>
    public class FieldItem
    {
        public FieldItem()
        {

        }

        public FieldItem(CrfField field)
        {
            FieldCode = field.FieldCode;
            FieldId = field.FieldId;
            FieldName = field.FieldName;
            IsEncrypted = field.IsEncrypted;
            StudyCrfFieldId = field.StudyCrfFieldId;
            TableId = field.TableId;
            TableRowId = field.TableRowId;

            if (!string.IsNullOrEmpty(field.Settings.DefaultValue))
            {
                this.Text = field.Settings.DefaultValue;
                this.Value = field.Settings.DefaultValue;
            }
        }

        /// <summary>
        /// 表Id
        /// </summary>
        public string TableId { get; set; }

        /// <summary>
        /// 行标记Id
        /// </summary>
        public int TableRowId { get; set; }

        /// <summary>
        /// 字段Id，如Birthday
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 对应界面显示用的自增序号
        /// </summary>
        public string FieldCode { get; set; }

        /// <summary>
        /// 课题字段Id
        /// </summary>
        public int StudyCrfFieldId { get; set; }

        /// <summary>
        /// 字段值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 字段文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 字段状态，在enmFielddataStatus中定义
        ///     normal = 0,
        ///     disabled = 1,
        ///     hidden = 2
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 质疑状态，在enmCrfQueryStatus中定义
        ///     已开放 = 0,
        ///     已回复 = 1,
        ///     已撤销 = 2,
        ///     未开放 = 3,
        ///     已重启 = 5,
        ///     已关闭 = 9
        /// </summary>
        public int? QueryStatus { get; set; }

        /// <summary>
        /// 是否加密
        /// </summary>
        public bool IsEncrypted { get; set; }

        /// <summary>
        /// 变更历史
        /// </summary>
        public List<FieldItemChangeLog> ChangeLogs { get; set; }

        /// <summary>
        /// 附加文件
        /// </summary>
        public List<AttachedFile> Files { get; set; }

        /// <summary>
        /// 字段类型，标准与扩展
        /// </summary>
        public int FieldKind { get; set; }

        /// <summary>
        /// 字段在[T_fielddata]表中的Id
        /// </summary>
        public int TFieldDataId { get; set; }

        /// <summary>
        /// 对应[T_fielddata]表中的Irow_id
        /// </summary>
        public int IRowId { get; set; }

    }

    public class FieldItemChangeLog
    {
        /// <summary>
        /// 修改前值
        /// </summary>
        public string OldValue { get; set; }

        /// <summary>
        /// 修改前文本
        /// </summary>
        public string OldText { get; set; }

        /// <summary>
        /// 修改备注
        /// </summary>
        public string ChangeComments { get; set; }

        /// <summary>
        /// 修改用户Id
        /// </summary>
        public int ChangedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Changed { get; set; }
    }

    /// <summary>
    /// 附件信息
    /// </summary>
    public class AttachedFile
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileUrl { get; set; }
    }

    public enum CrfSectionType
    {
        /// <summary>
        /// 标准CRF表
        /// </summary>
        Standard = 1,

        /// <summary>
        /// 单行模式的弹窗CRF表
        /// </summary>
        Window,

        /// <summary>
        /// 列表中的CRF表，或者多行模式的弹窗CRF表
        /// </summary>
        Row
    }
}
