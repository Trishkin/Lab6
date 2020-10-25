using System;

namespace Лаба_6
{
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Textbook MyBook = new Textbook();
            Console.WriteLine(Convert.ToString(MyBook.electronic_analogue()));
            Console.WriteLine(Convert.ToString(((IBook)MyBook).electronic_analogue()));

            Journal MyJournal = new Journal();
            Magazine MyMagazine = new Magazine();
            bool b = MyBook is Print_Edition;
            Print_Edition d = MyBook as Print_Edition;
            Console.WriteLine($"{b} - {d}");
            bool x = MyJournal is IPerson;
            IPerson y = MyJournal as IPerson;
            Console.WriteLine($"{x} - {y}");
            Console.WriteLine();
            Console.WriteLine($"{MyMagazine.ToString()}");
            Printer MyPrint = new Printer();
            Console.WriteLine();
            object[] mas = { MyJournal, MyMagazine, MyBook };
            for (int i = 0; i < mas.Length; i++)
                Console.WriteLine($"{MyPrint.IAmPrinting(mas[i] as Print_Edition)}");
            Console.ReadKey();

        }
    }
}

