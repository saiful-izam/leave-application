namespace LeaveApplicationForm.Models
{
    public class LeaveFormViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public string? EmailManager { get; set; }
    }
}
