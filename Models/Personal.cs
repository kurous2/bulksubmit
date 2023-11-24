using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgramTest.Models;
public class Personal
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string? Nama { get; set; }
    public int? IdGender { get; set; }
    public Gender? Gender { get; set; }
    [Column(TypeName = "char(1)")]
    public char? IdHobi { get; set; }
    [ForeignKey("IdHobi")]
    public Hobi? Hobi { get; set; }
    public int? Umur { get; set; }
}

public class PersonalType{

    public string? Nama { get; set; }
    public int? IdGender { get; set; }
    public char? IdHobi { get; set; }
    public int? Umur { get; set; }
}