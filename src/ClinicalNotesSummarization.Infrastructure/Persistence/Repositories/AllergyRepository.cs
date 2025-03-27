using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicalNotesSummarization.Infrastructure.Persistence.Repositories
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly ClinicalNotesDbContext _context;

        public AllergyRepository(ClinicalNotesDbContext context) =>
            _context = context;

        public async Task<Guid> AddAsync(Allergy allergy)
        {
            await _context.Allergies.AddAsync(allergy);
            await _context.SaveChangesAsync();
            return allergy.Id;
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var allergy = await _context.Allergies.FindAsync(Id);
            _context.Allergies.Remove(allergy!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Allergy>> GetAllAsync() =>
            await _context.Allergies.ToListAsync();

        public async Task<Allergy?> GetByIdAsync(Guid Id) =>
             await _context.Allergies.FindAsync(Id);

        public async Task<List<Allergy>> GetByPatientIdAsync(Guid patientId) =>
            await _context.Allergies.Where(_ => _.PatientId == patientId).ToListAsync();

        public async Task UpdateAsync(Allergy allergy)
        {
            _context.Allergies.Update(allergy);
            await _context.SaveChangesAsync();
        }
    }
}
