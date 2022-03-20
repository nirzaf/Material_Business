using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class WorkShopDb:DALBase
    {
        #region Get
        public List<tbl_Workshop> GetWorkshops()
        {
            List<tbl_Workshop> Ls;
            Ls = new List<tbl_Workshop>();

            string cmdStr = "select * from tbl_WorkShop";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tbl_Workshop Wp = new tbl_Workshop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();

                Ls.Add(Wp);
            }
            dr.Close();
            con.Close();
            return Ls;

        }
        public List<WorkShopRequest> GetWorkshopRequest()
        {
            List<WorkShopRequest> Ls;
            Ls = new List<WorkShopRequest>();

            string cmdStr = @"SELECT  tbl_User.UserId, tbl_User.UserName_Email,tbl_WorkShop.WorkShopId,
                tbl_WorkShop.WorkShopTitle, tbl_Student_WorkShop_Mapping.IsApproved      
                FROM    tbl_Student_WorkShop_Mapping Left outer JOIN      
                tbl_User ON tbl_User.UserId = tbl_Student_WorkShop_Mapping.StudentId Left outer JOIN      
                tbl_WorkShop ON tbl_Student_WorkShop_Mapping.WorkShopId = tbl_WorkShop.WorkShopId ";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WorkShopRequest Wp = new WorkShopRequest();
                Wp.UserId = int.Parse(dr["UserId"].ToString());
                Wp.UserName_Email = dr["UserName_Email"].ToString();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.IsApproved = (dr["IsApproved"].ToString() == "") ? false : bool.Parse(dr["IsApproved"].ToString());
                Ls.Add(Wp);
            }
            dr.Close();
            con.Close();
            return Ls;

        }
        public tbl_Workshop GetWorkshopById(int WorkShopId)
        {
            tbl_Workshop Wp = null;
            string cmdStr = "select * from tbl_WorkShop where WorkShopId=@WorkShopId";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Wp = new tbl_Workshop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();
            }
            dr.Close();
            con.Close();
            return Wp;

        } 
        #endregion
        
        #region Post

        #region Insert
        public bool InsertWorkshop(tbl_Workshop Wp, List<int> Ls)
        {

            SqlConnection con = new SqlConnection(conStr);

            string cmdStr = @"insert into tbl_WorkShop values(@WorkShopTitle,@WorkShopDate,@WorkShopDuration
                                            ,@WorkshopTopics,null,null,null,null) ;select Scope_Identity() as Id";
            string cmdStr2 = "insert into tbl_Trainer_WorkShop_Mapping values(@TrainerId,@WorkShopId,null,null,null,null) ";

            con.Open();
            SqlTransaction SqTrans = con.BeginTransaction();
            try
            {
                //Inserting Workshop
                SqlCommand cmd = new SqlCommand(cmdStr, con, SqTrans);
                cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkshopTopics", Wp.WorkShopTopics);
                SqlDataReader dr = cmd.ExecuteReader();

                //Reading WorkshopId returned from Scope_Identity
                int WorkShopId = 0;
                if (dr.Read())
                {
                    WorkShopId = int.Parse(dr[0].ToString());
                }
                dr.Close();

                //Inserting multiple records in tbl_Trainer_Workshop_Mapping 
                //with retrived WorkshopId from Scope_Identity
                //And TrainerIds from Ls
                if (WorkShopId != 0)
                {
                    foreach (var TrainerId in Ls)
                    {
                        SqlCommand cmd2 = new SqlCommand(cmdStr2, con, SqTrans);
                        cmd2.Parameters.AddWithValue("@TrainerId", TrainerId);
                        cmd2.Parameters.AddWithValue("@WorkshopId", WorkShopId);
                        cmd2.ExecuteNonQuery();
                    }
                }

                //If Every thing is successful then commiting the transaction
                SqTrans.Commit();
                con.Close();
                return true;
            }
            catch
            {
                //If any thing goes wrong then Rolling back the transaction
                SqTrans.Rollback();
                return false;
            }
        }
        public bool AssignTrainersToWorkShop(List<tbl_Trainer_WorkShop_Mapping> Ls)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlTransaction SqTrans = con.BeginTransaction();
            try
            {
                foreach (var item in Ls)
                {
                    string cmdStr = "insert into tbl_Trainer_WorkShop_Mapping values(@TrainerId,@WorkShopId,null,null,null,null) ";
                    SqlCommand cmd = new SqlCommand(cmdStr, con, SqTrans);
                    cmd.Parameters.AddWithValue("@TrainerId", item.TrainerId);
                    cmd.Parameters.AddWithValue("@WorkshopId", item.WorkShopId);
                    cmd.ExecuteNonQuery();
                }
                SqTrans.Commit();
                con.Close();
                return true;
            }
            catch
            {
                SqTrans.Rollback();
                return false;
            }
        } 
        #endregion

        #region Update
        public bool UpdateWorkshopById(tbl_Workshop Wp, int WorkShopId)
        {
            try
            {
                string cmdStr = @"Update tbl_WorkShop 
                                                Set WorkShopTitle=@WorkShopTitle,WorkShopDate=@WorkShopDate,
                                                WorkShopDuration=@WorkShopDuration,WorkshopTopics=@WorkshopTopics 
                                                where  WorkShopId=@WorkShopId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkshopTopics", Wp.WorkShopTopics);
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AppOrRejectWorkshopRequest(tbl_Student_WorkShop_Mapping swp)
        {
            try
            {
                string cmdStr = @"Update tbl_Student_WorkShop_Mapping 
                                                Set IsApproved=@IsApproved
                                                where  WorkShopId=@WorkShopId and StudentId=@StudentId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.Parameters.AddWithValue("@IsApproved", swp.IsApproved == true ? 1 : 0);
                cmd.Parameters.AddWithValue("@WorkShopId", swp.WorkShopId);
                cmd.Parameters.AddWithValue("@StudentId", swp.StudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Delete
        public bool DeleteWorkshopById(int WorkShopId)
        {
            try
            {
                string cmdStr = @"Delete from tbl_WorkShop where  WorkShopId=@WorkShopId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion
                
        #endregion
    }
}
