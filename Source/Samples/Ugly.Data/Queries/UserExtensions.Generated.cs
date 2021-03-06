﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ugly.Data.Queries
{
    public static partial class UserExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static Ugly.Data.Entities.User GetByKey(this System.Linq.IQueryable<Ugly.Data.Entities.User> queryable, int id, string userName)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<Ugly.Data.Entities.User>;
            if (dbSet != null)
                return dbSet.Find(id, userName);

            return queryable.FirstOrDefault(u => u.Id == id
                && u.UserName == userName);
        }
    }
}
