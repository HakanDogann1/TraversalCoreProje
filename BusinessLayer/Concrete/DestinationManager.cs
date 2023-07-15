using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void TDelete(Destination entity)
        {
            _destinationDal.Delete(entity);
        }

        public Destination TGetByID(int id)
        {
           return _destinationDal.GetByID(id);
        }

        public Destination TGetDestinationWithGuide(int id)
        {
            return _destinationDal.GetDestinationWithGuide(id);
        }

        public List<Destination> TGetLast4Destination()
        {
            return _destinationDal.GetLast4Destination();
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public List<Destination> TGetListByFilter(Expression<Func<Destination, bool>> filter)
        {
           return _destinationDal.GetListByFilter(filter);
        }

        public void TInsert(Destination entity)
        {
          _destinationDal.Insert(entity);
        }

        public void TUpdate(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}
