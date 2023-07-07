using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> GetListByFilter(Expression<Func<Destination, bool>> filter)
        {
            using var context = new Context();
            var values = context.Set<Destination>().Where(filter).ToList();
            return values;
        }
    }
}
