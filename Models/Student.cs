using System;
using System.ComponentModel.DataAnnotations;

namespace dwdm_pws2_gym.Models;

public class Student
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Registration Date")]
    public DateTime RegistrationDate { get; set; }

    public ICollection<Registration> Registrations { get; set; }
}
