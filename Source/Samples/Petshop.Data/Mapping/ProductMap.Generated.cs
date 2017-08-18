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
    public partial class ProductMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Petshop.Data.Entities.Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Product> builder)
        {
            // table
            builder.ToTable("Product", "dbo");

            // keys
            builder.HasKey(t => t.ProductId);

            // Properties
            builder.Property(t => t.ProductId)
                .IsRequired()
                .HasColumnName("ProductId")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .ValueGeneratedNever();
            builder.Property(t => t.Category)
                .IsRequired()
                .HasColumnName("Category")
                .HasColumnType("varchar")
                .HasMaxLength(10);
            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            builder.Property(t => t.Descn)
                .HasColumnName("Descn")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            // Relationships
            builder.HasOne(t => t.Category1)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__Product__Categor__3C69FB99");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Product> builder);

    }
}