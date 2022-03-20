using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Approval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetWorkShopRequest();
        }
    }
    private void GetWorkShopRequest()
    {
        WorkshopBusiness WB = new WorkshopBusiness();
        List<WorkShopRequest> Ls = WB.GetWorkshopRequest();
        grdWorkShopRequest.DataSource = Ls;
        grdWorkShopRequest.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int Sid = int.Parse(grdWorkShopRequest.DataKeys[grdWorkShopRequest.SelectedIndex].Values["UserId"].ToString());
        int Wid = int.Parse(grdWorkShopRequest.DataKeys[grdWorkShopRequest.SelectedIndex].Values["WorkShopId"].ToString());
        bool IsAppOrRej = bool.Parse(rblApproveReject.SelectedValue.ToString());

        tbl_Student_WorkShop_Mapping swp = new tbl_Student_WorkShop_Mapping();
        swp.StudentId = Sid;
        swp.WorkShopId = Wid;
        swp.IsApproved = IsAppOrRej;

        WorkshopBusiness WB = new WorkshopBusiness();
        WB.AppOrRejectWorkshopRequest(swp);
        GetWorkShopRequest();
    }
}