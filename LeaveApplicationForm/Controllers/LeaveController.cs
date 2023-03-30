using LeaveApplicationForm.DAL;
using LeaveApplicationForm.Models;
using LeaveApplicationForm.Service;
using LeaveApplicationForm.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveApplicationForm.Controllers
{
    public class LeaveController : Controller
    {
        private readonly AppDBContext _dbContext;
        private readonly IEmailService _emailService;

        public LeaveController(AppDBContext dBContext, IEmailService emailService)
        {
            _dbContext = dBContext;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Approval(String id)
        {
            var leave = _dbContext.LeaveForms
                .Where(x => x.Id == new Guid(id))
                .FirstOrDefault();

            var leaveFormViewModel = new LeaveFormViewModel()
            {
                Name = leave?.Name,
                Email = leave?.Email,
                EmailManager = leave?.EmailManager,
                EndDate = leave!.EndDate,
                Reason = leave?.Reason,
                StartDate = leave!.StartDate,
            };

            ViewData["Id"] = leave.Id;

            return View(leaveFormViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LeaveFormViewModel leaveRequest)
        {
            LeaveFormVO leave = new LeaveFormVO()
            {
                Id = Guid.NewGuid(),
                Name = leaveRequest.Name,
                Email = leaveRequest.Email,
                EmailManager = leaveRequest.EmailManager,
                EndDate = leaveRequest.EndDate,
                Reason = leaveRequest.Reason,
                StartDate = leaveRequest.StartDate,
                ApprovalStatus = "Pending Approval"
            };

            await _dbContext.LeaveForms.AddAsync(leave);
            await _dbContext.SaveChangesAsync();

            var uri = new Uri($"{Request.Scheme}://{Request.Host}");
            string appRootUrl = uri.AbsoluteUri;

            _emailService.SendEmailApproval(leave.Id.ToString(), appRootUrl, leave.EmailManager);

            TempData["successMessage"] = "Your Application has been submitted for approval.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Approve(String id)
        {

            var leave = await _dbContext.LeaveForms.
                Where(x => x.Id == new Guid(id))
                .FirstAsync();

            leave.ApprovalStatus = "Approved";

            await _dbContext.SaveChangesAsync();

            _emailService.SendEmailApproved(leave.Email);

            TempData["successMessage"] = "Your Approval has been successfully submitted";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Reject(String id)
        {
            var leave = await _dbContext.LeaveForms
                .Where(x => x.Id == new Guid(id))
                .FirstAsync();

            leave.ApprovalStatus = "Rejected";

            await _dbContext.SaveChangesAsync();

            _emailService.SendEmailRejected(leave.Email);

            TempData["successMessage"] = "Your Approval has been successfully submitted";
            return RedirectToAction("Index");
        }
    }
}
