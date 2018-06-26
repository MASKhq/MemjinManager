using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class PostInfo
    {
        public int Post_Id { get; set; }//职务表ID
        public string Post_name { get; set; }//职务名称
        public string Work_type { get; set; }//管理类别
        public int State { get; set; }//状态
    }
}
