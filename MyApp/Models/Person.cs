namespace MyApp.Models;

using System.ComponentModel.DataAnnotations;

public class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Date of Birth is required")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }
}