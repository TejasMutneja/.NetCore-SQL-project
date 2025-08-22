using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // Database context that allows access to the 'Expenses' tab
    private readonly Expensesdb _context;

    public HomeController(ILogger<HomeController> logger,Expensesdb context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    /// If an ID is provided, that specific expense is retrieved and editing.
    public IActionResult CreateEditExpense(int? id )
    {
        if (id!=null)
        {
        var expense = _context.Expenses.SingleOrDefault(expense=> expense.Id==id);
        return View(expense);
        }
        return View();
    }
    /// Deletes an expense record from the database. Redirects to the Expenses list afterwards.
     public IActionResult DeleteExpense(int id )
    {
        var expenseInDB = _context.Expenses.SingleOrDefault(expense=> expense.Id==id);
        if (expenseInDB != null)
        {
        _context.Expenses.Remove(expenseInDB);
         _context.SaveChanges();
        }
        
        return RedirectToAction("Expenses"); 
    }
    
    /// Handles form submissions for both creating and editing an expense.
    ///If the ID is non-zero, it updates the existing record; otherwise, it creates a new record.  
     public IActionResult CreateEditExpenseForm(Expense model)
    { 
        if (model.Id!=0)
        {
            _context.Expenses.Update(model);
             _context.SaveChanges();
        }else
        {
             
            _context.Expenses.Add(model);
             _context.SaveChanges();
        }
       
        
        return RedirectToAction("Expenses");
    }
    /// Displays the list of all expenses in the database, along with their total sum 
    public IActionResult Expenses(){
        var allExpenses = _context.Expenses.ToList();
        var total = allExpenses.Sum(expense=>expense.Value);
        ViewBag.Expenses = total; 
        return View(allExpenses);
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
}
