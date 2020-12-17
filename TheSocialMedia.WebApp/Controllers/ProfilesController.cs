using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheSocialMedia.Domain.AggregatesModel.ProfileAggregate;
using TheSocialMedia.Infra.DataAccess.Context;

namespace TheSocialMedia.WebApp.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ProfileService _service;

        public ProfilesController(ProfileService service)
        {
            _service = service;
        }

        // GET: Profiles
        public IActionResult Index()
        {
            var userId = Guid.Parse(User.Claims.ToArray()[0].Value);
            var profile = _service.GetProfile(userId);

            //Verifica se o usuário logado já preencheu o perfil
            if (profile != null)
                //Se já existe, leva o usuário para a página do próprio perfil
                return RedirectToAction("Details");

            return View(_service.GetAllProfiles());
        }

        // GET: Profiles/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                id = GetUserId();

            var profile = _service.GetProfile(id.Value);

            if (profile == null)
                return NotFound();

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,PhotoUrl")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                profile.Id = GetUserId();
                _service.RegisterProfile(profile);
                
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = _service.GetProfile(id.Value);

            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,PhotoUrl")] Profile profile)
        {
            if (id != profile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = _service.EditProfile(profile);

                if (result == false)
                    return NotFound();
                  
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
               return NotFound();


            var profile = _service.GetProfile(id.Value);

            if (profile == null)
                return NotFound();

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _service.DeleteProfile(id);
            
            return RedirectToAction(nameof(Index));
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.Claims.ToArray()[0].Value);
        }
    }
}
