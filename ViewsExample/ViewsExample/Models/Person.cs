namespace ViewsExample.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public Gender? PersonGender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public enum Gender
    {
        Male,Female,Others
    }
}
