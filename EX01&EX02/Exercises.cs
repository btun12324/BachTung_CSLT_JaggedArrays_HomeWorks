using System;

class BachTung_CSLT_JaggedArrays_HomeWork
{
    /*1.Create a jagged array and initialize it using the following values for its rows and columns; Then, display it.
        1 1 1 1 1
        2 2
        3 3 3 3
        4 4

    2.Create a Jagged Array with random integer numbers (or by user input) by getting the number of rows and columns from the user and printing the data in the array to the user. Then, create functions to implement following tasks:
            1.Print the biggest number of each row and the largest number of the whole array.
            2.Sort values ascending of each row.
            3.Print items of the array that are prime.
            4.Search and print all positions of a number (enter from the user).*/

    public static void Main(string[] args)
    {
        //EX_01();

        EX_02();

        Console.ReadKey();
    }

    static void InMang(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write(arr[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void SapXepMang(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Array.Sort(arr[i]);
        }
    }

    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static void InSoNguyenTo(int[][] arr)
    {
        Console.Write("Cac so nguyen to trong mang: ");
        bool coSoNguyenTo = false;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (IsPrime(arr[i][j]))
                {
                    Console.Write(arr[i][j] + " ");
                    coSoNguyenTo = true;
                }
            }
        }
        if (!coSoNguyenTo) Console.Write("Mang khong co so nguyen to");
        Console.WriteLine();
    }

    public static void TimSoLonNhat(int[][] arr)
    {
        int maxToanMang = int.MinValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Length == 0) continue;

            int maxDong = arr[i][0];
            for (int j = 1; j < arr[i].Length; j++)
            {
                if (arr[i][j] > maxDong) maxDong = arr[i][j];
            }

            Console.WriteLine($"So lon nhat dong la {i}: {maxDong}");
            if (maxDong > maxToanMang) maxToanMang = maxDong;
        }
        Console.WriteLine($"So lon nhan toan mang la: {maxToanMang}");
    }

    public static void TimKiemViTri(int[][] arr, int soCanTim)
    {
        bool kt = false;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] == soCanTim)
                {
                    Console.WriteLine($"Da tim thay so tai Dong {i}, Cot {j}");
                    kt = true;
                }
            }
        }
        if (!kt)
        {
            Console.WriteLine("!!!Khong tim thay so nay trong mang!!!");
        }
    }

    static void EX_01()
    {
        Console.WriteLine("-- Bai tap 1: --");

        int[][] mainarr =
        {
            new int[] {1, 1, 1, 1, 1},
            new int[] {2, 2},
            new int[] {3, 3, 3, 3},
            new int[] {4, 4}
        };

        InMang(mainarr);

        Console.WriteLine();
    }

    static void EX_02()
    {
        Console.WriteLine("-- Bai Tap 2: --");

        Console.Write("Nhap so dong: ");
        int arrRow = int.Parse(Console.ReadLine());

        int[][] mang = new int[arrRow][];
        Random rand = new Random();

        for (int i = 0; i < arrRow; i++)
        {
            Console.WriteLine($"Nhap so cot cho dong {i}: ");
            int arrColumn = int.Parse(Console.ReadLine());

            mang[i] = new int[arrColumn];

            for (int j = 0; j < arrColumn; j++)
            {
                mang[i][j] = rand.Next(1, 201);
            }
        }

        Console.WriteLine("Mang vua duoc tao: ");
        InMang(mang);
        Console.WriteLine();

        Console.WriteLine("1. tim max theo dong va max toan mang");
        TimSoLonNhat(mang);
        Console.WriteLine();

        Console.WriteLine("2. Sap xep tang dan theo dong");
        SapXepMang(mang);
        InMang(mang);
        Console.WriteLine();

        Console.WriteLine("3. Tim so nguyen to");
        InSoNguyenTo(mang);
        Console.WriteLine();

        Console.WriteLine("4. Tim vi tri cua so duoc nhap vao");
        Console.Write("Nhap so can tim vi tri: ");
        int f_num = int.Parse(Console.ReadLine());

        TimKiemViTri(mang, f_num);
        Console.WriteLine();

        Console.WriteLine("KET THUC CHUONG TRINH");
    }


}