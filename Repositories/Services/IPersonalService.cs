using ProgramTest.Models;

namespace ProgramTest.Repositories.Services;

public interface IPersonalService : IBaseService<Personal>
{
    public Task<int> InsertDataAsync(List<PersonalType> personal);

}