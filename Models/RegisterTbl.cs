namespace C_INFO.Models
{
    public class RegisterTbl
    {
        public int Id  { get; set; }
        public string UserName { get; set; }
        public int? PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IsAdmin { get; set; }
    }
}
