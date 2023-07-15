﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {
        List<Destination> GetListByFilter(Expression<Func<Destination, bool>> filter);
        Destination GetDestinationWithGuide(int id);
        List<Destination> GetLast4Destination();
    }
}
