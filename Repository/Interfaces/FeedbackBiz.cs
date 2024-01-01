using CRUD.Dal;
using CRUD.Dto;

namespace CRUD.Repository.Interfaces
{
    public class FeedbackBiz : IFeedbackBiz
    {
        private readonly CRUDDalBase _db;
        public FeedbackBiz(CRUDDalBase db)
        {
            _db = db;
        }
        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            var feedBack = await _db.Feedbacks.AddAsync(feedback);
            await _db.SaveChangesAsync();
            return feedback;
        }
    }
}
