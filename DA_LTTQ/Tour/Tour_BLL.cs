using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class Tour_BLL
    {
        Tour_DAL dalTour;
        public Tour_BLL()
        {
            dalTour = new Tour_DAL();
        }

        public DataTable GetTourBanChay()
        {
            return dalTour.GetTourBanChay();
        }

        public DataTable GetLocTour(tbl_Tour tour)
        {
            return dalTour.GetLocTour(tour);
        }

        public DataTable GetAllTour2(tbl_Tour tour)
        {
            return dalTour.GetAllTour2(tour);
        }

        public DataTable SearchTour(tbl_Tour tour)
        {
            return dalTour.SearchTour(tour);
        }

        public DataTable LocTour(tbl_Tour tour)
        {
            return dalTour.LocTour(tour);
        }

        public DataTable GetTTTour(tbl_Tour tour)
        {
            return dalTour.GetTTTour(tour);
        }

        public byte[] GetPhoto(tbl_Tour tour)
        {
            return dalTour.GetPhoto(tour);
        }

        public bool InsertTour(tbl_Tour tour)
        {
            return dalTour.InsertTour(tour);
        }

        public bool Update(tbl_Tour tour)
        {
            return dalTour.Update(tour);
        }

        public bool DeleteTour(tbl_Tour tour)
        {
            return dalTour.DeleteTour(tour);
        }

        public int GetMaTour()
        {
            return dalTour.GetMaTour();
        }

        public bool UpdatesltOUR(tbl_Tour tour, tbl_KhachHang khachhang)
        {
            return dalTour.UpdatesltOUR(tour, khachhang);
        }
    }
}
