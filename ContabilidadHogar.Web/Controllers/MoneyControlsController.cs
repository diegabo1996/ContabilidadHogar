using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContabilidadHogar.Database;
using ContabilidadHogar.Models;
using ContabilidadHogar.Interfaces;

namespace ContabilidadHogar.Web.Controllers
{
    public class MoneyControlsController : Controller
    {
        private readonly IMoneyControlDatabaseTransactions _context;

        public MoneyControlsController(IMoneyControlDatabaseTransactions context)
        {
            _context = context;
        }

        // GET: MoneyControls
        public async Task<IActionResult> Index()
        {
              return _context.Read() != null ? 
                          View(_context.Read()) :
                          Problem("Entity set 'ContextMoney.RegistryMoneyControl'  is null.");
        }

        // GET: MoneyControls/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var moneyControl = _context.Read()
                .FirstOrDefault(m => m.IdTransaction == id);
            if (moneyControl == null)
            {
                return NotFound();
            }

            return View(moneyControl);
        }

        // GET: MoneyControls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoneyControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaction,TransactionDateTime,Description,Details,IncomeTransaction,AmountTransaction,BalanceTransaction")] MoneyControl moneyControl)
        {
            if (ModelState.IsValid)
            {
                moneyControl.IdTransaction = Guid.NewGuid();
                _context.Create(moneyControl);
                return RedirectToAction(nameof(Index));
            }
            return View(moneyControl);
        }

        // GET: MoneyControls/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var moneyControl = _context.Read(id);
            if (moneyControl == null)
            {
                return NotFound();
            }
            return View(moneyControl);
        }

        // POST: MoneyControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdTransaction,TransactionDateTime,Description,Details,IncomeTransaction,AmountTransaction,BalanceTransaction")] MoneyControl moneyControl)
        {
            if (id != moneyControl.IdTransaction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyControl);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyControlExists(moneyControl.IdTransaction))
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
            return View(moneyControl);
        }

        // GET: MoneyControls/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var moneyControl = _context.Read(id);
            if (moneyControl == null)
            {
                return NotFound();
            }

            return View(moneyControl);
        }

        // POST: MoneyControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'ContextMoney.RegistryMoneyControl'  is null.");
            }
            var moneyControl = _context.Read(id);
            if (moneyControl != null)
            {
                _context.Delete(moneyControl);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyControlExists(Guid id)
        {
            if (_context.Read(id)!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
