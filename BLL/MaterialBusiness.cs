using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class MaterialBusiness:BLLBase
    {
        public void CreateMaterial(tbl_Material M)
        {
            MaterialDB MD = new MaterialDB();
            MD.CreateMaterial(M);
        }
        public List<WorkShopMaterial> GetMaterials()
        {
            MaterialDB MD = new MaterialDB();
           return MD.GetMaterials(); ;
        }
    }
}
