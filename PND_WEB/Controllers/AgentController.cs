using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;
using PND_WEB.ViewModels;

namespace WebApplication4.Controllers
{
    public class AgentController : Controller
    {
        private readonly DataContext _context;

        public AgentController(DataContext context)
        {
            _context = context;
        }

        // GET: Agent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agents.ToListAsync());
        }

        // GET: Agent/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.Code == id);
            if (agent == null)
            {
                return NotFound();
            }

            AgentActionViewModel agentViewModel = new AgentActionViewModel();
            agentViewModel.agent = agent;
            agentViewModel.agentActions = await _context.AgentActions
                .Where(a => a.Code == id)
                .ToListAsync();

            return View(agentViewModel);
        }

        // GET: Agent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,AgentName,AgentNamekd,AgentAdd,Note")] Agent agent)
        {
            var agentid = _context.Agents.Select(c => c.Code).ToList();
            if (agentid.Contains(agent.Code))
            {
                ModelState.AddModelError("CustomerId", "Mã agent đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agent/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Agent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,AgentName,AgentNamekd,AgentAdd,Note")] Agent agent)
        {
            if (id != agent.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.Code))
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
            return View(agent);
        }

        // GET: Agent/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.Code == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agentAction = await _context.AgentActions
                .Where(a => a.Code == id)
                .ToListAsync();
            if (agentAction != null)
            {
                foreach (var item in agentAction)
                {
                    _context.AgentActions.Remove(item);
                }

            }
            var agent = await _context.Agents.FindAsync(id);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(string id)
        {
            return _context.Agents.Any(e => e.Code == id);
        }


        [HttpGet]
        [Route("Agent/AgentCreate/{id}")]
        public async Task<IActionResult> AgentCreate(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            AgentActionEditModel agentViewModel = new();
            agentViewModel.id = id;
            agentViewModel.agentAction = new AgentAction();
            return View(agentViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgentCreate(AgentActionEditModel agentEdit)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var agent = await _context.Agents.FindAsync(agentEdit.id);
                if (agent == null)
                {
                    return NotFound();
                }
                agentEdit.agentAction.Code = agentEdit.id;
                _context.AgentActions.Add(agentEdit.agentAction);
                await _context.SaveChangesAsync();
                TempData["status"] = "Thêm thành công";
                return RedirectToAction("Details", new { id = agentEdit.id });
            }
            else
            {
                TempData["status"] += "Thêm không thành công";
            }
            return View(agentEdit);

        }

        [HttpGet]
        public async Task<IActionResult> AgentEdit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agentAction = await _context.AgentActions.FindAsync(id);
            if (agentAction == null)
            {
                return NotFound();
            }
            var agentEditModel = new AgentActionEditModel
            {
                agentAction = agentAction,
                id = agentAction.Code
            };

            return View(agentEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgentEdit(AgentActionEditModel agentEdit)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var agentAction = await _context.AgentActions.FindAsync(agentEdit.agentAction.Id);
                if (agentAction == null)
                {
                    return NotFound();
                }

                agentAction.PersonInCharge = agentEdit.agentAction.PersonInCharge;
                agentAction.PhoneNumber = agentEdit.agentAction.PhoneNumber;
                agentAction.Email = agentEdit.agentAction.Email;
                agentAction.Note = agentEdit.agentAction.Note;
                _context.Update(agentAction);
                await _context.SaveChangesAsync();
                TempData["status"] = "Sửa thành công";
                return RedirectToAction("Details", new { id = agentEdit.agentAction.Code });
            }
            else
            {
                TempData["status"] += "Sửa không thành công";
            }
            return View(agentEdit);
        }

        [HttpGet]
        public async Task<IActionResult> AgentDelete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agentAction = await _context.AgentActions.FindAsync(id);
            if (agentAction == null)
            {
                return NotFound();
            }
            var agentEditModel = new AgentActionEditModel
            {
                agentAction = agentAction,
                id = agentAction.Code
            };
            return View(agentEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgentDelete(AgentActionEditModel agentEdit)
        {
            TempData["status"] = "Error: ";
            if (agentEdit.agentAction == null)
            {
                return NotFound();
            }
            var agentAction = await _context.AgentActions.FindAsync(agentEdit.agentAction.Id);
            var Code = agentAction.Code;
            if (agentAction == null)
            {
                return NotFound();
            }

            _context.AgentActions.Remove(agentAction);
            await _context.SaveChangesAsync();
            TempData["status"] = "Xóa thành công";
            return RedirectToAction("Details", new { id = Code });
        }
    }
}
