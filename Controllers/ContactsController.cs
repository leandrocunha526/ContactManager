using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;
using ContactManager.Data;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts
                .Where(c => !c.IsDeleted)
                .ToListAsync();
            return View(contacts);
        }

        // GET: Contacts/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (contact == null) return NotFound();

            return View(contact);
        }

        // GET: Contacts/Create
        [Authorize]
        public IActionResult Create() => View();

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Name,Phone,Email")] Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);

            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null || contact.IsDeleted) return NotFound();

            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Email")] Contact contact)
        {
            if (id != contact.Id) return NotFound();

            if (!ModelState.IsValid) return View(contact);

            try
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Contacts.Any(e => e.Id == contact.Id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (contact == null) return NotFound();

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.IsDeleted = true;
                contact.DeletedAt = DateTime.UtcNow;
                _context.Update(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Deleted
        [Authorize]
        public async Task<IActionResult> Deleted()
        {
            var deletedContacts = await _context.Contacts
                .Where(c => c.IsDeleted)
                .ToListAsync();

            return View(deletedContacts);
        }

        // POST: Contacts/Restore/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Restore(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null || !contact.IsDeleted) return NotFound();

            contact.IsDeleted = false;
            contact.DeletedAt = null;

            _context.Update(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Deleted));
        }
    }
}
