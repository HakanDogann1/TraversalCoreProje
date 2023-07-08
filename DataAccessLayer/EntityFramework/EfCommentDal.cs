﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetDestinationByID(int id)
        {
            using var context = new Context();
            var values = context.Comments.Where(x=>x.DestinationID == id).ToList();
            return values;
        }

        public List<Comment> GetDestinationWithComment()
        {
           using var context = new Context();
            return context.Comments.Include(x=>x.Destination).ToList();
        }
    }
}
