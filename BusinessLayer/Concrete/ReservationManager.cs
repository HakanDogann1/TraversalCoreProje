using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TApprove(int id)
        {
            _reservationDal.Approve(id);
        }

        public void TCancel(int id)
        {
            _reservationDal.Cancel(id);
        }

        public void TDelete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public List<Reservation> TGetByApprovedReservation(int id)
        {
            return _reservationDal.GetByApprovedReservation(id);
        }

        public List<Reservation> TGetByFilter(System.Linq.Expressions.Expression<Func<Reservation, bool>> filter)
        {
           return _reservationDal.GetByFilter(filter);
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public void TInsert(Reservation entity)
        {
            _reservationDal.Insert(entity);
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
