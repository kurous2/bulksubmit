using ProgramTest.Models;

namespace ProgramTest.Repositories.Services;

public interface IHobiService
{
    public Task<List<Hobi>> GetHobiListAsync();
    
}