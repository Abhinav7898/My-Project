using CRUD.Dal;
using CRUD.Dto;
using CRUD.Repository.Interfaces;

namespace CRUD.Repository.Biz
{
    public class RegistrationBiz : IRegistrationBiz
    {
        private readonly CRUDDalBase _db;

        public RegistrationBiz(CRUDDalBase db)
        {
            _db = db;
        }
        public async Task<Registration> AddUserAsync(Registration registration)
        {
            var user = _db.Registration.Where(x => x.Email == registration.Email).FirstOrDefault();
            if (user != null)
            {
                throw new Exception("User Already Present");
            }
            _db.Registration.Add(registration);
            await _db.SaveChangesAsync();
            return registration;
        }

        public List<Registration> GetUserList()
        {
            return _db.Registration.ToList();
        }

        public (bool, Registration) ValidateUser(string email, string password)
        {
            var user = _db.Registration.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
           return (user != null ? (true,  user) :(false, user));
        }
    }
}
