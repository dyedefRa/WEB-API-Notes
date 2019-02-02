using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.DAL
{
   public interface IRepository<TT> where TT:class
    {

        List<TT> Listele();
        TT GetByID(int id);
        int Sil( int id);
        TT Guncelle(TT temp);
        TT Ekle(TT temp);
      


    }
}
