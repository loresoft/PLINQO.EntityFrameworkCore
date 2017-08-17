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
    public partial class UserMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Tracker.Data.Entities.User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tracker.Data.Entities.User> builder)
        {
            // table
            builder.ToTable("User", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
            builder.Property(t => t.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar")
                .HasMaxLength(200);
            builder.Property(t => t.LastName)
                .HasColumnName("LastName")
                .HasColumnType("nvarchar")
                .HasMaxLength(200);
            builder.Property(t => t.Avatar)
                .HasColumnName("Avatar")
                .HasColumnType("varbinary");
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
            builder.Property(t => t.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("char")
                .HasMaxLength(86)
                .HasDefaultValueSql("('')");
            builder.Property(t => t.PasswordSalt)
                .IsRequired()
                .HasColumnName("PasswordSalt")
                .HasColumnType("char")
                .HasMaxLength(5)
                .HasDefaultValueSql("('')");
            builder.Property(t => t.Comment)
                .HasColumnName("Comment")
                .HasColumnType("text");
            builder.Property(t => t.IsApproved)
                .IsRequired()
                .HasColumnName("IsApproved")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");
            builder.Property(t => t.LastLoginDate)
                .HasColumnName("LastLoginDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(t => t.LastActivityDate)
                .IsRequired()
                .HasColumnName("LastActivityDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(t => t.LastPasswordChangeDate)
                .HasColumnName("LastPasswordChangeDate")
                .HasColumnType("datetime");
            builder.Property(t => t.AvatarType)
                .HasColumnName("AvatarType")
                .HasColumnType("nvarchar")
                .HasMaxLength(150);

            // Relationships

            InitializeMapping(builder);
        }
    }
}
