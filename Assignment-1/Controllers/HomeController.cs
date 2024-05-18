using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment_1.Controllers;



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;


    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Songs()
    {
        return View();
    }

    public async Task<IActionResult> Song1()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:5234/skyFullOfStars");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            ViewData["Data"] = data;
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Song1 action");
            throw;
        }
    }

    public async Task<IActionResult> Song2()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:5234/shivers");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            ViewData["Data"] = data;
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Song1 action");
            throw;
        }
    }
    // public IActionResult Song2()
    // {
    //     return View();
    // }

    public async Task<IActionResult> Song3()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:5234/sunflower");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            ViewData["Data"] = data;
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Song1 action");
            throw;
        }
    }

    // public IActionResult Song3()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
