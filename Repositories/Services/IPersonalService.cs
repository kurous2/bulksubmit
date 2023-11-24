using ProgramTest.Models;

namespace ProgramTest.Repositories.Services;

public interface IPersonalService
{
    public Task<List<Personal>> GetPersonalListAsync();
    public Task<int> InsertDataAsync(List<PersonalType> personal);

}