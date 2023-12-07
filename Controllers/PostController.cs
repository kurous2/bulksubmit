using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgramTest.Data;
using ProgramTest.Models;
using ProgramTest.Repositories.Services;

namespace ProgramTest.Controllers;

public class PostController : Controller
{
    // private readonly IPersonalService _personalService;
    private readonly IPersonalService _svc;

    public PostController(IPersonalService svc)
    {
        // _personalService = personalService;
        _svc = svc;
    }

    
    public IActionResult GenerateData()
    {
        return View("BulkSubmit");
    }

    public async Task<IActionResult> Index()
    {
        var result = await _svc.ToListAsync();
        return View(result);
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
