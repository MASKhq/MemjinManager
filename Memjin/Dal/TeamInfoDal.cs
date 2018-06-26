using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class TeamInfoDal
    {
        /// <summary>
        /// TeamInfo班组的添加
        /// </summary>
        /// <param name="ti">TeamInfo对象</param>
        /// <returns></returns>
        public int InsertTeamInfo(TeamInfo ti)
        {
            string sql = "insert into TeamInfo(Team_name,Team_entrytime,Team_foreman,Team_Phone) values(@Team_name,@Teamentry_time,@Team_foreman,@Team_Phone)";

            SqlParameter[] pms =
            {
                new SqlParameter("@Team_name", ti.Team_name),
                new SqlParameter("@Team_entrytime", ti.Team_entrytime),
                new SqlParameter("@Team_foreman", ti.Team_foreman),
                new SqlParameter("@Team_Phone", ti.Team_Phone)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 根据班组TeamInfo的Id对班组的删除
        /// </summary>
        /// <param name="Team_id">班组id</param>
        /// <returns></returns>
        public int DeleteTeamInfo(int Team_id)
        {
            string sql = "update TeamInfo set State=0 where Team_id=@Team_id";

            SqlParameter[] pms =
            {
                new SqlParameter("@Team_id", Team_id)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 根据班组TeamInfo的Id对班组的其他信息的修改
        /// </summary>
        /// <param name="ti">TeamInfo对象</param>
        /// <returns></returns>
        public int UpdateTeamInfo(TeamInfo ti)
        {
            string sql = "update TeamInfo set Team_name=@Team_name,Team_entrytime=@Team_entrytime,Team_foreman=@Team_foreman,Team_Phone=@Team_Phone,State=@State where Team_id=@Team_id";

            SqlParameter[] pms =
            {
                new SqlParameter("@Team_name", ti.Team_name),
                new SqlParameter("@Team_entrytime", ti.Team_entrytime),
                new SqlParameter("@Team_foreman", ti.Team_foreman),
                new SqlParameter("@Team_Phone", ti.Team_Phone),
                new SqlParameter("@State", ti.State),
                new SqlParameter("@Team_id", ti.Team_id)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// TeamInfo班组的查询
        /// </summary>
        /// <returns></returns>
        public List<TeamInfo> QueryTeamInfo()
        {
            string sql = "select * from TeamInfo where State=1";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            List<TeamInfo> tiList = new List<TeamInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TeamInfo ti = new TeamInfo();
                ti.Team_id = int.Parse(dt.Rows[i]["Team_id"].ToString());
                ti.Team_name = dt.Rows[i]["Team_name"] as string;
                ti.Team_entrytime = Convert.ToDateTime(dt.Rows[i]["Team_entrytime"].ToString());
                ti.Team_foreman = dt.Rows[i]["Team_foreman"] as string;
                ti.Team_Phone = dt.Rows[i]["Team_Phone"] as string;
                tiList.Add(ti);
            }

            return tiList;
        }
    }
}
