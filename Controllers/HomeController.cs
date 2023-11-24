using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgramTest.Data;
using ProgramTest.Models;
using ProgramTest.Repositories.Services;

namespace ProgramTest.Controllers;

public class HomeController : Controller
{
    // private readonly IPersonalService _personalService;
    private readonly IPersonalService _svc;

    public HomeController(IPersonalService svc)
    {
        // _personalService = personalService;
        _svc = svc;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> BulkSubmit([FromBody] List<PersonalType> personalData)
    {
        try
        {
            await _svc.InsertDataAsync(personalData);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
