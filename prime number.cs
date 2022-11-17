using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022_3_17_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Eratosthenes PN = new Eratosthenes();
            PN.Create();//使用這個方法
            
            while (true)
            {
                try
                {
                    Console.WriteLine("\n\n" + DateTime.Now);
                    Console.Write("[A]Factorial[？？] [B]How many prime number[? ?] [C]Prime Number[？] [E]Eratostosnes[？] ");//可用C 100,000測試(正確答案為:1299721)
                    string[] Line = Console.ReadLine().Split(' ');
                    if (Line[0] == "") return;
                    string which = Line[0];
                    int start, last, temp;
                    double StartTime, EndTime;
                    checked
                    {
                        switch (which)
                        {
                            case "A":
                                start = int.Parse(Line[1]);
                                last = int.Parse(Line[2]);
                                if (start > last)  //Exchange start and last
                                {
                                    temp = last;
                                    last = start;
                                    start = temp;
                                }
                                //2.Method / Function / SubRoutine
                                //F(X,Y) = X^2 + X*Y + Y^2
                                //F(int X, int Y) = X^2 + X*Y + Y^2
                                //F(2,3) = 19
                                for (int n = start; n <= last; n++)
                                {
                                    if (Factorial(n) == -1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(n + "！= " + "N!之N值須 >= 0");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else Console.WriteLine(n + "！= " + Factorial(n));

                                }
                                break;
                            case "B":
                                Console.WriteLine("Prime Number？？(Between two Number)1 7919");
                                Console.WriteLine("Prime Number？？(Between two Number)2147400000 2147483646");
                                Console.WriteLine("Prime Number？？(Between two Number)2140000000 2147483646");
                                string[] two = Console.ReadLine().Split(' ');
                                if (two[0] == "") break;
                                int X = int.Parse(two[0]);
                                int Y = int.Parse(two[1]);

                                StartTime = DateTime.Now.TimeOfDay.TotalSeconds;
                                int no = 0;
                                for (int i = X; i < Y; i++)
                                {
                                    if (PrimeYN(i))
                                    {
                                        no++;
                                        Console.WriteLine("P" + no + "= " + i);
                                    }
                                }
                                EndTime = DateTime.Now.TimeOfDay.TotalSeconds;
                                Console.WriteLine("兩數間共 " + no + "個質數;" + "計時：" + Math.Round(EndTime - StartTime, 3) + " 秒");

                                break;
                            case "C":
                                // case "c": ←如果想要大小寫不區分，可以加上這行
                                decimal nth = 0;   //nth prime number 目前做的回數
                                decimal NN = 0;    //Natural Number 自然數ex:1,2,3,4...
                                decimal Number = int.Parse(Line[1]);    // number of prime Number 做幾次

                                StartTime = DateTime.Now.TimeOfDay.TotalSeconds;
                                while (nth < Number)
                                {
                                    //if (PrimeYesNo((int)NN))//用這個方法跑完質數會很慢
                                    if (PrimeYN((int)NN))
                                    {
                                        nth++;
                                        Console.WriteLine("P" + nth + "= " + NN);
                                    }
                                    NN++;
                                }
                                EndTime = DateTime.Now.TimeOfDay.TotalSeconds;
                                Console.WriteLine("計算 " + Number + "個質數計：" + Math.Round(EndTime - StartTime, 3) + " 秒");

                                break;
                            case "E":
                                StartTime = DateTime.Now.TimeOfDay.TotalSeconds;

                                int number = int.Parse(Line[1]);
                                int[] PrimeNo = new int[number + 1];// number + 1 是為了讓 int[1] 就放第1個數值(較直覺)，不會像一般都用int[0]放第1個數值。
                                PrimeNo[1] = 2; PrimeNo[2] = 3; PrimeNo[3] = 5; PrimeNo[4] = 7;
                                int N = 11;
                                int np, SqaueRoot;
                                Console.WriteLine("P1=2\n" + "P2=3\n" + "P3 = 5\n" + "P4 = 7\n");

                                for (int n = 5; n <= number; n++)// 因為PrimeNo[]值放到PrimeNo[4]而已，所以n從5開始

                                {
                                    SqaueRoot = (int)Math.Sqrt(N) + 2;
                                    np = 1;
                                    while (SqaueRoot >= PrimeNo[np])
                                    {
                                        if (N % PrimeNo[np] == 0)
                                        {
                                            N++;
                                            np = 1;
                                        }
                                        else np++;
                                    }
                                    PrimeNo[n] = N;
                                    Console.WriteLine("P" + n + "=" + PrimeNo[n]);
                                    N++;
                                }

                                EndTime = DateTime.Now.TimeOfDay.TotalSeconds;
                                Console.WriteLine("計算" + number + "個質數計" + Math.Round(EndTime - StartTime, 3) + "秒");

                                break;

                            default:
                                return; //break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    Console.WriteLine("Press any key for Continue(Exit)");
                    //Console.ReadKey();
                }
            }
        }

        static bool PrimeYesNo(decimal X)
        {
            //3.
            if (X <= 1) return false;
            else if (X == 2) return true;
            else if (X % 2 == 0) return false;
            else   //X > 2
            {
                //for (decimal i = 3; i < (decimal)Math.Pow((double)X,1.0/2.0); i += 2)
                //for (decimal i = 3; i < (decimal)Math.Sqrt((double)X); i += 2)


                for (decimal i = 3; i * i <= X; i += 2)//每次都要算一次 i * i <= X 並判斷，跑完需要很久時間
                {
                    if (X % i == 0) return false;
                }
                return true; // is prime Number
            }
        }
        static bool PrimeYN(int X)
        {
            //3.
            if (X <= 1) return false;
            else if (X == 2) return true;
            else if (X % 2 == 0) return false;
            else   //X > 2
            {
                //for (decimal i = 3; i < (decimal)Math.Pow((double)X,1.0/2.0); i += 2)
                //for (decimal i = 3; i < (decimal)Math.Sqrt((double)X); i += 2)
                int SqareRoot = (int)Math.Sqrt(X) + 2;   //←比起PrimeYesNo，不用每次都算一次i * i <= X

                for (int i = 3; i < SqareRoot; i += 2)
                {
                    if (X % i == 0) return false;
                }
                return true; // is prime Number
            }
        }
        static decimal Factorial(int X)
        {
            if (X < 0) return -1;
            else if (X == 0 || X == 1) return 1;
            else
            {
                decimal F = 1;
                for (int i = X; i > 0; i--)
                {
                    F *= i; //F = F * i;
                }
                return F;
            }
        }

        class Eratosthenes
        {
            public int[] PrimeNo = new int[100001];

            public void Create()
            {
                PrimeNo[1] = 2; PrimeNo[2] = 3; PrimeNo[3] = 5; PrimeNo[4] = 7;
                int N = 11;
                int np, SqaueRoot;
                Console.WriteLine("P1=2\n" + "P2=3\n" + "P3 = 5\n" + "P4 = 7\n");

                for (int n = 5; n <= 100000; n++)// 因為PrimeNo[]值放到PrimeNo[4]而已，所以n從5開始

                {
                    SqaueRoot = (int)Math.Sqrt(N) + 2;
                    np = 1;
                    while (SqaueRoot >= PrimeNo[np])
                    {
                        if (N % PrimeNo[np] == 0)
                        {
                            N++;
                            np = 1;
                        }
                        else np++;
                    }
                    PrimeNo[n] = N;
                    Console.WriteLine("P" + n + "=" + PrimeNo[n]);
                    N++;
                }
                Console.WriteLine("PrimeNo[1000]=" + PrimeNo[1000]);
                Console.WriteLine("PrimeNo[100000]=" + PrimeNo[100000]);
                Console.WriteLine("(int)PrimeNo[100000]^2 =" + PrimeNo[100000] * PrimeNo[100000]);//數值會溢位(超過int能負荷的大小)，故結果會呈現錯誤答案
                Console.WriteLine("(long)PrimeNo[1000]^2 =" + PrimeNo[100000] * (long)PrimeNo[100000]);
            }
            public bool Test(int N)
            {
                int ptr = 1;
                if (N < 2) return false;
                else if (N == 2) return true;
                else if (N % 2 == 0) return false;
                else
                {
                    int SRoot = (int)Math.Sqrt(N) + 2;
                    while (SRoot >= PrimeNo[SRoot])
                    {
                        if (N % PrimeNo[SRoot] == 0) return false;
                        else ptr++;
                    }
                }
                return true;
            }



        }
    }

}
