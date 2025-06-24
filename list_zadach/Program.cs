using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Task(string name, string description)
        {
            Name = name;
            Description = description;
            Status = false;
            Date = DateTime.Now;
        }
        public void CompletedTask()
        {
            Status = true;
        }
    }
    public class ToDoList
    {
        private List<Task> tasks;
        public ToDoList()
        {
            tasks = new List<Task>();
        }
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public void CompleteTask(int taskNum)
        {
            if (taskNum >= 0 && taskNum < tasks.Count)
            {
                tasks[taskNum].CompletedTask();
            }
        }
        public void DeleteTask(int taskNumDel)
        {
            if (taskNumDel >= 0 && taskNumDel < tasks.Count)
            {
                tasks.RemoveAt(taskNumDel);
            }
        }
        public void DisplayTasks(bool ShowActive)
        {
            if (ShowActive == true)
            {
                tasks.RemoveAll(tasks => tasks.Status == true);
                for (int i = 0; i < tasks.Count; i++)
                    Console.WriteLine($"{i + 1}. {tasks[i].Name} - {tasks[i].Description} - {(tasks[i].Status ? "Выполнена" : "Активна")} - {tasks[i].Date}");
            }
            else
            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine($"{i + 1}. {tasks[i].Name} - {tasks[i].Description} - {(tasks[i].Status ? "Выполнена" : "Активна")} - {tasks[i].Date}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();
            while (true)
            {
                Console.WriteLine("1. Создать задачу.");
                Console.WriteLine("2. Список всех задач.");
                Console.WriteLine("3. Отметить задачу как выполненную.");
                Console.WriteLine("4. Удалить задачу.");
                Console.WriteLine("5. Показать только активные задачи.");
                Console.WriteLine("0. Выход.");

                var option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Console.WriteLine("Вставьте название задачи");
                        var name = Console.ReadLine();
                        Console.WriteLine("Вставьте описание задачи");
                        var description = Console.ReadLine();
                        toDoList.AddTask(new Task(name, description));
                        Console.Clear();
                        break;
                    case "2":
                        toDoList.DisplayTasks(false);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        toDoList.DisplayTasks(false);
                        Console.WriteLine("Введите номер задачи, которую хотите выполнить");
                        var taskNum = int.Parse(Console.ReadLine());
                        toDoList.CompleteTask(taskNum - 1);
                        Console.Clear();
                        break;
                    case "4":
                        toDoList.DisplayTasks(false);
                        Console.WriteLine("Введите номер задачи, которую хотите удалить");
                        var taskNumDel = int.Parse(Console.ReadLine());
                        toDoList.DeleteTask(taskNumDel - 1);
                        Console.Clear();
                        break;
                    case "5":
                        toDoList.DisplayTasks(true);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод, пожалуйста повторите попытку");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
