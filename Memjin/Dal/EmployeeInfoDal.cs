using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class EmployeeInfoDal
    {
        /// <summary>
        /// EmployeeInfo人员的添加
        /// </summary>
        /// <param name="ei">EmployeeInfo对象</param>
        /// <returns></returns>
        public int InsertTeamInfo(EmployeeInfo ei)
        {
            string sql = "insert into EmployeeInfo(Chip_number,Username,Contractor,Picture,Phone,Team_id,Post,Work_type,Id_card,Entry_time,Approach_time,Playing_time,Eo_Nation,Blood_type,Educational_level,Address) values(@Chip_number,@Username,Contractor,@Picture,@Phone,@Team_id,@Post,@Work_type,@Id_card,@Entry_time,@Approach_time,@Playing_time,@Eo_Nation,@Blood_type,@Educational_level,@Address)";

            SqlParameter[] pms =
            {
                new SqlParameter("@Chip_number", ei.Chip_number),
                new SqlParameter("@Username", ei.Username),
                new SqlParameter("@Contractor", ei.Contractor),
                new SqlParameter("@Picture", ei.Picture),
                new SqlParameter("@Phone", ei.Phone),
                new SqlParameter("@Team_id", ei.Team_id),
                new SqlParameter("@Post", ei.Post),
                new SqlParameter("@Work_type", ei.Work_type),
                new SqlParameter("@Id_card", ei.Id_card),
                new SqlParameter("@Entry_time", ei.Entry_time),
                new SqlParameter("@Approach_time", ei.Approach_time),
                new SqlParameter("@Playing_time", ei.Playing_time),
                new SqlParameter("@Eo_Nation", ei.Eo_Nation),
                new SqlParameter("@Blood_type", ei.Blood_type),
                new SqlParameter("@Educational_level", ei.Educational_level),
                new SqlParameter("@Address", ei.Address),
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 根据员工表EmployeeInfo的芯片编号对员工的删除
        /// </summary>
        /// <param name="Chip_number">员工Chip_number</param>
        /// <returns></returns>
        public int DeleteEmployeeInfo(int Chip_number)
        {
            string sql = "update EmployeeInfo set State=10000 where Chip_number=@Chip_number";

            SqlParameter[] pms =
            {
                new SqlParameter("@Chip_number", Chip_number)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 根据员工表EmployeeInfo的芯片编号对员工的其他信息的修改
        /// </summary>
        /// <param name="ei">EmployeeInfo对象</param>
        /// <returns></returns>
        public int UpdateEmployeeInfo(EmployeeInfo ei)
        {
            string sql = "update TeamInfo set Username=@Username,Contractor=@Contractor,Picture=@Picture,Phone=@Phone,Team_id=@Team_id,Post=@Post,Work_type=@Work_type,Id_card=@Id_card,Entry_time=@Entry_time,Approach_time=@Approach_time,Playing_time=@Playing_time,Eo_Nation=@Eo_Nation,Blood_type=@Blood_type,Educational_level=@Educational_level,Address=@Address,State=@State where Chip_number=@Chip_number";

            SqlParameter[] pms =
            {
                new SqlParameter("@Username", ei.Username),
                new SqlParameter("@Contractor", ei.Contractor),
                new SqlParameter("@Picture", ei.Picture),
                new SqlParameter("@Phone", ei.Phone),
                new SqlParameter("@Team_id", ei.Team_id),
                new SqlParameter("@Post", ei.Post),
                new SqlParameter("@Work_type", ei.Work_type),
                new SqlParameter("@Id_card", ei.Id_card),
                new SqlParameter("@Entry_time", ei.Entry_time),
                new SqlParameter("@Approach_time", ei.Approach_time),
                new SqlParameter("@Playing_time", ei.Playing_time),
                new SqlParameter("@Eo_Nation", ei.Eo_Nation),
                new SqlParameter("@Blood_type", ei.Blood_type),
                new SqlParameter("@Educational_level", ei.Educational_level),
                new SqlParameter("@Address", ei.Address),
                new SqlParameter("@State", ei.State),
                new SqlParameter("@Chip_number", ei.Chip_number)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 查询所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> QueryEmployeeInfo()
        {
            string sql = "select * from EmployeeInfo where State=10001";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            List<EmployeeInfo> eiList = new List<EmployeeInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeInfo ei = new EmployeeInfo();
                ei.Chip_number = dt.Rows[i]["Chip_number"].ToString();
                ei.Username = dt.Rows[i]["Username"].ToString();
                ei.Contractor = dt.Rows[i]["Contractor"].ToString();
                ei.Picture = dt.Rows[i]["Picture"].ToString();
                ei.Phone = dt.Rows[i]["Phone"].ToString();
                ei.Team_id = int.Parse(dt.Rows[i]["Team_id"].ToString());
                ei.Post = int.Parse(dt.Rows[i]["Post"].ToString());
                ei.Work_type = int.Parse(dt.Rows[i]["Work_type"].ToString());
                ei.Id_card = dt.Rows[i]["Id_card"].ToString();
                ei.Entry_time = Convert.ToDateTime(dt.Rows[i]["Entry_time"].ToString());
                ei.Approach_time = Convert.ToDateTime(dt.Rows[i]["Approach_time"].ToString());
                ei.Playing_time = Convert.ToDateTime(dt.Rows[i]["Playing_time"].ToString());
                ei.Eo_Nation = dt.Rows[i]["Eo_Nation"].ToString();
                ei.Blood_type = dt.Rows[i]["Blood_type"].ToString();
                ei.Educational_level = int.Parse(dt.Rows[i]["Educational_level"].ToString());
                ei.Address = dt.Rows[i]["Address"].ToString();
                ei.State = int.Parse(dt.Rows[i]["State"].ToString());
                eiList.Add(ei);
            }

            return eiList;
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
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from EmployeeInfo where State=10001");
            if (Post > 0)
            {
                sb.Append(" and Post='"+ Post + "'");
            }
            if (Work_type > 0)
            {
                sb.Append(" and Work_type='" + Work_type + "'");
            }
            if (Team_id > 0)
            {
                sb.Append(" and Team_id='" + Team_id + "'");
            }
            if (Str_count != "")
            {
                sb.Append(" and (Username='" + Str_count + "' or Contractor='" + Str_count + "' or Phone='" + Str_count + "')");
            }
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString());

            List<EmployeeInfo> eiList = new List<EmployeeInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeInfo ei = new EmployeeInfo();
                ei.Chip_number = dt.Rows[i]["Chip_number"].ToString();
                ei.Username = dt.Rows[i]["Username"].ToString();
                ei.Contractor = dt.Rows[i]["Contractor"].ToString();
                ei.Picture = dt.Rows[i]["Picture"].ToString();
                ei.Phone = dt.Rows[i]["Phone"].ToString();
                ei.Team_id = int.Parse(dt.Rows[i]["Team_id"].ToString());
                ei.Post = int.Parse(dt.Rows[i]["Post"].ToString());
                ei.Work_type = int.Parse(dt.Rows[i]["Work_type"].ToString());
                ei.Id_card = dt.Rows[i]["Id_card"].ToString();
                ei.Entry_time = Convert.ToDateTime(dt.Rows[i]["Entry_time"].ToString());
                ei.Approach_time = Convert.ToDateTime(dt.Rows[i]["Approach_time"].ToString());
                ei.Playing_time = Convert.ToDateTime(dt.Rows[i]["Playing_time"].ToString());
                ei.Eo_Nation = dt.Rows[i]["Eo_Nation"].ToString();
                ei.Blood_type = dt.Rows[i]["Blood_type"].ToString();
                ei.Educational_level = int.Parse(dt.Rows[i]["Educational_level"].ToString());
                ei.Address = dt.Rows[i]["Address"].ToString();
                ei.State = int.Parse(dt.Rows[i]["State"].ToString());
                eiList.Add(ei);
            }

            return eiList;
        }
    }
}
