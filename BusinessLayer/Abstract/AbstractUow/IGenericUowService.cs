using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUow
{
    public interface IGenericUowService<T> where T : class
    {
        T TGetById(int id);
        void TInsert(T entity);
        void TUpdate(T entity);
        void TMultiUpdate(List<T> entity);
    }
}
