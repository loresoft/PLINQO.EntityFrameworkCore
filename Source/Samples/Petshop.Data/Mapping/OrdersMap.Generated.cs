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
    public partial class OrdersMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Petshop.Data.Entities.Orders>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Orders> builder)
        {
            // table
            builder.ToTable("Orders", "dbo");

            // keys
            builder.HasKey(t => t.OrderId);

            // Properties
            builder.Property(t => t.OrderId)
                .IsRequired()
                .HasColumnName("OrderId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.OrderDate)
                .IsRequired()
                .HasColumnName("OrderDate")
                .HasColumnType("datetime");
            builder.Property(t => t.ShipAddr1)
                .IsRequired()
                .HasColumnName("ShipAddr1")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.ShipAddr2)
                .HasColumnName("ShipAddr2")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.ShipCity)
                .IsRequired()
                .HasColumnName("ShipCity")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.ShipState)
                .IsRequired()
                .HasColumnName("ShipState")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.ShipZip)
                .IsRequired()
                .HasColumnName("ShipZip")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.ShipCountry)
                .IsRequired()
                .HasColumnName("ShipCountry")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.BillAddr1)
                .IsRequired()
                .HasColumnName("BillAddr1")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.BillAddr2)
                .HasColumnName("BillAddr2")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.BillCity)
                .IsRequired()
                .HasColumnName("BillCity")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.BillState)
                .IsRequired()
                .HasColumnName("BillState")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.BillZip)
                .IsRequired()
                .HasColumnName("BillZip")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.BillCountry)
                .IsRequired()
                .HasColumnName("BillCountry")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.Courier)
                .IsRequired()
                .HasColumnName("Courier")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.TotalPrice)
                .IsRequired()
                .HasColumnName("TotalPrice")
                .HasColumnType("decimal");
            builder.Property(t => t.BillToFirstName)
                .IsRequired()
                .HasColumnName("BillToFirstName")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.BillToLastName)
                .IsRequired()
                .HasColumnName("BillToLastName")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.ShipToFirstName)
                .IsRequired()
                .HasColumnName("ShipToFirstName")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.ShipToLastName)
                .IsRequired()
                .HasColumnName("ShipToLastName")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.CreditCard)
                .IsRequired()
                .HasColumnName("CreditCard")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            builder.Property(t => t.ExprDate)
                .IsRequired()
                .HasColumnName("ExprDate")
                .HasColumnType("varchar")
                .HasMaxLength(7);
            builder.Property(t => t.CardType)
                .IsRequired()
                .HasColumnName("CardType")
                .HasColumnType("varchar")
                .HasMaxLength(40);
            builder.Property(t => t.Locale)
                .IsRequired()
                .HasColumnName("Locale")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            // Relationships

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Orders> builder);

    }
}