using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgramTest.Models;
public class Hobi
{
   
    [Column(TypeName = "char(1)")]
    public char Id { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string? Nama { get; set; }
}
