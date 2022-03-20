using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;


public partial class Admin_Trainer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTrainers();
        }
    }
    private void GetTrainers()
    {
        UserBusiness UB = new UserBusiness();
        List<tbl_User> Ls = UB.GetTrainers();
        grdTrainers.DataSource = Ls;
        grdTrainers.DataBind();
    }
    protected void txtSave_Click(object sender, EventArgs e)
    {
        tbl_User U = new tbl_User();
        U.UserName_Email = txtEmail.Text;
        U.FirstName = txtTrainerFirstName.Text;
        U.LastName = txtLastName.Text;
        U.RoleId = 2;
        UserBusiness UB = new UserBusiness();
        UB.CreateTrainer(U);
        GetTrainers();
    }
}