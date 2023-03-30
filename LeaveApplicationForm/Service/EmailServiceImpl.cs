using LeaveApplicationForm.DAL;
using MailKit.Net.Smtp;
using MimeKit;

namespace LeaveApplicationForm.Service
{
    public class EmailServiceImpl : IEmailService
    {
        private readonly string emailAdmin = "leaveemployeetest01@gmail.com";
        private readonly string pwd = @"vohuokvugnijgorn";
        private string approvalEmailTemplate = @"Dear Manager,
                                                 There is one leave application that requires your approval.
                                                 Please click link below to approve or reject the application:
                                                  <urlApproval>";

        private string successEmailTemplate = @"Dear Employee,
                                               Your leave application has been approved.";

        private string rejectEmailTemplate = @"Dear Employee,
                                               Your leave application has been rejected.";

        private readonly AppDBContext _dbContext;

        public EmailServiceImpl(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async void SendEmailApproval(string leaveId, string rootUrl, string receiver)
        {
            var emailTemplate = approvalEmailTemplate.Replace("<urlApproval>", rootUrl + "/Leave/Approval/" + leaveId);

            SendEmail(receiver, "Leave Approval Notification" ,emailTemplate);
        }

        public async void SendEmailApproved(string receiver)
        {
            SendEmail(receiver, "Leave Approval Notification", successEmailTemplate);
        }

        public void SendEmailRejected(string receiver)
        {
            SendEmail(receiver, "Leave Approval Notification", rejectEmailTemplate);
        }

        private async void SendEmail( string receiver, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            
            message.From.Add(new MailboxAddress("employeeTest", emailAdmin));

            message.To.Add(MailboxAddress.Parse(receiver));

            message.Subject = subject;

            message.Body = new TextPart("plain") { Text = body };

            SmtpClient smtpClient = new SmtpClient();
            
            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);

                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Authenticate(emailAdmin, pwd);

                smtpClient.Send(message);

            }catch (Exception ex)
            {
                throw;
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
