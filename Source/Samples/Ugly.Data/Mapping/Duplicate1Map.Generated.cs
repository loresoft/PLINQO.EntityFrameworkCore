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


namespace Ugly.Data.Mapping
{
    public partial class Duplicate1Map
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Ugly.Data.Entities.Duplicate1>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.Duplicate1> builder)
        {
            // table
            builder.ToTable("Duplicate", "Ugly");

            // keys
            builder.HasKey(t => t.DuplicateID);

            // Properties
            builder.Property(t => t.DuplicateID)
                .IsRequired()
                .HasColumnName("DuplicateID")
                .HasColumnType("int")
                .ValueGeneratedNever();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            // Relationships

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.Duplicate1> builder);

    }
}