using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoLot.Models;
using AutoLot.Data;

namespace AutoLot.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AutoLotContext _context;

    public HomeController(ILogger<HomeController> logger, AutoLotContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        await EnsureDatabaseSeeded();
        var cars = await _context.Cars.ToListAsync();
        return View(cars);
    }

    public async Task<IActionResult> Details(int id)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    private async Task EnsureDatabaseSeeded()
    {
        if (!await _context.Cars.AnyAsync())
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2022,
                    Trim = "LE",
                    Price = 28500m,
                    ImageUrl = "https://picsum.photos/400/300?random=1",
                    Mileage = 15000,
                    Color = "Silver",
                    Engine = "2.5L 4-Cylinder",
                    Transmission = "Automatic",
                    FuelType = "Gasoline",
                    Drivetrain = "FWD",
                    Features = "Backup Camera, Bluetooth, Cruise Control, Power Windows, Air Conditioning",
                    Description = "Reliable and fuel-efficient sedan perfect for daily commuting.",
                    VIN = "1HGBH41JXMN109186"
                },
                new Car
                {
                    Make = "Honda",
                    Model = "CR-V",
                    Year = 2023,
                    Trim = "EX",
                    Price = 32900m,
                    ImageUrl = "https://picsum.photos/400/300?random=2",
                    Mileage = 8500,
                    Color = "Black",
                    Engine = "1.5L Turbo 4-Cylinder",
                    Transmission = "CVT",
                    FuelType = "Gasoline",
                    Drivetrain = "AWD",
                    Features = "Sunroof, Heated Seats, Apple CarPlay, Android Auto, Honda Sensing Suite",
                    Description = "Spacious and versatile SUV with excellent safety ratings.",
                    VIN = "2HKRM4H75NH123456"
                },
                new Car
                {
                    Make = "Ford",
                    Model = "F-150",
                    Year = 2021,
                    Trim = "XLT",
                    Price = 45500m,
                    ImageUrl = "https://picsum.photos/400/300?random=3",
                    Mileage = 22000,
                    Color = "Blue",
                    Engine = "3.5L V6 EcoBoost",
                    Transmission = "10-Speed Automatic",
                    FuelType = "Gasoline",
                    Drivetrain = "4WD",
                    Features = "Tow Package, Bed Liner, Running Boards, SYNC 3, Remote Start",
                    Description = "America's best-selling truck with impressive towing capacity.",
                    VIN = "1FTFW1E50MFA12345"
                },
                new Car
                {
                    Make = "BMW",
                    Model = "X5",
                    Year = 2020,
                    Trim = "xDrive40i",
                    Price = 52000m,
                    ImageUrl = "https://picsum.photos/400/300?random=4",
                    Mileage = 35000,
                    Color = "White",
                    Engine = "3.0L Turbo I6",
                    Transmission = "8-Speed Automatic",
                    FuelType = "Gasoline",
                    Drivetrain = "AWD",
                    Features = "Premium Package, Panoramic Sunroof, Navigation, Leather Seats, Harman Kardon Audio",
                    Description = "Luxury SUV with premium features and sporty performance.",
                    VIN = "5UXCR6C04L9A12345"
                },
                new Car
                {
                    Make = "Chevrolet",
                    Model = "Malibu",
                    Year = 2023,
                    Trim = "LT",
                    Price = 26800m,
                    ImageUrl = "https://picsum.photos/400/300?random=5",
                    Mileage = 5200,
                    Color = "Red",
                    Engine = "1.5L Turbo 4-Cylinder",
                    Transmission = "CVT",
                    FuelType = "Gasoline",
                    Drivetrain = "FWD",
                    Features = "Apple CarPlay, Android Auto, Teen Driver, WiFi Hotspot, Remote Start",
                    Description = "Modern sedan with advanced technology and excellent fuel economy.",
                    VIN = "1G1ZD5ST5NF123456"
                },
                new Car
                {
                    Make = "Jeep",
                    Model = "Wrangler",
                    Year = 2022,
                    Trim = "Sahara",
                    Price = 48900m,
                    ImageUrl = "https://picsum.photos/400/300?random=6",
                    Mileage = 12000,
                    Color = "Green",
                    Engine = "3.6L V6",
                    Transmission = "8-Speed Automatic",
                    FuelType = "Gasoline",
                    Drivetrain = "4WD",
                    Features = "Removable Doors, Fold-Down Windshield, Rock Rails, Uconnect 4C NAV",
                    Description = "Iconic off-road vehicle built for adventure and capability.",
                    VIN = "1C4HJXEG6NW123456"
                }
            };

            _context.Cars.AddRange(cars);
            await _context.SaveChangesAsync();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
