using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class EmployeeInfoBll
    {
        EmployeeInfoDal eiDal = new EmployeeInfoDal();
        /// <summary>
        /// EmployeeInfo人员的添加
        /// </summary>
        /// <param name="ei">EmployeeInfo对象</param>
        /// <returns></returns>
        public bool InsertTeamInfo(EmployeeInfo ei)
        {
            return eiDal.InsertTeamInfo(ei) > 0;
        }
        /// <summary>
        /// 根据员工表EmployeeInfo的芯片编号对员工的删除
        /// </summary>
        /// <param name="Chip_number">员工Chip_number</param>
        /// <returns></returns>
        public bool DeleteEmployeeInfo(int Chip_number)
        {
            return eiDal.DeleteEmployeeInfo(Chip_number) > 0;
        }
        /// <summary>
        /// 根据员工表EmployeeInfo的芯片编号对员工的其他信息的修改
        /// </summary>
        /// <param name="ei">EmployeeInfo对象</param>
        /// <returns></returns>
        public bool UpdateEmployeeInfo(EmployeeInfo ei)
        {
            return eiDal.UpdateEmployeeInfo(ei) > 0;
        }
        /// <summary>
        /// 查询所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> QueryEmployeeInfo()
        {
            return eiDal.QueryEmployeeInfo();
        }
        /// <summary>
        /// 模糊查询员工信息表
        /// </summary>
        /// <param name="Post">职务id</param>
        /// <param name="Work_type">工种id</param>
        /// <param name="Team_id">班组id</param>
        /// <param name="Str_count">按姓名或承建商或手机号码查询</param>
        /// <returns></returns>
        public List<EmployeeInfo> SelectEmployeeInfo(int Post, int Work_type, int Team_id, string Str_count)
        {
            return eiDal.SelectEmployeeInfo(Post, Work_type, Team_id, Str_count);
        }
    }
}
