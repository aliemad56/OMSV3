using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSV1.Domain.Entities.Attachments;

namespace OMSV1.Infrastructure.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<AttachmentCU>
{
 public void Configure(EntityTypeBuilder<AttachmentCU> builder)
    {
        // Primary Key
        builder.HasKey(a => a.Id);

        // Properties
        builder.Property(a => a.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.FilePath)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.EntityType)
            .IsRequired()
            .HasConversion<string>(); // Store as string in the database

        builder.Property(a => a.EntityId)
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        // Table Mapping
        builder.ToTable("AttachmentCUs");
    }
}