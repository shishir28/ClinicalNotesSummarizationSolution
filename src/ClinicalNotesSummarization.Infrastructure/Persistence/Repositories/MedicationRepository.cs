using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicalNotesSummarization.Infrastructure.Persistence.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly ClinicalNotesDbContext _context;

        public MedicationRepository(ClinicalNotesDbContext context) =>
            _context = context;

        public async Task<Guid> AddAsync(Medication medication)
        {
            await _context.Medications.AddAsync(medication);
            await _context.SaveChangesAsync();
            return medication.Id;
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var medication = await _context.Medications.FindAsync(Id);
            _context.Medications.Remove(medication!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Medication>> GetAllAsync() =>
            await _context.Medications.ToListAsync();

        public async Task<Medication?> GetByIdAsync(Guid Id) =>
             await _context.Medications.FindAsync(Id);

        public async Task<List<Medication>> GetByPatientIdAsync(Guid patientId) =>
            await _context.Medications.Where(_ => _.PatientId == patientId).ToListAsync();

        public async Task UpdateAsync(Medication medication)
        {
            _context.Medications.Update(medication);
            await _context.SaveChangesAsync();
        }
    }
}
