using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivitiesManager.Data;
using ActivitiesManager.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace ActivitiesManager.Controllers
{

    public class TodoItemsController : Controller
    {
        private readonly IApiConnection _api;

        public TodoItemsController(IApiConnection api)
        {
            _api = api;
        }

        // GET: TodoItems
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = JsonConvert.DeserializeObject<List<TodoItem>>((string)await _api.Get());
            if (list == null)
            {
                return View();
            }
            return View(list);
        }

        // GET: TodoItems/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await GetItem(id);

            if (item == null)
            {
                return View();
            }
            return View(item);
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DT_Creation,DT_DeadLine,DT_Done,Priority")] TodoItem todoItem)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(todoItem), Encoding.UTF8, "application/json");
            var result =await _api.Post(content);
            var newItem= JsonConvert.DeserializeObject <TodoItem> ((string)result);
            /*if (ModelState.IsValid)
            {
                _context.Add(todoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);*/
            return RedirectToAction(nameof(Index));
        }

        // GET: TodoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            TodoItem todoItem = await GetItem(id);
            //var todoItem = await _api.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DT_Creation,DT_DeadLine,DT_Done,Priority")] TodoItem todoItem)
        {
            
            if (id != todoItem.Id)
            {
                return NotFound();
            }
         
            try
            {
                
                StringContent content = new StringContent(JsonConvert.SerializeObject(todoItem), Encoding.UTF8, "application/json");

                await _api.Put(todoItem.Id, content);

            }
            catch (Exception ex)
            {
                if (!await TodoItemExists(todoItem.Id))
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

        // GET: TodoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            TodoItem item = await GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        private async Task<TodoItem> GetItem(int? id)
        {
            return JsonConvert.DeserializeObject<TodoItem>((string)await _api.Get(id));
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _api.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TodoItemExists(int id)
        {
            TodoItem item = await GetItem(id);
            return item.Id == id;
        }
    }
}
