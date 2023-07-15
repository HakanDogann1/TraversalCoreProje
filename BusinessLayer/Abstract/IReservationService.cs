using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        List<Reservation> TGetByFilter(Expression<Func<Reservation, bool>> filter);
        List<Reservation> TGetByApprovedReservation(int id);
        void TApprove(int id);
        void TCancel(int id);
    }
}
