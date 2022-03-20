using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Material : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
}