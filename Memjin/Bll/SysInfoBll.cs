using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccConSys
{
    public class SysInfoBll
    {
        SysInfoDal siDal = new SysInfoDal();

        /// <summary>
        /// SysInfo系统参数表的查询
        /// </summary>
        /// <returns></returns>
        public List<SysInfo> QuerySysInfo()
        {
            return siDal.QuerySysInfo();
        }
    }
}
