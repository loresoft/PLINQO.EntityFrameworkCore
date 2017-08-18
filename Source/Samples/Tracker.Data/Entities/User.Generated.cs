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
using System.Text;

namespace Tracker.Data.Entities
{
    public partial class User
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            PasswordHash = "";
            PasswordSalt = "";
            IsApproved = true;
            LastLoginDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
            Audits = new HashSet<Audit>();
            AssignedTasks = new HashSet<Task>();
            CreatedTasks = new HashSet<Task>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Byte[] Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Byte[] RowVersion { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public string AvatarType { get; set; }

        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<Task> AssignedTasks { get; set; }
        public virtual ICollection<Task> CreatedTasks { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}