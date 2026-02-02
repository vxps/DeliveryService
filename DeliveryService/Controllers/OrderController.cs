using DeliveryService.DataAccess;
using DeliveryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Controllers;

public class OrderController : Controller
{
    private readonly DeliveryDbContext _context;

    public OrderController(DeliveryDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Orders.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Orders == null)
        {
            return NotFound();
        }

        var order = await _context.Orders
            .FirstOrDefaultAsync(m => m.Id == id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SenderCity,SenderAddress,ReceiverCity,ReceiverAddress,Weight,PickupDate")] Order order)
    {
        if (ModelState.IsValid)
        {
            order.OrderNumber = Guid.NewGuid();
            order.CreatedDate = DateTime.UtcNow;
            order.PickupDate = DateTime.SpecifyKind(order.PickupDate.Date, DateTimeKind.Utc);
                
            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(order);
    }
    
    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }
}