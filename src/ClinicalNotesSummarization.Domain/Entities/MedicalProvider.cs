using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class MedicalProvider : BaseEntity
    {
        public string Name { get; private set; }
        public string Specialty { get; private set; }
        public string LicenseNumber { get; private set; }

        private MedicalProvider() { } // For EF Core

        public MedicalProvider(string name, string specialty, string licenseNumber)
        {
            Name = name;
            Specialty = specialty;
            LicenseNumber = licenseNumber;
        }
    }
}
