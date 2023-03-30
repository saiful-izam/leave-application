namespace LeaveApplicationForm.VO
{
    public class LeaveFormVO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public string? EmailManager { get; set; }
        public string? ApprovalStatus { get; set; }

    }
}
