using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class EmployeeInfo
    {
        public int Eb_Id { get; set; }
        public string Chip_number { get; set; }//芯片编号
        public string Username { get; set; }//姓名
        public string Contractor { get; set; }//承建商
        public string Picture { get; set; }//头像
        public string Phone { get; set; }//手机号
        public int Team_id { get; set; }//班组
        public int Post { get; set; }//职务
        public int Work_type { get; set; }//工种
        public string Id_card { get; set; }//身份证号
        public DateTime Entry_time { get; set; }//入职时间
        public DateTime Approach_time { get; set; }//进厂时间
        public DateTime Playing_time { get; set; }//出厂时间
        public string Eo_Nation { get; set; }//民族
        public string Blood_type { get; set; }//血型
        public int Educational_level { get; set; }//文化程度
        public string Address { get; set; }//地址
        public int State { get; set; }//状态
    }
}
