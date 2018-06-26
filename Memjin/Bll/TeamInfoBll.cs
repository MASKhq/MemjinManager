using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class TeamInfoBll
    {
        TeamInfoDal tiDal = new TeamInfoDal();
        /// <summary>
        /// TeamInfo班组的添加
        /// </summary>
        /// <param name="ti">TeamInfo对象</param>
        /// <returns></returns>
        public bool InsertTeamInfo(TeamInfo ti)
        {
            return tiDal.InsertTeamInfo(ti) > 0;
        }
        /// <summary>
        /// 根据班组TeamInfo的Id对班组的删除
        /// </summary>
        /// <param name="Team_id">班组id</param>
        /// <returns></returns>
        public bool DeleteTeamInfo(int Team_id)
        {
            return tiDal.DeleteTeamInfo(Team_id) > 0;
        }
        /// <summary>
        /// 根据班组TeamInfo的Id对班组的其他信息的修改
        /// </summary>
        /// <param name="ti">TeamInfo对象</param>
        /// <returns></returns>
        public bool UpdateTeamInfo(TeamInfo ti)
        {
            return tiDal.UpdateTeamInfo(ti) > 0;
        }
        /// <summary>
        /// TeamInfo班组的查询
        /// </summary>
        /// <returns></returns>
        public List<TeamInfo> QueryTeamInfo()
        {
            return tiDal.QueryTeamInfo();
        }
    }
}
