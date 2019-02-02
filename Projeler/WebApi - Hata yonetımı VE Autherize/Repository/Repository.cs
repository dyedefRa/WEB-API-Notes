using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Programming.DAL;

namespace Repository
{
    public class Repository<TT> : IRepository<TT> where TT : class
    {
        private readonly ProgrammingDB ctx=new ProgrammingDB();
        private DbSet<TT> objectSet;

            public Repository()
        {
         objectSet= ctx.Set<TT>();
        }

        public int DELETE(int id)
        {

            var model = GET(id);
            objectSet.Remove(model);
            return SAVE();
        }

        

        public TT GET(int id)
        {
            return objectSet.Find(id);
        }

      

        public IEnumerable<TT> GETALL()
        {
            return objectSet.Select(x=>x);
        }

      
        public IQueryable<TT> GetMANY(Expression<Func<TT, bool>> kosul)
        {
            return objectSet.Where(kosul);
        }

        public TT GetONE(Expression<Func<TT, bool>> kosul)
        {
            return objectSet.FirstOrDefault(kosul);
        }

        public int INSERT(TT temp)
        {
            objectSet.Add(temp);
            return SAVE();
        }

        public int SAVE()
        {
            return ctx.SaveChanges();
        }

        public int UPDATE(TT temp)
        {
            objectSet.AddOrUpdate(temp);
            return SAVE();
        }

      
    }
}
