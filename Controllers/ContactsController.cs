using ContactRegister.Data;
using ContactRegister.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContactRegister.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactContext _context;

        public ContactsController(ContactContext context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.Include(x => x.Emails).ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
                return NotFound();

            var contato = await _context.Contacts.Include(x => x.Emails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
                return NotFound();

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Nome,Empresa,TelefonePessoal,TelefoneComercial,Emails")] Contact contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
                return NotFound();

            var contato = await _context.Contacts.Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contato == null)
                return NotFound();

            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Empresa,TelefonePessoal,TelefoneComercial,Emails")] Contact contato)
        {
            if (id != contato.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingContato = await _context.Contacts
                    .Include(c => c.Emails).FirstOrDefaultAsync(c => c.Id == contato.Id);

                if (existingContato == null)
                    return NotFound();

                existingContato.Name = contato.Name;
                existingContato.Company = contato.Company;
                existingContato.PersonalPhone = contato.PersonalPhone;
                existingContato.CommercialPhone = contato.CommercialPhone;

                var existingEmailIds = existingContato.Emails.Select(e => e.Id).ToList();

                foreach (var existingEmail in existingContato.Emails.ToList())
                {
                    if (!contato.Emails.Any(e => e.Id == existingEmail.Id))
                        existingContato.Emails.Remove(existingEmail);
                }

                foreach (var newEmail in contato.Emails)
                {
                    if (existingEmailIds.Contains(newEmail.Id))
                    {
                        var existingEmail = existingContato.Emails.FirstOrDefault(e => e.Id == newEmail.Id);
                        if (existingEmail != null)
                            existingEmail.Address = newEmail.Address;
                    }
                    existingContato.Emails.Add(newEmail);
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
                return NotFound();

            var contato = await _context.Contacts

                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
                return NotFound();

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
                return Problem("Entity set 'ContatoContext.Contatos'  is null.");

            var contato = await _context.Contacts.FindAsync(id);
            if (contato != null)
                _context.Contacts.Remove(contato);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
