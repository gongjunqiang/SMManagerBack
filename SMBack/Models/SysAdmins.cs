using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    [Serializable]
    public class SysAdmins
    {
        public int LoginId { get; set; }
        public string LoginPwd { get; set; }
        public string AdminName { get; set; }
        public int AdminStatus { get; set; }
        public int RoleId { get; set; }

        //扩展属性
        public int LogId { get; set; }


    }
}
