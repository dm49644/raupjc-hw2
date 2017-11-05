using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Tests
{
    [TestClass()]
    public class TodoItemTests
    {
        [TestMethod()]
        public void TodoItemTest()
        {
            TodoItem ti=new TodoItem("string");
            Assert.AreEqual(ti.DateCreated, DateTime.UtcNow);
            Assert.AreEqual(ti.Text, "string");
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem ti = new TodoItem("string");
            Assert.IsFalse(ti.IsCompleted);
            ti.MarkAsCompleted();
            Assert.IsTrue(ti.IsCompleted);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            TodoItem ti = new TodoItem("string");
            Assert.IsFalse(ti.Equals(null));
            Assert.IsFalse(ti.Equals(new TodoItem("a")));
            TodoItem t2 = ti;
            Assert.IsTrue(ti.Equals(t2));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            TodoItem ti = new TodoItem("string");
            Assert.AreEqual(ti.Id.GetHashCode(), ti.GetHashCode());
        }
    }
}