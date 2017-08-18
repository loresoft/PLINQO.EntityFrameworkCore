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
    public partial class RoleMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Tracker.Data.Entities.Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tracker.Data.Entities.Role> builder)
        {
            // table
            builder.ToTable("Role", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            builder.Property(t => t.Description)
                .HasColumnName("Description")
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

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tracker.Data.Entities.Role> builder);

    }
}
