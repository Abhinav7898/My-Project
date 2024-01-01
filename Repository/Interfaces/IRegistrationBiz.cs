using CRUD.Dto;

namespace CRUD.Repository.Interfaces
{
    public interface IRegistrationBiz
    {
        Task<Registration> AddUserAsync(Registration registration);
        List<Registration> GetUserList();
        (bool,  Registration) ValidateUser(string email, string password);
    }
}
