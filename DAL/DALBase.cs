using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
  public  class DALBase
    {
       protected string conStr;
        public DALBase()
        {
            conStr = MySettings.Default.ConStr;
        }
    }
}
