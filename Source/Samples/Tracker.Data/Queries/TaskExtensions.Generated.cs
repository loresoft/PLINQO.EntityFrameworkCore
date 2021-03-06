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
    public static partial class TaskExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static Tracker.Data.Entities.Task GetByKey(this System.Linq.IQueryable<Tracker.Data.Entities.Task> queryable, int id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<Tracker.Data.Entities.Task>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(t => t.Id == id);
        }

        public static IQueryable<Tracker.Data.Entities.Task> ByAssignedIdStatusId(this IQueryable<Tracker.Data.Entities.Task> queryable, int? assignedId, int statusId)
        {
            return queryable.Where(t => (t.AssignedId == assignedId || (assignedId == null && t.AssignedId == null))
                && t.StatusId == statusId);
        }

        public static IQueryable<Tracker.Data.Entities.Task> ByStatusId(this IQueryable<Tracker.Data.Entities.Task> queryable, int statusId)
        {
            return queryable.Where(t => t.StatusId == statusId);
        }

        public static IQueryable<Tracker.Data.Entities.Task> ByPriorityId(this IQueryable<Tracker.Data.Entities.Task> queryable, int? priorityId)
        {
            return queryable.Where(t => (t.PriorityId == priorityId || (priorityId == null && t.PriorityId == null)));
        }

        public static IQueryable<Tracker.Data.Entities.Task> ByCreatedId(this IQueryable<Tracker.Data.Entities.Task> queryable, int createdId)
        {
            return queryable.Where(t => t.CreatedId == createdId);
        }

        public static IQueryable<Tracker.Data.Entities.Task> ByAssignedId(this IQueryable<Tracker.Data.Entities.Task> queryable, int? assignedId)
        {
            return queryable.Where(t => (t.AssignedId == assignedId || (assignedId == null && t.AssignedId == null)));
        }
    }
}
