using System;
using System.Collections.Generic;

namespace NewStudent.Entity.Models;

public partial class Student
{
    public Guid Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string? City { get; set; }

    public DateTime JoinDate { get; set; }

    public int Std { get; set; }
}
