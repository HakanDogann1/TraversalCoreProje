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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TDelete(Guide entity)
        {
           _guideDal.Delete(entity);
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public void TInsert(Guide entity)
        {
           _guideDal.Insert(entity);
        }

        public void TUpdate(Guide entity)
        {
            _guideDal.Update(entity);
        }
    }
}
