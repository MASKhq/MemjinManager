using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class PostInfoDal
    {
        /// <summary>
        /// PostInfo职务的添加
        /// </summary>
        /// <param name="pi">PostInfo对象</param>
        /// <returns></returns>
        public int InsertPostInfo(PostInfo pi)
        {
            string sql = "insert into PostInfo(Post_name,Work_type) values(@Post_name,@Work_type)";

            SqlParameter[] pms =
            {
                new SqlParameter("@Post_name", pi.Post_name),
                new SqlParameter("@Work_type", pi.Work_type)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 根据职务PostInfo的Id对职务的删除
        /// </summary>
        /// <param name="Post_Id">班组id</param>
        /// <returns></returns>
        public int DeletePostInfo(int Post_Id)
        {
            string sql = "update PostInfo set State=0 where Post_Id=@Post_Id";

            SqlParameter[] pms =
            {
                new SqlParameter("@Post_Id", Post_Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// 根据职务PostInfo的Id对职务的其他信息的修改
        /// </summary>
        /// <param name="pi">PostInfo对象</param>
        /// <returns></returns>
        public int UpdatePostInfo(PostInfo pi)
        {
            string sql = "update TeamInfo set Post_name=@Post_name,Work_type=@Work_type,State=@State where Post_Id=@Post_Id";

            SqlParameter[] pms =
            {
                new SqlParameter("@Post_name", pi.Post_name),
                new SqlParameter("@Work_type", pi.Work_type),
                new SqlParameter("@State", pi.State),
                new SqlParameter("@Post_Id", pi.Post_Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, pms);
        }
        /// <summary>
        /// PostInfo职务的查询
        /// </summary>
        /// <returns></returns>
        public List<PostInfo> QueryPostInfo()
        {
            string sql = "select * from PostInfo where State=1";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            List<PostInfo> piList = new List<PostInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PostInfo pi = new PostInfo();
                pi.Post_Id = int.Parse(dt.Rows[i]["Post_Id"].ToString());
                pi.Post_name = dt.Rows[i]["Post_name"] as string;
                pi.Work_type = dt.Rows[i]["Work_type"] as string;
                piList.Add(pi);
            }

            return piList;
        }
    }
}
