using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
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
        public Destination GetDestinationWithGuide(int id)
        {
           using var context = new Context();
            return context.Destinations.Where(x=>x.DestinationID==id).Include(x=>x.Guide).SingleOrDefault();
        }

        public List<Destination> GetLast4Destination()
        {
            using var context = new Context();
            return context.Destinations.OrderByDescending(x=>x.DestinationID).Take(4).ToList();
        }

        public List<Destination> GetListByFilter(Expression<Func<Destination, bool>> filter)
        {
            using var context = new Context();
            var values = context.Set<Destination>().Where(filter).ToList();
            return values;
        }
    }
}
