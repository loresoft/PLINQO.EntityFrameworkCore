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

namespace Tracker.Data.Queries
{
    public static partial class StatusExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static Tracker.Data.Entities.Status GetByKey(this System.Linq.IQueryable<Tracker.Data.Entities.Status> queryable, int id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<Tracker.Data.Entities.Status>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(s => s.Id == id);
        }
    }
}
