using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    public class PatientQuery
    {
        public int Id { get; set; }
        public int StudyPatientId { get; set; }
        public int PatientCrfdataId { get; set; }
        public int CrfId { get; set; }
        public int CrfFieldId { get; set; }
        public int RowIndex { get; set; }
        public int IrowId { get; set; }
        public int FielddataId { get; set; }
        /// <summary>
        /// CRF相关访视Id
        /// </summary>
        public int VisitId { get; set; }
        public string QueryContent { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public System.DateTime QueryTime { get; set; }
        public Nullable<int> ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReplyContent { get; set; }
        public Nullable<int> ReplyUserId { get; set; }
        public string ReplyUserName { get; set; }
        public Nullable<System.DateTime> ReplyTime { get; set; }
        public string Oldvaluestr { get; set; }
        public string Newvaluestr { get; set; }
        public QueryStatus Status { get; set; }
        public QueryType QueryType { get; set; }
        public string CloseReason { get; set; }
        public Nullable<int> RuleId { get; set; }

        public string PatientName { get; set; }
        public string PatientNumber { get; set; }
        public string CrfName { get; set; }
        public string FieldName { get; set; }

        public string QueryUserRole { get; set; }

    }

    public class QueryCreateInfo
    {
        //不一定是Actually Crf Id，有可能是父Crf，传递左边树形结构的CrfId
        public int CrfId { get; set; }

        public int VisitId { get; set; }

        //[T_fielddata]中的Id
        public int TFieldDataId { get; set; }

        public string QueryContent { get; set; }

    }

    public class QueryReply
    {
        public int QueryId { get; set; }

        public string ReplyContent { get; set; }
    }

    public class QueryClose
    {
        public int QueryId { get; set; }

        public string CloseReason { get; set; }
    }

    public class QueryStatusInfo
    {
        public int QueryId { get; set; }

        public QueryStatus Status { get; set; }
    }

    public class QueryBatchOperationInfo
    {
        public int StudyId { get; set; }
        public string OperationName { get; set; }
        public int[] QueryIds { get; set; }
        public string Comment { get; set; }
    }
}
