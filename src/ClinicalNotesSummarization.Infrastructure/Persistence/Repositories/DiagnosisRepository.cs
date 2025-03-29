using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicalNotesSummarization.Infrastructure.Persistence.Repositories
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly ClinicalNotesDbContext _context;

        public DiagnosisRepository(ClinicalNotesDbContext context) =>
            _context = context;

        public async Task<Guid> AddAsync(Diagnosis medication)
        {
            await _context.Diagnoses.AddAsync(medication);
            await _context.SaveChangesAsync();
            return medication.Id;
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var medication = await _context.Diagnoses.FindAsync(Id);
            _context.Diagnoses.Remove(medication!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Diagnosis>> GetAllAsync() =>
            await _context.Diagnoses.ToListAsync();

        public async Task<Diagnosis?> GetByIdAsync(Guid Id) =>
             await _context.Diagnoses.FindAsync(Id);

        public async Task<List<Diagnosis>> GetByPatientIdAsync(Guid patientId) =>
            await _context.Diagnoses.Where(_ => _.PatientId == patientId).ToListAsync();

        public async Task UpdateAsync(Diagnosis medication)
        {
            _context.Diagnoses.Update(medication);
            await _context.SaveChangesAsync();
        }
    }
}
