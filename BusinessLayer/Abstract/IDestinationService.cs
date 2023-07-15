using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        List<Destination> TGetListByFilter(Expression<Func<Destination, bool>> filter);
       Destination TGetDestinationWithGuide(int id);
        List<Destination> TGetLast4Destination();
    }
}
