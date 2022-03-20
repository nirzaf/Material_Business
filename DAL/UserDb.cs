using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDb : DALBase
    {
        public List<tbl_User> GetTrainers()
        {
            try
            {
                List<tbl_User> Ls;
                Ls = new List<tbl_User>();
                string cmdStr = @"SELECT        tbl_User.UserId, tbl_User.FirstName,tbl_User.LastName
                                            FROM            tbl_User INNER JOIN
                                            tbl_Role ON tbl_User.RoleId = tbl_Role.RoleId
                                            WHERE        (tbl_Role.RoleName = 'Trainer')";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tbl_User Tr = new tbl_User();
                    Tr.UserId = int.Parse(dr["UserId"].ToString());
                    Tr.FirstName = dr["FirstName"].ToString();
                    Tr.LastName = dr["LastName"].ToString();
                    Ls.Add(Tr);
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

        public bool CreateUserRequest(tbl_User U, int WorkShopId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlTransaction SqTrans = con.BeginTransaction();
            string cmdStr = @"insert into tbl_User (UserName_Email,RoleId) values(@UserName_Email,3);
                                            select Scope_Identity() as Id";
            string cmdStr2 = "insert into tbl_Student_WorkShop_Mapping values(@StudentId,@WorkShopId,NULL) ";
            try
            {
                //Inserting Workshop
                SqlCommand cmd = new SqlCommand(cmdStr, con, SqTrans);
                cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
                SqlDataReader dr = cmd.ExecuteReader();

                //Reading StudentId returned from Scope_Identity
                int StudentId = 0;
                if (dr.Read())
                {
                    StudentId = int.Parse(dr[0].ToString());
                }
                dr.Close();

                //Inserting record in tbl_Student_Workshop_Mapping 
                //with retrived StudentId from Scope_Identity
                SqlCommand cmd2 = new SqlCommand(cmdStr2, con, SqTrans);
                cmd2.Parameters.AddWithValue("@StudentId", StudentId);
                cmd2.Parameters.AddWithValue("@WorkshopId", WorkShopId);
                cmd2.ExecuteNonQuery();

                //If Every thing is successful then commiting the transaction
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

        public bool ValidateUser(tbl_User U)
        {
            string cmdStr = @"SELECT   *  FROM            tbl_User 
                                            WHERE        (UserName_Email=@UserName_Email and Password=@Password)";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
            cmd.Parameters.AddWithValue("@Password", U.Password);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                U.UserId = int.Parse(dr["UserId"].ToString());
                U.UserName_Email = dr["UserName_Email"].ToString();
                U.RoleId = int.Parse(dr["RoleId"].ToString());
            }

            dr.Close();
            con.Close();
            if (U.UserId != 0)
                return true;
            else
                return false;
        }

        public bool CreateTrainer(tbl_User U)
        {
            string cmdStr = @"insert into  tbl_User (UserName_Email,FirstName,LastName,RoleId)
                                            values  (@UserName_Email,@FirstName,@LastName,@RoleId)";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
            cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
            cmd.Parameters.AddWithValue("@LastName", U.LastName);
            cmd.Parameters.AddWithValue("@RoleId", U.RoleId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public List<tbl_User> GetStudents()
        {
            try
            {
                List<tbl_User> Ls;
                Ls = new List<tbl_User>();
                string cmdStr = @"SELECT        *
                                            FROM            tbl_User INNER JOIN
                                            tbl_Role ON tbl_User.RoleId = tbl_Role.RoleId
                                            WHERE        (tbl_Role.RoleName = 'Student')";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tbl_User Tr = new tbl_User();
                    Tr.UserId = int.Parse(dr["UserId"].ToString());
                    Tr.FirstName = dr["FirstName"].ToString();
                    Tr.LastName = dr["LastName"].ToString();
                    Tr.UserName_Email = dr["UserName_Email"].ToString();
                    Ls.Add(Tr);
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
