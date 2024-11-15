using System;

namespace dwdm_pws2_gym.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sport
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Display(Name = "Sport")]
    public string Name { get; set; }

    [Display(Name = "Weekly Hours")]
    public int WeeklyHours { get; set; }

    public ICollection<Registration> Registrations { get; set; }
}
