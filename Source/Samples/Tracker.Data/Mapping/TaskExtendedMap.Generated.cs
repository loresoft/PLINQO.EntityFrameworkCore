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
    public partial class TaskExtendedMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Tracker.Data.Entities.TaskExtended>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tracker.Data.Entities.TaskExtended> builder)
        {
            // table
            builder.ToTable("TaskExtended", "dbo");

            // keys
            builder.HasKey(t => t.TaskId);

            // Properties
            builder.Property(t => t.TaskId)
                .IsRequired()
                .HasColumnName("TaskId")
                .HasColumnType("int")
                .ValueGeneratedNever();
            builder.Property(t => t.Browser)
                .HasColumnName("Browser")
                .HasColumnType("nvarchar")
                .HasMaxLength(200);
            builder.Property(t => t.Os)
                .HasColumnName("OS")
                .HasColumnType("nvarchar")
                .HasMaxLength(150);
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

            // Relationships
            builder.HasOne(t => t.Task)
                .WithOne(t => t.TaskExtended)
                .HasForeignKey<Tracker.Data.Entities.TaskExtended>(d => d.TaskId)
                .HasConstraintName("FK_TaskExtended_Task");

            InitializeMapping(builder);
        }
    }
}
