namespace ClinicalNotesSummarization.SharedKernel.Events;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}

