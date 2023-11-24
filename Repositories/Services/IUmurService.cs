using ProgramTest.Models;

namespace ProgramTest.Repositories.Services;

public interface IUmurService
{
    public Task<List<Umur>> GetUmurListAsync();
}