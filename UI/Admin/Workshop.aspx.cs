using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

public partial class Admin_Workshop : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetWorkShops();
                GetTrainers();
            }
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message+"Kindly Contact Admin at 00-000-000000");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        tbl_Workshop Wp = new tbl_Workshop();
        Wp.WorkShopTitle = txtWorkShopTitle.Text;
        Wp.WorkShopDate = DateTime.Parse(txtWorkShopDate.Text);
        Wp.WorkShopTopics = txtWorkShopTopics.Text;
        Wp.WorkShopDuration = txtWorkShopDuration.Text;

        List<int> Ls = new List<int>();
        foreach (ListItem item in ckbLTrainers.Items)
        {
            int TrainerId;
            if (item.Selected)
            {
                TrainerId = int.Parse(item.Value);
                Ls.Add(TrainerId);
            }
        }

        WorkshopBusiness WB = new WorkshopBusiness();
        WB.InsertWorkshop(Wp, Ls);
        GetWorkShops();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(GridView1.SelectedValue.ToString());
        WorkshopBusiness WB = new WorkshopBusiness();
        tbl_Workshop Wp = WB.GetWorkshopById(id);
        txtWorkShopTitle.Text = Wp.WorkShopTitle;
        txtWorkShopDate.Text = Wp.WorkShopDate.ToString();
        txtWorkShopDuration.Text = Wp.WorkShopDuration;
        txtWorkShopTopics.Text = Wp.WorkShopTopics;
        ckbLTrainers.ClearSelection();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tbl_Workshop Wp = new tbl_Workshop();
        Wp.WorkShopTitle = txtWorkShopTitle.Text;
        Wp.WorkShopDate = DateTime.Parse(txtWorkShopDate.Text);
        Wp.WorkShopTopics = txtWorkShopTopics.Text;
        Wp.WorkShopDuration = txtWorkShopDuration.Text;

        WorkshopBusiness WB = new WorkshopBusiness();
        int id = int.Parse(GridView1.SelectedValue.ToString());
        WB.UpdateWorkshopById(Wp, id);

        GetWorkShops();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        WorkshopBusiness WB = new WorkshopBusiness();
        int id = int.Parse(GridView1.SelectedValue.ToString());
        WB.DeleteWorkshopById(id);
        GetWorkShops();
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        List<tbl_Trainer_WorkShop_Mapping> Ls = new List<tbl_Trainer_WorkShop_Mapping>();

        int WorkShopId = int.Parse(GridView1.SelectedValue.ToString());

        foreach (ListItem item in ckbLTrainers.Items)
        {
            if (item.Selected)
            {
                int TrainerId = int.Parse(item.Value);
                tbl_Trainer_WorkShop_Mapping twm = new tbl_Trainer_WorkShop_Mapping();
                twm.WorkShopId = WorkShopId;
                twm.TrainerId = TrainerId;
                Ls.Add(twm);
            }
        }

        if (Ls.Count() > 0)
        {
            WorkshopBusiness WB = new WorkshopBusiness();
            WB.AssignTrainersToWorkShop(Ls);
        }
    } 
    #endregion

    #region PrivateMethods
    private void GetTrainers()
    {
        UserBusiness UB = new UserBusiness();
        List<tbl_User> Ls = UB.GetTrainers();

        ckbLTrainers.DataSource = Ls;
        ckbLTrainers.DataTextField = "FirstName";
        ckbLTrainers.DataValueField = "UserId";
        ckbLTrainers.DataBind();
    }
    private void GetWorkShops()
    {
        WorkshopBusiness WB = new WorkshopBusiness();
        List<tbl_Workshop> Ls = WB.GetWorkshops();
        GridView1.DataSource = Ls;
        GridView1.DataBind();
    } 
    #endregion
  
}