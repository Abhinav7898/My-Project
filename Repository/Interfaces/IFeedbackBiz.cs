using CRUD.Dto;

namespace CRUD.Repository.Interfaces
{
    public interface IFeedbackBiz
    {
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
    }
}
