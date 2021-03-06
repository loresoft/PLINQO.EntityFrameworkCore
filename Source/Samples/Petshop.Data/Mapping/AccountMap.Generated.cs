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


namespace Petshop.Data.Mapping
{
    public partial class AccountMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Petshop.Data.Entities.Account>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Account> builder)
        {
            // table
            builder.ToTable("Account", "dbo");

            // keys
            builder.HasKey(t => t.UserId);

            // Properties
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .ValueGeneratedNever();
            builder.Property(t => t.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .HasColumnType("varchar")
                .HasMaxLength(2);
            builder.Property(t => t.Address1)
                .IsRequired()
                .HasColumnName("Addr1")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.Address2)
                .HasColumnName("Addr2")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.State)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.Zip)
                .IsRequired()
                .HasColumnName("Zip")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.Country)
                .IsRequired()
                .HasColumnName("Country")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.Phone)
                .IsRequired()
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            // Relationships

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Account> builder);

    }
}
