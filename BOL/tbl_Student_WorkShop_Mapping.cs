using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class tbl_Student_WorkShop_Mapping
    {
        public int SerialNo { get; set; }
        public int StudentId { get; set; }
        public int WorkShopId { get; set; }
        public bool IsApproved { get; set; }
    }
}
