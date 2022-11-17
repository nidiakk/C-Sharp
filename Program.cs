using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS2022_10_4_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {   Random rn = new Random();
            while (true)
            {
                double h = 0;
                double t = 0;
                double g = 9.80665;
                try
                {
                    checked
                    {
                        
                        //1.
                        //Console.Write("Input 自由落體之秒數(Second)=?");
                        //t = double.Parse(Console.ReadLine());
                        //2.
                        Console.WriteLine(System.DateTime.Now);
                        t= 10*rn.NextDouble();

                        Console.Write("Input 自由落體之秒數(Second)=?"+Math.Round(t,1));
                        h = (1.0 / 2.0) * g *Math.Pow(t,2);

                        Console.BackgroundColor= ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("   吊橋高度(h)="+Math.Round(h,2)+"公尺");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        System.Threading.Thread.Sleep(rn.Next(500,5001));
                        //System.Threading.Thread.Sleep(rn.Next(2000));

                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex);//顯示錯誤提示
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    Console.WriteLine("Try again !!");
                    Console.WriteLine();
                    //Console.ReadKey();
                }
            }


        }
    }
}
