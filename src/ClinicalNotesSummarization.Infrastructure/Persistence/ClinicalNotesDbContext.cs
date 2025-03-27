using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ClinicalNotesSummarization.Infrastructure.Persistence
{
    public class ClinicalNotesDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public ClinicalNotesDbContext(DbContextOptions<ClinicalNotesDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<ClinicalNote> ClinicalNotes { get; set; }
        public DbSet<MedicalProvider> MedicalProviders { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Medication> Medications { get; set; }

        public DbSet<Allergy> Allergies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Gender)
                      .HasConversion(
                          v => v.ToString(),
                          v => (Gender)Enum.Parse(typeof(Gender), v))
                      .HasColumnType("text");
            });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicalNotesDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var property in ChangeTracker.Entries<BaseEntity>().SelectMany(be=> be.Properties))
            {
                    if (property.CurrentValue is DateTimeOffset dto)
                        property.CurrentValue = dto.ToUniversalTime();
            }

            var domainEvents = ChangeTracker.Entries<BaseEntity>()
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent, cancellationToken);

            return result;
        }
    }
}
