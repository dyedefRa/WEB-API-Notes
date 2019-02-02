using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public interface IRepository<T> where T:class
    {

        IEnumerable<T> GETALL();
        T GET(int id);
        int DELETE(int id);
        int UPDATE(T temp);
        int INSERT(T temp);
        T GetONE(Expression<Func<T, bool>> kosul);
        IQueryable<T> GetMANY(Expression<Func<T, bool>> kosul);
        int SAVE();


    }
}
