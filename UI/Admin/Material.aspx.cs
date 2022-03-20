using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Material : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetWorkShops();
            GetMaterials();
        }
    }

    private void GetMaterials()
    {
        MaterialBusiness MB = new MaterialBusiness();
        List<WorkShopMaterial> Ls = MB.GetMaterials();
        grdMaterial.DataSource = Ls;
        grdMaterial.DataBind();
    }
    private void GetWorkShops()
    {
        WorkshopBusiness WB = new WorkshopBusiness();
        List<tbl_Workshop> Ls = WB.GetWorkshops();
       ddlWorkshop.DataSource = Ls;
       ddlWorkshop.DataValueField = "WorkShopId";
       ddlWorkshop.DataTextField = "WorkShopTitle";
        ddlWorkshop.DataBind();
    } 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (fuldMaterial.HasFile)
        {
            string path = Server.MapPath("~//Material//");
            fuldMaterial.SaveAs(path + fuldMaterial.FileName);
            tbl_Material M = new tbl_Material();
            M.WorkShopId = int.Parse(ddlWorkshop.SelectedValue);
            M.MaterialPath = "~//Material//" + fuldMaterial.FileName;
            MaterialBusiness MB = new MaterialBusiness();
            MB.CreateMaterial(M);
            GetMaterials();
        }

    }
}