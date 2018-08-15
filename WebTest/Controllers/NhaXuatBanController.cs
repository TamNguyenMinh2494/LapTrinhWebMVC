using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;
namespace WebTest.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public PartialViewResult NhaXuatBanPartial()
        {
            //Lấy 4 NXB từ Database và sort theo tên NXB
            return PartialView(db.NhaXuatBans.Take(4).OrderBy(n => n.TenNXB).ToList());
        }
        //hiển thị sách theo NXB
        public ViewResult SachTheoNXB(int MaNXB=0)
        {
            //kiểm tra nhà xuất bản có tồn tại?
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //truy xuất các quyển sách theo nhà xuất bản
            List<Sach> sach = db.Saches.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if (sach.Count == 0)
            {
                ViewBag.sach = "Không có sách gì trong chủ đề này";
            }
            return View(sach);
        }
    }
}