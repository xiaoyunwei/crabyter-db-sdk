using System;
using System.Collections.Generic;

namespace Sinyoo.CrabyterDb.Models
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 性别。1：男；2：女；0：其他
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 注册时短信验证码
        /// </summary>
        public string ValidationCode { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 登陆秘密
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public string InvitationCode { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户注册的来源
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// 癌肿领域
        /// </summary>
        public string CancelDomain { get; set; }

        /// <summary>
        /// 资格证明图片URL
        /// </summary>
        public string QualificationUrl { get; set; }

        /// <summary>
        /// 最后修改密码时间
        /// </summary>
        public DateTime? PasswordLastModified { get; set; }
    }

    public class MobileCodePair
    {
        public string MobileNumber { get; set; }
        public string ValidationCode { get; set; }
    }

    public class LoginInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ModifyMobileInfo
    {
        public string OldMobileNumber { get; set; }
        public string OldValidationCode { get; set; }
        public string NewMobileNumber { get; set; }
        public string NewValidationCode { get; set; }
    }

    public class ModifyPasswordInfo
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class ResetPasswordInfo
    {
        public string MobileNumber { get; set; }
        public string ValidationCode { get; set; }
        public string NewPassword { get; set; }
    }

    public class SystemAuth
    {
        public string AuthCode { get; set; }

        public string AuthName { get; set; }
    }

    public class StudyActionList
    {
        public int StudyId { get; set; }

        public int SiteId { get; set; }

        public string Role { get; set; }

        public List<string> Actions { get; set; }
    }


}
