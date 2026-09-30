using Microsoft.VisualBasic;
using System;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

class BachTung_CSLT_JaggedArrays_HomeWork
{
    /* The X company has 3 working groups; group 1 has 5 members, group 2 has 3 members, and group 3 has 6 members.The data stored for each member has an ID number, full name, and completed tasks.An ID identifies each member.
     Select an appropriate data structure to save this info.Then, write functions to perform the following tasks:
     1.Initialize an array with pre-assigned values ​​or values ​​entered from the keyboard.
     2.Print a list of all members.
     3.Print the information on a member when the ID is known.
     4.Print the member with the highest number of completed tasks.
     Create the main program with menus that allow you to select the tasks to be performed.
     Hint: create a jagged array to store these members in the form [id,[name, tasks]].*/
    public static void Main(string[] args)
    {
        string[][,] emps = null;
        init(emps);

        Console.WriteLine("--DANH SACH NHAN VIEN--");

        print_members(emps);
        Console.WriteLine();

        Console.Write("Nhap id nhan vien can tim: ");
        string f_id = Console.ReadLine();

        print_member(emps, f_id);

        string[,] row = search_member(emps, f_id);
        if (row != null)
        {
            Console.WriteLine("--- THONG TIN CUA THANH VIEN THEO ID DA NHAP ---");
            Console.WriteLine($"Id: {row[0, 0]}, Name: {row[0, 1]}, No Tasks: {row[0, 2]}");
        }
        else
            Console.WriteLine("Khong tim thay");

        string[] mve = most_valuable_emp(emps);
        Console.Write("Nhan vien sieng nang nhat: ");
        Console.WriteLine($"Id: {mve[0]}, Name: {mve[1]}, No Tasks: {mve[2]}");

        Console.ReadKey();
    }

    static void init(string[][,] grouplist)
    {
        grouplist[0] = new string[5, 3]
        {
            {"1001","","" },
            {"1002","","" },
            {"1003","","" },
            {"1004","","" },
            {"1005","","" },
        };

        grouplist[1] = new string[3, 3]
        {
            {"2001","","" },
            {"2002","","" },
            {"2003","","" },
        };

        grouplist[2] = new string[6, 3]
        {
            {"3001","","" },
            {"3002","","" },
            {"3003","","" },
            {"3004","","" },
            {"3005","","" },
            {"3006","","" },
        };
    }

    static void print_members(string[][,] emps)
    {
        foreach (string[,] row in emps)
        {
            for (int i = 0; i < row.GetLength(1); i++)
            {
                Console.WriteLine($"Id: {row[i, 0]}, Name: {row[i, 1]}, No Tasks: {row[i, 2]}");
            }
        }
    }
    static void print_member(string[][,] emps, string id)
    {
        bool found = false;
        foreach (string[,] row in emps)
        {
            for (int i = 0; i < row.GetLength(1); i++)
            {
                if (row[i, 0] == id)
                {
                    Console.WriteLine($"Id: {row[i, 0]}, Name: {row[i, 1]}, No Tasks: {row[i, 2]}");
                    found = true;
                }
            }
        }
        if (!found)
            Console.WriteLine($"khong tim thay nhan vien co id ={id}");
    }

    static string[,] search_member(string[][,] emps, string id)
    {
        foreach (string[,] row in emps)
        {
            for (int i = 0; i < row.GetLength(1); i++)
            {
                if (row[i, 0] == id)
                {
                    return row;
                }
            }
        }
        return null;
    }

    static string[] most_valuable_emp(string[][,] emps)
    {
        string[] emp_max_tasks = null;
        int max = 0;
        foreach (string[,] row in emps)
        {
            for (int i = 0; i < row.GetLength(1); i++)
            {
                int tasks = int.Parse(row[i, 2]);
                if (tasks > max)
                {
                    max = tasks;
                    emp_max_tasks = new string[3] { row[i, 0], row[i, 1], row[i, 2] };
                }
            }
        }
        return emp_max_tasks;
    }


}
