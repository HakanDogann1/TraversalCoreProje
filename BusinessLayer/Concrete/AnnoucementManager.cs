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
    public class AnnoucementManager : IAnnoucementService
    {
        private readonly IAnnoucementDal _annoucementDal;

        public AnnoucementManager(IAnnoucementDal annoucementDal)
        {
            _annoucementDal = annoucementDal;
        }

        public void TDelete(Announcement entity)
        {
            _annoucementDal.Delete(entity);
        }

        public Announcement TGetByID(int id)
        {
            return _annoucementDal.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return _annoucementDal.GetList();
        }

        public void TInsert(Announcement entity)
        {
            _annoucementDal.Insert(entity);
        }

        public void TUpdate(Announcement entity)
        {
            _annoucementDal.Update(entity);
        }
    }
}
