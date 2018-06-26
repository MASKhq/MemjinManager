using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class SysInfoDal
    {
        /// <summary>
        /// SysInfo系统参数表的查询
        /// </summary>
        /// <returns></returns>
        public List<SysInfo> QuerySysInfo()
        {
            string sql = "select * from SysInfo";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            List<SysInfo> siList = new List<SysInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SysInfo si = new SysInfo();
                si.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                si.Title = dt.Rows[i]["Title"].ToString();
                si.Value = dt.Rows[i]["Value"].ToString();
                siList.Add(si);
            }

            return siList;
        }
    }
}
