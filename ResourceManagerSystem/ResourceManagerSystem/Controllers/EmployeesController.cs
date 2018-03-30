using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.CI == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CI,Name,FirstName,LastName,Phone,Email,Sex,BirthDate,CivilState,Height,Weight,AdmissionDate,Illiterate,Basic,HighSchool,MiddleTechnician,Degree,Visual,Motor,Mental")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.CI == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CI,Name,FirstName,LastName,Phone,Email,Sex,BirthDate,CivilState,Height,Weight,AdmissionDate,Illiterate,Basic,HighSchool,MiddleTechnician,Degree,Visual,Motor,Mental")] Employee employee)
        {
            if (id != employee.CI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.CI))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.CI == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.CI == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddMasiveEmployees(int quantity)
        {
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name");
            List<EmployeModelView> model=new List<EmployeModelView>();
            for (int i = 0; i < quantity; i++)
            {
                model.Add(new EmployeModelView() { });
            }
            return View(model);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMasiveEmployees(List<EmployeModelView> model)
        {
            foreach (var item in model)
            {
                Employee employee = new Employee() {
                    CI =item.CI,
                    AdmissionDate =item.AdmissionDate,
                    Basic =item.Basic,
                    BirthDate =item.BirthDate,
                    CivilState =item.CivilState,
                    Degree =item.Degree,
                    Email=item.Email,
                    FirstName=item.FirstName,
                    LastName=item.LastName,
                    Name=item.Name,
                    Height=item.Height,
                    Weight=item.Weight,
                    HighSchool=item.HighSchool,
                    Illiterate=item.Illiterate,
                    Mental=item.Mental,
                    MiddleTechnician=item.MiddleTechnician,
                    Motor=item.Motor,
                    Sex=item.Sex,
                    Visual=item.Visual,
                    Phone=item.Phone,
                };
                Contrat contrat = new Contrat() {
                    CI=item.CI,
                    DateEnd=item.DateEnd,
                    DateStart=item.DateStart,
                    OperativeID=item.OperativeID,
                    TypeContrat=item.TypeContrat,
                };
                if (!EmployeeExists(employee.CI))
                {
                    _context.Employee.Add(employee);                    
                    _context.Contrat.Add(contrat);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.CI == id);
        }
    }
}
