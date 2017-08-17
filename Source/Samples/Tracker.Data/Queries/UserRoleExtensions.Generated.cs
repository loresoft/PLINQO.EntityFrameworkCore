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
    public static partial class UserRoleExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static Tracker.Data.Entities.UserRole GetByKey(this System.Linq.IQueryable<Tracker.Data.Entities.UserRole> queryable, int userId, int roleId)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<Tracker.Data.Entities.UserRole>;
            if (dbSet != null)
                return dbSet.Find(userId, roleId);

            return queryable.FirstOrDefault(u => u.UserId == userId
                && u.RoleId == roleId);
        }

        public static IQueryable<Tracker.Data.Entities.UserRole> ByUserId(this IQueryable<Tracker.Data.Entities.UserRole> queryable, int userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }

        public static IQueryable<Tracker.Data.Entities.UserRole> ByRoleId(this IQueryable<Tracker.Data.Entities.UserRole> queryable, int roleId)
        {
            return queryable.Where(u => u.RoleId == roleId);
        }
    }
}
