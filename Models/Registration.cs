using System;

namespace dwdm_pws2_gym.Models;

public class Registration
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int SportId { get; set; }

    public Student Student { get; set; }

    public Sport Sport { get; set; }
}
