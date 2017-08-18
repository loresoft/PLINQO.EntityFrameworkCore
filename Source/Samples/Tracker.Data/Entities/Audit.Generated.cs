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
    public partial class Audit
    {
        public Audit()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public int? TaskId { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}