using ClinicalNotesSummarization.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicalNotesSummarization.Infrastructure.Persistence
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(255);

            // Relationships
            builder.HasMany(p => p.ClinicalNotes)
                   .WithOne(n => n.Patient)
                   .HasForeignKey(n => n.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Allergies)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
