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
    public partial class QueryMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Ugly.Data.Entities.Query>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.Query> builder)
        {
            // table
            builder.ToTable("Query", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedNever();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            builder.Property(t => t.QueryMember)
                .HasColumnName("Query")
                .HasColumnType("nvarchar");

            // Relationships

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.Query> builder);

    }
}
