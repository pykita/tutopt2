using System;
using System.Linq;
using Tutopt.Models.Storage;

namespace Tutopt.Storage
{
    public interface IGoodsStorage : IDisposable
    {
        IQueryable<Goods> Goodses();
        void SaveChanges();
        void AddGoods(Goods goods);
        void UpdateGoods(Goods goods);
    }

    public class GoodsStorage : IGoodsStorage
    {
        private EntityStorage m_Storage;
        public GoodsStorage()
        {
            m_Storage = new EntityStorage();
        }
        public void Dispose()
        {
            m_Storage.Dispose();
        }

        public IQueryable<Goods> Goodses()
        {
            return m_Storage.Goods;
        }

        public void SaveChanges()
        {
            m_Storage.SaveChanges();
        }

        public void AddGoods(Goods goods)
        {
            m_Storage.Goods.AddObject(goods);
        }

        public void UpdateGoods(Goods goods)
        {
            m_Storage.Goods.ApplyCurrentValues(goods);
        }
    }
}
