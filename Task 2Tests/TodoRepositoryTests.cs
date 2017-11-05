using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.zadatak;

namespace Task_2.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {

        [TestMethod()]
        public void GetTest()
        {
            IGenericList<TodoItem> list = new GenericList<TodoItem>();
            TodoItem ti = new TodoItem("a");
            list.Add(ti);
            TodoRepository tr=new TodoRepository(list);
            Assert.AreEqual(ti, tr.Get(ti.Id));
        }

        [TestMethod()]
        public void AddTest()
        {
            TodoItem ti = new TodoItem("a");
            TodoRepository tr = new TodoRepository(null);
            Assert.AreEqual(ti, tr.Add(ti));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoItem ti = new TodoItem("a");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti);
            Assert.IsTrue(tr.Remove(ti.Id));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoItem ti = new TodoItem("a");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti);
            ti.Text = "b";
            tr.Update(ti);
            Assert.IsTrue(tr.Get(ti.Id).Text.Equals("b"));
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem ti = new TodoItem("a");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti);
            tr.MarkAsCompleted(ti.Id);
            Assert.IsTrue(tr.Get(ti.Id).IsCompleted);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoItem ti1 = new TodoItem("a");
            TodoItem ti2= new TodoItem("b");
            TodoItem ti3 = new TodoItem("c");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti1);
            tr.Add(ti2);
            tr.Add(ti3);
            List<TodoItem> list = new List<TodoItem>();
            list.Add(ti1);
            list.Add(ti2);
            list.Add(ti3);
            list = list.OrderByDescending(s => s.DateCreated).ToList();
            CollectionAssert.AreEqual(tr.GetAll(), list);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoItem ti1 = new TodoItem("a");
            TodoItem ti2 = new TodoItem("b");
            TodoItem ti3 = new TodoItem("c");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti1);
            tr.Add(ti2);
            tr.Add(ti3);
            tr.MarkAsCompleted(ti2.Id);
            tr.MarkAsCompleted(ti1.Id);
            List<TodoItem> list = new List<TodoItem>();
            list.Add(ti3);
            CollectionAssert.AreEqual(tr.GetActive(), list);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoItem ti1 = new TodoItem("a");
            TodoItem ti2 = new TodoItem("b");
            TodoItem ti3 = new TodoItem("c");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti1);
            tr.Add(ti2);
            tr.Add(ti3);
            tr.MarkAsCompleted(ti2.Id);
            List<TodoItem> list = new List<TodoItem>();
            list.Add(ti2);
            CollectionAssert.AreEqual(tr.GetCompleted(), list);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            TodoItem ti1 = new TodoItem("a");
            TodoItem ti2 = new TodoItem("b");
            TodoItem ti3 = new TodoItem("c");
            TodoRepository tr = new TodoRepository(null);
            tr.Add(ti1);
            tr.Add(ti2);
            tr.Add(ti3);
            List<TodoItem> list = new List<TodoItem>();
            list.Add(ti3);
            CollectionAssert.AreEqual(tr.GetFiltered(s=>s.Text.Equals("c")), list);
        }
    }
}