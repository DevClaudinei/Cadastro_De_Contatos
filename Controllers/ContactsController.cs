using ContactRegister.Data;
using ContactRegister.Exceptions;
using ContactRegister.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContactRegister.Controllers
{   
    public class ContactsController : Controller
    {
        private readonly ContactContext _context;

        public ContactsController(ContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.Include(x => x.Emails).ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                VerifyIntRequestStatus(id, _context);
                var contact = await _context.Contacts.Include(x => x.Emails)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (contact == null)
                    throw new NotFoundException($"Contact for id: {id} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
        }

        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                VerifyStringRequestStatus(name, _context);
                var contact = await _context.Contacts.Include(x => x.Emails)
                    .Where(x => x.Name.Contains(name)).ToListAsync();

                if (contact.Count == 0)
                    throw new NotFoundException($"Contact for name: {name} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
        }

        public async Task<IActionResult> GetByCompany(string company)
        {
            try
            {
                VerifyStringRequestStatus(company, _context);
                var contact = await _context.Contacts.Include(x => x.Emails)
                        .Where(x => x.Company.Contains(company)).ToListAsync();

                if (contact.Count == 0)
                    throw new NotFoundException($"Contact for company: {company} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
        }

        public async Task<IActionResult> GetByPersonalPhone(string personalPhone)
        {
            try
            {
                VerifyStringRequestStatus(personalPhone, _context);
                var contact = await _context.Contacts.Include(x => x.Emails)
                    .FirstOrDefaultAsync(x => x.PersonalPhone.Equals(personalPhone));

                if (contact == null)
                    throw new NotFoundException($"Contact for personal phone: {personalPhone} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
        }

        public async Task<IActionResult> GetByCommercialPhone(string commercialPhone)
        {
            try
            {
                VerifyStringRequestStatus(commercialPhone, _context);
                var contact = await _context.Contacts.Include(x => x.Emails)
                    .FirstOrDefaultAsync(x => x.CommercialPhone.Equals(commercialPhone));

                if (contact == null)
                    throw new NotFoundException($"Contact for personal phone: {commercialPhone} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
        }

        public async Task<IActionResult> GetByEmail([FromQuery(Name = "e-mail")] string email)
        {
            try
            {
                VerifyStringRequestStatus(email, _context);
                var contact = await _context.Contacts.Include(x => x.Emails)
                    .FirstOrDefaultAsync(x => x.Emails.Any(x => x.Address == email));
                
                if (contact == null)
                    throw new NotFoundException($"Contact for e-mail: {email} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
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
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
                return NotFound();

            var contact = await _context.Contacts.Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        private void PreparingPropertiesForUpdate(Contact existingContact, Contact contact)
        {
                existingContact.Name = contact.Name;
                existingContact.Company = contact.Company;
                existingContact.PersonalPhone = contact.PersonalPhone;
                existingContact.CommercialPhone = contact.CommercialPhone;

                var existingEmailIds = existingContact.Emails.Select(e => e.Id).ToList();

                foreach (var existingEmail in existingContact.Emails.ToList())
                {
                    if (!contact.Emails.Any(e => e.Id == existingEmail.Id))
                        existingContact.Emails.Remove(existingEmail);
                }

                foreach (var newEmail in contact.Emails)
                {
                    if (existingEmailIds.Contains(newEmail.Id))
                    {
                        var existingEmail = existingContact.Emails.FirstOrDefault(e => e.Id == newEmail.Id);
                        if (existingEmail != null)
                            existingEmail.Address = newEmail.Address;
                    }
                    existingContact.Emails.Add(newEmail);
                }
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Company,PersonalPhone,CommercialPhone,Emails")] Contact contact)
         public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Company,PersonalPhone,CommercialPhone,Emails")] Contact contact)
        {
            if (id != contact.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingContact = await _context.Contacts
                    .Include(c => c.Emails).FirstOrDefaultAsync(c => c.Id == contact.Id);

                if (existingContact == null)
                    return NotFound();
                
                try
                {
                    PreparingPropertiesForUpdate(existingContact, contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contact.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                VerifyIntRequestStatus(id, _context);
                var contact = await _context.Contacts
                    .FirstOrDefaultAsync(m => m.Id == id);
                
                if (contact == null)
                    throw new NotFoundException($"Contact for id: {id} not found.");

                return View(contact);
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
            catch (BadRequestException e)
            {
                return View("Error 500", e);
            }
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

        private void VerifyStringRequestStatus(string parameter, ContactContext context)
        {
            if (parameter == null || context.Contacts == null)
                throw new BadRequestException("An error occurred in the request or context");            
        }

        private void VerifyIntRequestStatus(int? parameter, ContactContext context)
        {
            if (parameter == null || context.Contacts == null)
                throw new BadRequestException("An error occurred in the request or context");            
        }
    }
}
