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
    public static partial class SqlTypesExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static Ugly.Data.Entities.SqlTypes GetByKey(this System.Linq.IQueryable<Ugly.Data.Entities.SqlTypes> queryable, int id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<Ugly.Data.Entities.SqlTypes>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(s => s.Id == id);
        }
    }
}
