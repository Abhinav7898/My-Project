namespace CRUD.Dto
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int IsActive { get; set; }
        public int IsApproved { get; set; }
    }
}