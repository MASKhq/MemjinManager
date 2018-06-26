using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class PostInfoBll
    {
        PostInfoDal piDal = new PostInfoDal();
        /// <summary>
        /// PostInfo职务的添加
        /// </summary>
        /// <param name="pi">PostInfo对象</param>
        /// <returns></returns>
        public bool InsertPostInfo(PostInfo pi)
        {
            return piDal.InsertPostInfo(pi) > 0;
        }
        /// <summary>
        /// 根据职务PostInfo的Id对职务的删除
        /// </summary>
        /// <param name="Post_Id">班组id</param>
        /// <returns></returns>
        public bool DeletePostInfo(int Post_Id)
        {
            return piDal.DeletePostInfo(Post_Id) > 0;
        }
        /// <summary>
        /// 根据职务PostInfo的Id对职务的其他信息的修改
        /// </summary>
        /// <param name="pi">PostInfo对象</param>
        /// <returns></returns>
        public bool UpdatePostInfo(PostInfo pi)
        {
            return piDal.UpdatePostInfo(pi) > 0;
        }
        /// <summary>
        /// PostInfo职务的查询
        /// </summary>
        /// <returns></returns>
        public List<PostInfo> QueryPostInfo()
        {
            return piDal.QueryPostInfo();
        }
    }
}
