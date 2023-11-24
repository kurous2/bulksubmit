using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgramTest.Models;
 [Keyless]
public class Umur
{
    public int? Age { get; set; }
    public int? Total { get; set; }
}