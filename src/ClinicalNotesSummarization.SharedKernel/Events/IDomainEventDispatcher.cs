namespace ClinicalNotesSummarization.SharedKernel.Events
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IDomainEvent domainEvent);
        Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents);
    }
}
