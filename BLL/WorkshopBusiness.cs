using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class WorkshopBusiness:BLLBase
    {
        WorkShopDb WD;
        public WorkshopBusiness()
        {
            WD = new WorkShopDb();
        }

        public List<WorkShopRequest> GetWorkshopRequest()
        {

            return WD.GetWorkshopRequest();
        }
        public bool AppOrRejectWorkshopRequest(tbl_Student_WorkShop_Mapping swp)
        {
            return WD.AppOrRejectWorkshopRequest(swp);
        }
        public bool InsertWorkshop(tbl_Workshop Wp, List<int> Ls)
        {
            //Workshopdate should be greater than current date
            if (Wp.WorkShopDate > DateTime.Now)
            {

                WD.InsertWorkshop(Wp, Ls);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<tbl_Workshop> GetWorkshops()
        {

            return WD.GetWorkshops();
        }
        public tbl_Workshop GetWorkshopById(int WorkShopId)
        {

            tbl_Workshop Wp = WD.GetWorkshopById(WorkShopId);
            return Wp;
        }
        public bool UpdateWorkshopById(tbl_Workshop Wp, int WorkShopId)
        {

            if (Wp.WorkShopDate > DateTime.Now)
            {
                WD.UpdateWorkshopById(Wp, WorkShopId);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteWorkshopById(int WorkShopId)
        {

            WD.DeleteWorkshopById(WorkShopId);
            return true;
        }
        public bool AssignTrainersToWorkShop(List<tbl_Trainer_WorkShop_Mapping> Ls)
        {

            WD.AssignTrainersToWorkShop(Ls);
            return true;
        }
    }
}
