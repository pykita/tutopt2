using System.Web.Mvc;
using Tutopt.Models.Goods;
using Tutopt.Service;
using Tutopt.Storage;

namespace Tutopt.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsService m_Service;
        public GoodsController()
        {
            m_Service = new GoodsService(new GoodsStorage());
        }

        public ActionResult Index()
        {
            return View(m_Service.GetGoodsViewModel());
        }

        public ActionResult Edit(int id)
        {
            return View(m_Service.GetGoodsItem(id));
        }

        [HttpPost]
        public ActionResult Edit(GoodsItemViewModel goodsItem)
        {
            m_Service.SaveGoods(goodsItem);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GoodsItemViewModel goodsItem)
        {
            m_Service.SaveGoods(goodsItem);
            return View();
        }
    }
}
