using BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MaterialDB:DALBase
    {

        public bool CreateMaterial(BOL.tbl_Material M)
        {
            string cmdStr = @"insert into  tbl_Material (MaterialPath,WorkShopId)
                                            values  (@MaterialPath,@WorkShopId)";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            cmd.Parameters.AddWithValue("@MaterialPath", M.MaterialPath);
            cmd.Parameters.AddWithValue("@WorkShopId", M.WorkShopId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public List<WorkShopMaterial> GetMaterials()
        {
            try
            {
                List<WorkShopMaterial> Ls;
                Ls = new List<WorkShopMaterial>();
                string cmdStr = @"SELECT  M.MaterialId,M.MaterialDescription,M. MaterialPath, W.WorkShopTitle 
                                                FROM  tbl_Material M join tbl_Workshop W on M.WorkShopId=W.WorkShopId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    WorkShopMaterial Mt = new WorkShopMaterial();
                    Mt.MaterialId = int.Parse(dr["MaterialId"].ToString());
                    Mt.WorkShopTitle = dr["WorkShopTitle"].ToString();
                    Mt.MaterialDescription = dr["MaterialDescription"].ToString();
                    Mt.MaterialPath = dr["MaterialPath"].ToString();
                    Ls.Add(Mt);
                }
                dr.Close();
                con.Close();
                return Ls;
            }
            catch
            {
                throw;
            }
        }
    }
}
