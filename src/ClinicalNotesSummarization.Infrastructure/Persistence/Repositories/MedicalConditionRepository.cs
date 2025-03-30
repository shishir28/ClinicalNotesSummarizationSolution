using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicalNotesSummarization.Infrastructure.Persistence.Repositories
{
    public class MedicalConditionRepository : IMedicalConditionRepository
    {
        private readonly ClinicalNotesDbContext _context;

        public MedicalConditionRepository(ClinicalNotesDbContext context) =>
            _context = context;

        public async Task<Guid> AddAsync(MedicalCondition medication)
        {
            await _context.MedicalConditions.AddAsync(medication);
            await _context.SaveChangesAsync();
            return medication.Id;
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var medication = await _context.MedicalConditions.FindAsync(Id);
            _context.MedicalConditions.Remove(medication!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicalCondition>> GetAllAsync() =>
            await _context.MedicalConditions.ToListAsync();

        public async Task<MedicalCondition?> GetByIdAsync(Guid Id) =>
             await _context.MedicalConditions.FindAsync(Id);

        public async Task<List<MedicalCondition>> GetByPatientIdAsync(Guid patientId) =>
            await _context.MedicalConditions.Where(_ => _.PatientId == patientId).ToListAsync();

        public async Task UpdateAsync(MedicalCondition medication)
        {
            _context.MedicalConditions.Update(medication);
            await _context.SaveChangesAsync();
        }
    }
}
