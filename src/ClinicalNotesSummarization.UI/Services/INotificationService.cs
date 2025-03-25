using ClinicalNotesSummarization.UI.Models;
using MudBlazor;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface INotificationService
    {
        Task Success(string message);
        Task Warning(string message);
        Task Error(string message);
    }

    public class NotificationService : INotificationService
    {
        private readonly ISnackbar _snackbar;

        public NotificationService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public Task Success(string message)
        {
            _snackbar.Add(message, Severity.Success);
            return Task.CompletedTask;
        }

        public Task Warning(string message)
        {
            _snackbar.Add(message, Severity.Warning);
            return Task.CompletedTask;
        }

        public Task Error(string message)
        {
            _snackbar.Add(message, Severity.Error);
            return Task.CompletedTask;
        }
    }   
}
