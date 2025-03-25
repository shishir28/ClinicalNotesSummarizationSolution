using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicalNotesSummarization.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicalNotesDbContext _context;

        public PatientRepository(ClinicalNotesDbContext context) =>
            _context = context;

        public async Task<Patient?> GetByIdAsync(Guid Id) =>
             await _context.Patients.FindAsync(Id);

        public async Task<List<Patient>> GetAllAsync() =>
             await _context.Patients.ToListAsync();

        public async Task<Guid> AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient.Id;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var patient = await _context.Patients.FindAsync(Id);
            _context.Patients.Remove(patient!);
            await _context.SaveChangesAsync();
        }
    }
}
