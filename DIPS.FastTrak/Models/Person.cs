namespace DIPS.FastTrak.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NationalId { get; set; }
        public int? DigitallyActive { get; set; }
        public int Age => DateTime.Today.Year - DOB.Year;
        public DateTime DOB { get; set; }
        public string? FullName => $"{LastName}, {FirstName}";
    }
}
