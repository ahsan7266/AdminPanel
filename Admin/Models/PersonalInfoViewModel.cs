namespace Admin.Models
{
    public class PersonalInfoViewModel
    {
        public Guid PeronalInfoId { get; set; }
        public IFormFile? Backgroundimg { get; set; }
        public ByteArrayContent Backgroundimgbyte { get; set; }
        public IFormFile? Profileimg { get; set; }
        public IFormFile? Cv { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int Age { get; set; }
        public string? Detail { get; set; }
        public string? Experience { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
