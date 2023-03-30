namespace LeaveApplicationForm.Service
{
    public interface IEmailService
    {
        void SendEmailApproval(string leaveId, string rootUrl, string receiver);
        void SendEmailApproved(string receiver);
        void SendEmailRejected(string receiver);
    }
}
