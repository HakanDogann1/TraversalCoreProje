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
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetByApprovedReservation(int id)
        {
            using var context = new Context();
            return context.Reservations.Include(y=>y.AppUser).Where(x=>x.AppUserID == id && x.Status== "Onay Bekliyor...").ToList();
        }

        public List<Reservation> GetByFilter(Expression<Func<Reservation, bool>> filter)
        {
           using var context =new Context();
            return context.Reservations.Where(filter).ToList();
        }
    }
}
