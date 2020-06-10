using Marten;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskList.Domain;

namespace TaskList.Controllers
{
    public class TasksController : Controller
    {
        private readonly IDocumentStore _documentStore;

        public TasksController(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public IActionResult Index()
        {
            List<Task> tasks;
            using (var session = _documentStore.LightweightSession())
            {
                tasks = session.Query<Task>().ToList();
            }
            return View(tasks);
        }
        public IActionResult Create(Task task)
        {
            task.AddedOn = DateTime.UtcNow;

            using (var session = _documentStore.LightweightSession())
            {
                session.Store(task);
                session.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (var session = _documentStore.LightweightSession())
            {
                session.Delete<Task>(id);
                session.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult MarkAsComplete(int id)
        {
            using (var session = _documentStore.LightweightSession())
            {
                var task = session.Load<Task>(id);
                task.MarkAsComplete();
                session.Store(task);
                session.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult MarkAsIncomplete(int id)
        {
            using (var session = _documentStore.LightweightSession())
            {
                var task = session.Load<Task>(id);
                task.MarkAsIncomplete();
                session.Store(task);
                session.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
