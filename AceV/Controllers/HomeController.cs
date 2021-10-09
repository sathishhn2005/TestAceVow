using Utility;
using BussLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;

namespace AceV.Controllers
{
    public class HomeController : Controller
    {
        string source = string.Empty;
        DealsModel objBAL;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult PreviewFlyer(int id)
        {
            int t = 31;
            List<PreviewDeals> model = new List<PreviewDeals>();

            objBAL = new DealsModel();
            objBAL.GetFlyerPreview(t, id, out model);
            foreach (var item in model)
            {
                using (Image image = Image.FromFile(Server.MapPath("~/ProductImages/" + item.image)))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        item.image = base64String;
                        // return base64String;
                    }
                }
            }
            CalcPrice(model);
            if (Session["Flyer"] != null)
            {
                model = (List<PreviewDeals>)Session["Flyer"];
            }
            return View(model);
        }
        private void CalcPrice(List<PreviewDeals> lstModel)
        {
            if (lstModel != null)
            {
                if (lstModel.Count > 0)
                {
                    foreach (var item in lstModel)
                    {
                        if (!item.OfferPrice.Equals(0))
                        {
                            item.SavingPrice = Convert.ToDecimal(item.RegularPrice - item.OfferPrice);
                            item.SavingPercentage = Convert.ToInt32(item.SavingPrice / item.RegularPrice * 100);
                            item.Price = item.OfferPrice;
                        }
                        else
                        {
                            item.Price = Convert.ToDecimal(item.RegularPrice);
                        }
                    }
                }
            }
        }
    }
}