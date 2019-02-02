using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CTXContext ctx = new CTXContext();
        private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = ctx.Set<T>();
        }
        public T Ekle(T temp)
        {
            _objectSet.Add(temp);
          return  temp;
        }

        public T GetByID(int id)
        {
            return _objectSet.Find(id);
        }

        public T Guncelle(T temp)
        {
            ctx.SaveChanges();
            return temp;
        }

        public List<T> Listele()
        {
            return _objectSet.ToList();
        }

        public int Sil(int id)
        {

            _objectSet.Remove(GetByID(id));
            return KAYDET();
        }
        public int KAYDET()
        {
            return ctx.SaveChanges();
        }

           }
}
