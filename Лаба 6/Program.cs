using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_6
{
    public class library
    {
        public string NameOfLibrary { get; set; }
        List<object> Library = new List<object>();
        public void info()
        {
            foreach (var item in Library)
            {
                Console.WriteLine(item);
            }
        }

        public void Add(object data)
        {
            Library.Add(data);
        }
        public bool Remove(object data)
        {
           return Library.Remove(data);
        }

    
        public class Book<T>
        {
            public Book(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Book<T> Next { get; set; }
        }

        private class List<T> : IEnumerable<T>  // односвязный список
        {
            public Book<T> head; // головной/первый элемент
            public Book<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                Book<T> Book = new Book<T>(data);

                if (head == null)
                    head = Book;
                else
                    tail.Next = Book;
                tail = Book;

                count++;
            }
            // удаление элемента
            public bool Remove(T data)
            {
                Book<T> current = head;
                Book<T> previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;

                            // Если current.Next не установлен, значит узел последний,
                            // изменяем переменную tail
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            // если удаляется первый элемент
                            // переустанавливаем значение head
                            head = head.Next;

                            // если после удаления список пуст, сбрасываем tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
                return false;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            // очистка списка
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            // содержит ли список элемент
            public bool Contains(T data)
            {
                Book<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            // добвление в начало
            public void AppendFirst(T data)
            {
                Book<T> Book = new Book<T>(data);
                Book.Next = head;
                head = Book;
                if (count == 0)
                    tail = head;
                count++;
            }
            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Book<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            public void info()
            {
                Book<T> current = head;
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }

        }
}
    public abstract class Print_Edition
    {
        public string Author = "Me", Publisher = "My friend";
        public virtual void info()
        { }
        public abstract bool electronic_analogue();
        public override string ToString()
        {
            object a = GetType();
            Console.WriteLine(Author);
            Console.WriteLine(Publisher);
            return Convert.ToString(a);
        }
    }
    public interface IPerson
    {
        bool Person();

    }
    public interface IBook
    {
        bool electronic_analogue();
    }
    public class Textbook : Print_Edition, IBook, IPerson
    {
        public override bool electronic_analogue()
        { return true; }
        bool IBook.electronic_analogue()
        { return false; }
        bool IPerson.Person()
        {
            return false;
        }
        public override void info()
        {
            base.info();
        }
    }
    public sealed class Magazine : Print_Edition, IPerson
    {
        bool IPerson.Person()
        {
            return true;
        }
        public override bool electronic_analogue()
        { return true; }
    }

    public class Journal : Print_Edition, IPerson
    {
        bool IPerson.Person()
        {
            return false;
        }
        public override bool electronic_analogue()
        { return true; }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Printer
    {
        public virtual object IAmPrinting(Print_Edition someobj)
        {
            someobj.GetType();
            someobj.ToString();
            return someobj.GetType();
        }
    }
    enum Days
    {
        monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    struct User
    {
        public string name;
        public int age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }
    partial class Class1
    { 
    public void ICanRun()
        { 
            Console.WriteLine($"I Run");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Textbook MyBook = new Textbook();
            //Console.WriteLine(Convert.ToString(MyBook.electronic_analogue()));
            //Console.WriteLine(Convert.ToString(((IBook)MyBook).electronic_analogue()));

            Journal MyJournal = new Journal();
            Magazine MyMagazine = new Magazine();
            //bool b = MyBook is Print_Edition;
            //Print_Edition d = MyBook as Print_Edition;
            //Console.WriteLine($"{b} - {d}");
            //bool x = MyJournal is IPerson;
            //IPerson y = MyJournal as IPerson;
            //Console.WriteLine($"{x} - {y}");
            //Console.WriteLine();
            //Console.WriteLine($"{MyMagazine.ToString()}");
            //Printer MyPrint = new Printer();
            //Console.WriteLine();
            //object[] mas = { MyJournal, MyMagazine, MyBook };
            //for (int i = 0; i < mas.Length; i++)
            //    Console.WriteLine($"{MyPrint.IAmPrinting(mas[i] as Print_Edition)}");
            library Library = new library();
            Library.info();
            Library.Add(MyJournal);
            Library.Add(MyMagazine);
            Library.Add(MyBook);
            Console.ReadKey();

        }
    }
}

