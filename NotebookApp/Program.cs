using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Notebook
    {
        public static Dictionary<int, Note> notes = new Dictionary<int, Note>();
        private const string KeyFormatExe = "The note dose not exist. Try again";
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello. It is simple Notebook :) To finish enter exit.");
            Console.WriteLine("The functioal is:");
            Console.WriteLine("enter new to create new note");
            Console.WriteLine("enter edit to edit note");
            Console.WriteLine("enter delete to delete note");
            Console.WriteLine("enter show  to show necessary note");
            Console.WriteLine("enter show all to show all notes");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "exit":
                        return;
                    case "new":
                        CreateNewNote();
                        break;
                    case "edit":
                        EditNote();
                        break;
                    case "delete":
                        DeleteNote();
                        break;
                    case "show all":
                        ShowAll();
                        break;
                    case "show":
                        ReadNote();
                        break;
                    default:
                        Console.WriteLine("Unknown command. Try again");
                        break;
                }
            }
        }

        public static void CreateNewNote()
        {
            string sur = RequiredInputField("Enter surname:");
            string name = RequiredInputField("Enter name:");
            string mid = InputField("Enter middle name:"); //!
            string num = RequiredInputNumber("Enter number:");
            string country = RequiredInputField("Enter country:");
            DateTime bth = InputDateField("Enter birthday:");//!
            string org = InputField("Enter organization:");//!
            string spec = InputField("Enter profession:");//!
            string add = InputField("Enter addirion:");//!

            try
            {
                Note n = new Note(sur, name, num, country);
                n.MiddleName = mid;
                n.Birthday = bth;
                n.Org = org;
                n.Specialty = spec;
                n.Addition = add;

                notes.Add(n.Id, n);
                Console.WriteLine("Note added :)");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The note is already exist");
            }

        }
        public static void EditNote()
        {
            if (notes.Count != 0)
            {
                Console.WriteLine("To edit note enter surname and name");
                try
                {
                    Note n = GetCurrentNode();
                    notes.Remove(n.Id);

                    string s = "";
                    while (s != "done")
                    {
                        Console.WriteLine("to edit enter the field: sur, name, mid, num,country,bth (bithday), org, spec, add");
                        Console.WriteLine("to finish enter - done");
                        s = Console.ReadLine();
                        switch (s)
                        {
                            case "sur":
                                Console.WriteLine($"Old Surname: {n.Surname}");
                                n.Surname = RequiredInputField("Enter new:");
                                break;
                            case "name":
                                Console.WriteLine($"Old Name: {n.Name}");
                                n.Name = RequiredInputField("Enter new:");
                                break;
                            case "mid":
                                Console.WriteLine($"Old Middle Name: {n.MiddleName}");
                                n.MiddleName = InputField("Enter new:");

                                break;
                            case "num":
                                Console.WriteLine($"Old Number: {n.Number}");
                                n.Number = RequiredInputField("Enter new:");

                                break;
                            case "country":
                                Console.WriteLine($"Old Country: {n.Country}");
                                n.Country = RequiredInputField("Enter new:");
                                break;
                            case "bth":
                                Console.WriteLine($"Old Bithday: {n.Birthday}");
                                n.Birthday = InputDateField("Enter new:");
                                break;
                            case "org":
                                Console.WriteLine($"Old Organisation: {n.Org}");
                                n.Org = InputField("Enter new:");
                                break;
                            case "spec":
                                Console.WriteLine($"Old speciality: {n.Specialty}");
                                n.Specialty = InputField("Enter new:");
                                break;
                            case "add":
                                Console.WriteLine($"Old add: {n.Addition}");
                                n.Addition = InputField("Enter new:");
                                break;
                            case "done":
                                n.newId(); notes.Add(n.Id, n);
                                Console.WriteLine("Changes saved!");
                                return;
                            default:
                                Console.WriteLine("Unknown command. Try again!");
                                break;
                        }
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine(KeyFormatExe);
                }
            }
            else Console.WriteLine("No notes :(");

        }
        public static void DeleteNote()
        { if (notes.Count != 0)
            {
                Console.WriteLine("To delete note enter surname and name");
                try
                {
                    Note n = GetCurrentNode();
                    notes.Remove(n.Id);
                    Console.WriteLine("Note deleted!");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine(KeyFormatExe);
                }
            }
            else Console.WriteLine("No notes :(");
        }
        public static Note GetCurrentNode()
        {
            string sur = RequiredInputField("Enter surname:");
            string num = RequiredInputField("Enter name:");
            int id = sur.GetHashCode() + num.GetHashCode();
            return notes[id];
        }
        public static void ReadNote()
        {
            if (notes.Count != 0)
            {
                Console.WriteLine("Enter surname and name");
                try
                {
                    Note n = GetCurrentNode();
                    Console.WriteLine(n.ToString());
                    if (!(string.IsNullOrEmpty(n.MiddleName))) Console.WriteLine("Middle Name:" + n.MiddleName);
                    if (!(string.IsNullOrEmpty(n.Country))) Console.WriteLine("Country:" + n.Country);
                    if (n.Birthday != null) Console.WriteLine("Birthday:" + n.Birthday);
                    if (!(string.IsNullOrEmpty(n.Org))) Console.WriteLine("Orgnisation:" + n.Org);
                    if (!(string.IsNullOrEmpty(n.Specialty))) Console.WriteLine("Specialty:" + n.Specialty);
                    if (!(string.IsNullOrEmpty(n.Addition))) Console.WriteLine("Addition:" + n.Addition);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine(KeyFormatExe);
                }
            }
            else Console.WriteLine("No notes :(");



        }
        public static void ShowAll()
        {
            if (notes.Count != 0)
            {
                foreach (var item in notes)
                {
                    Console.WriteLine(item.Value.ToString());
                    Console.WriteLine("----------");
                }
            }
            else Console.WriteLine("No notes :(");
        }

        public static string RequiredInputField(string msg)
        {
            string s = null;
            while (string.IsNullOrEmpty(s))
            {
                Console.WriteLine(msg);
                s = Console.ReadLine();

            }
            return s;
        }
        public static string RequiredInputNumber(string msg)
        {
            int n = 0;
            string s = null;
            while (!(int.TryParse(s, out n)))
            {
                Console.WriteLine(msg);
                s = Console.ReadLine();
              
            }
            return s;
        }

        public static string InputField(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        public static DateTime InputDateField(string msg)
        {

            Console.WriteLine(msg);
            DateTime bth = new DateTime();
            string bthStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(bthStr))
            {
                while (!DateTime.TryParse(bthStr, out bth))
                {
                    Console.WriteLine("Incorrect date format. Try again");
                    bthStr = Console.ReadLine();
                }
            }

            return bth;


        }

    }
}
