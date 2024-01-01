using CRUD.Dto;
using CRUD.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackBiz _biz;
        public FeedbackController(IFeedbackBiz biz)
        {
            _biz = biz;
        }

        [Authorize]
        [HttpPost]
        [Route(("api/[controller]/[action]"))]
        public async Task<IActionResult> AddFeedback(Feedback feedback)
        {
            var feedBack = await _biz.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(AddFeedback), feedBack);
        }
    }
}
