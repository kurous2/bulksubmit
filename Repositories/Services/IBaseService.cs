using ProgramTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProgramTest.Repositories.Services;

public interface IBaseService<T>
{
      Task<List<T>> ToListAsync();

}