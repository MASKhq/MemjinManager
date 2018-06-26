using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class TeamInfo
    {
        public int Team_id { get; set; }//班组id
        public string Team_name { get; set; }//班组名
        public DateTime Team_entrytime { get; set; }//班组进厂时间
        public string Team_foreman { get; set; }//班组长
        public string Team_Phone { get; set; }//班组长电话
        public int State { get; set; }//状态
    }
}
