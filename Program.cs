using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace vs2022_4_1
{
    internal class Program
    {   static Thread threadA, threadB, threadC;
        static Random RN = new Random();
        static byte A, B, C, Nth;
        static int SleepTime;

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Press Y(y) for Continue Else for No？ Nth？ Max SleepTime(ms)？");
                    string[]Line=Console.ReadLine().Split(' ');
                    Nth = Byte.Parse(Line[1]);//Byte:0~255
                     SleepTime=int.Parse(Line[2]);
                    if (Line[0] == "y" || Line[0] == "Y")
                    {
                        A=0; B=0; C=0;
                        threadA = new System.Threading.Thread(new System.Threading.ThreadStart(IMA));
                        threadB = new Thread(new ThreadStart(IMB));
                        threadC = new Thread(new ThreadStart(IMC));
                        threadA.Start();
                        threadB.Start();
                        threadC.Start();
                    }
                    else return;
                }
           catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    Console.ReadKey();
                }
             }
        }
        
        private static void IMA()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(RN.Next(SleepTime));
                A++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("資一甲("+A+"):"+System.DateTime.Now);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                if (A == Nth)
                {
                    threadB.Abort(); threadC.Abort();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Winner：資一甲");
                    Console.ForegroundColor = ConsoleColor.White;
                    threadA.Abort();
                    
                }
                
            }
        }

        private static void IMB()
        {
            while (true)
            {
                Thread.Sleep(RN.Next(SleepTime));
                B++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("資一乙(" + B + "):" + System.DateTime.Now.ToLongTimeString().ToString());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                if (B == Nth)
                {
                    threadA.Abort(); threadC.Abort();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Winner：資一乙" );
                    Console.ForegroundColor = ConsoleColor.White;
                    threadB.Abort();
                }
            }
        }
        private static void IMC()
        {
            while (true)
            {
                Thread.Sleep(RN.Next(SleepTime));
                C++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("資一丙(" + C + "):" + System.DateTime.Now.Hour+ ":"+DateTime.Now.Minute+ ":"+DateTime.Now.Second);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                if (C == Nth)
                {
                    threadA.Abort(); threadB.Abort();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Winner：資一丙");
                    Console.ForegroundColor = ConsoleColor.White;
                    threadC.Abort();
                }
            }
        }
    }
}
