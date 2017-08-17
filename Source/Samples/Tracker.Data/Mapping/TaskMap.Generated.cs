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
using Microsoft.EntityFrameworkCore;


namespace Tracker.Data.Mapping
{
    public partial class TaskMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Tracker.Data.Entities.Task>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tracker.Data.Entities.Task> builder)
        {
            // table
            builder.ToTable("Task", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.StatusId)
                .IsRequired()
                .HasColumnName("StatusId")
                .HasColumnType("int");
            builder.Property(t => t.PriorityId)
                .HasColumnName("PriorityId")
                .HasColumnType("int");
            builder.Property(t => t.CreatedId)
                .IsRequired()
                .HasColumnName("CreatedId")
                .HasColumnType("int");
            builder.Property(t => t.Summary)
                .IsRequired()
                .HasColumnName("Summary")
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            builder.Property(t => t.Details)
                .HasColumnName("Details")
                .HasColumnType("nvarchar")
                .HasMaxLength(2000);
            builder.Property(t => t.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime");
            builder.Property(t => t.DueDate)
                .HasColumnName("DueDate")
                .HasColumnType("datetime");
            builder.Property(t => t.CompleteDate)
                .HasColumnName("CompleteDate")
                .HasColumnType("datetime");
            builder.Property(t => t.AssignedId)
                .HasColumnName("AssignedId")
                .HasColumnType("int");
            builder.Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(t => t.ModifiedDate)
                .IsRequired()
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(t => t.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("RowVersion")
                .HasColumnType("timestamp")
                .HasMaxLength(8)
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(t => t.LastModifiedBy)
                .HasColumnName("LastModifiedBy")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            // Relationships
            builder.HasOne(t => t.Priority)
                .WithMany(t => t.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK_Task_Priority");
            builder.HasOne(t => t.Status)
                .WithMany(t => t.Tasks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Task_Status");
            builder.HasOne(t => t.AssignedUser)
                .WithMany(t => t.AssignedTasks)
                .HasForeignKey(d => d.AssignedId)
                .HasConstraintName("FK_Task_User_Assigned");
            builder.HasOne(t => t.CreatedUser)
                .WithMany(t => t.CreatedTasks)
                .HasForeignKey(d => d.CreatedId)
                .HasConstraintName("FK_Task_User_Created");

            InitializeMapping(builder);
        }
    }
}
