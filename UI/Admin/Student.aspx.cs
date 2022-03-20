using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetStudents();
        }
    }

    private void GetStudents()
    {
        UserBusiness UB = new UserBusiness();
        List<tbl_User> Ls = UB.GetStudents();
        grdStudents.DataSource = Ls;
        grdStudents.DataBind();
    }
}