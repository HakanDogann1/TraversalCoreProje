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
    public class NewsletterManager : INewsletterService
    {
        private readonly INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void TDelete(Newsletter entity)
        {
            _newsletterDal.Delete(entity);
        }

        public Newsletter TGetByID(int id)
        {
            return _newsletterDal.GetByID(id);
        }

        public List<Newsletter> TGetList()
        {
            return _newsletterDal.GetList();
        }

        public void TInsert(Newsletter entity)
        {
            _newsletterDal.Insert(entity);
        }

        public void TUpdate(Newsletter entity)
        {
           _newsletterDal.Update(entity);
        }
    }
}
