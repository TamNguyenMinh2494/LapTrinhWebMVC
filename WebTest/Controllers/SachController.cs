using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;
namespace WebTest.Controllers
{
    public class SachController : Controller
    {
        // GET: SachMoiPartial
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public PartialViewResult NewArrivalPartial()
        {
            var listNewArrival = db.Saches.Take(3).ToList();
            return PartialView(listNewArrival);
        }
        //Action xem chi tiết
        public ViewResult XemChiTiet(int MaSach=0)
        {
            Sach sach = db.Saches.SingleOrDefault(n=>n.MaSach == MaSach);
            if(sach == null)
            {
                //trả về trang báo lỗi nếu k tìm thấy sách
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
    }
}