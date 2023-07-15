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
        public void Approve(int id)
        {
           using var context = new Context();
            var value = context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            value.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void Cancel(int id)
        {
            using var context = new Context();
            var value = context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            value.Status = "İptal Edildi";
            context.SaveChanges();
        }

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
