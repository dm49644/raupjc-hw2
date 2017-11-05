using System;
using System.Collections.Generic;
using System.Linq;
using _3.zadatak;

namespace Task_2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();

            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(s => s.Id.Equals(todoId));
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException("duplicate id: { " + todoItem.Id + " }");
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (Get(todoItem.Id) == null) return Add(todoItem);
            Get(todoItem.Id).DateCompleted = todoItem.DateCompleted;
            Get(todoItem.Id).DateCreated = todoItem.DateCreated;
            Get(todoItem.Id).Text = todoItem.Text;
            return Get(todoItem.Id);
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            return Get(todoId).MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}