using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace PAA_Lab1_15719

{
    class Program
    {
        static void Main(string[] args)
        {
            String fullText;
            String pattern5 = "";
            String pattern10 = "";
            String pattern20 = "";
            String pattern50= "";
            String pathSrc = @"C:\Users\SmartPC\Desktop\PAA\Texts\HexText.txt";

            Console.WriteLine("Hello and Welcome! ");
            Console.WriteLine("To choose HexFile package, press 1 ");
            Console.WriteLine("To choose War and Peace package, press 2 ");
            String str = Console.ReadLine();
            if (str.Contains("1"))
            {
                pathSrc = @"C:\Users\SmartPC\Desktop\PAA\Texts\HexText.txt";
                pattern5 = "6e656"; //"peace";
                pattern10 = "3206e756c6"; //"everything";
                pattern20 = "3206e756c6c612e20536"; //"symmetrically placed";
                pattern50 = "9742e20566573746962756c756d2074656d707573206c69626";

                Console.WriteLine("You have chosen the Hex Text Package. It contains these values: ");
                Console.WriteLine("pattern5: " + pattern5);
                Console.WriteLine("pattern10: " + pattern10);
                Console.WriteLine("pattern20: " + pattern20);
                Console.WriteLine("pattern50: " + pattern50);


            }
            if (str.Contains("2"))
            {
                pathSrc = @"C:\Users\SmartPC\Desktop\PAA\Texts\WarAndPiece.txt";
                pattern5 = "peace";
                pattern10 = "everything";
                pattern20 = "symmetrically placed";
                pattern50 = "This eBook is for the use of anyone anywhere at no";

                Console.WriteLine("You have chosen the War and Peace Package. It contains these values: ");
                Console.WriteLine("pattern5: " + pattern5);
                Console.WriteLine("pattern10: " + pattern10);
                Console.WriteLine("pattern20: " + pattern20);
                Console.WriteLine("pattern50: " + pattern50);
            }
        
            using (StreamReader sr = File.OpenText(pathSrc))
            {
                fullText = sr.ReadToEnd();
            }

            Console.WriteLine("The performances are: ");


            //5 character pattern
            ApplyingAlgorithms.ApplyRabinKarp(fullText, pattern5, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\RK5.txt");
            ApplyingAlgorithms.ApplyKMP(fullText, pattern5, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\KMP5.txt");
            ApplyingAlgorithms.ApplySoundEx(fullText, pattern5, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\SoundEx5.txt");
            ApplyingAlgorithms.ApplyLevenstein(fullText, pattern5, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\Levenstein5.txt");

            //10 character pattern
            ApplyingAlgorithms.ApplyRabinKarp(fullText, pattern10, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\RK10.txt");
            ApplyingAlgorithms.ApplyKMP(fullText, pattern10, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\KMP10.txt");
            ApplyingAlgorithms.ApplySoundEx(fullText, pattern10, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\SoundEx10.txt");
            ApplyingAlgorithms.ApplyLevenstein(fullText, pattern10, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\Levenstein10.txt");
            
            //20 character pattern
            ApplyingAlgorithms.ApplyRabinKarp(fullText, pattern20, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\RK20.txt");
            ApplyingAlgorithms.ApplyKMP(fullText, pattern20, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\KMP20.txt");

            //50 character pattern
            ApplyingAlgorithms.ApplyRabinKarp(fullText, pattern50, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\RK50.txt");
            ApplyingAlgorithms.ApplyKMP(fullText, pattern50, @"C:\Users\SmartPC\Desktop\PAA\Texts\AfterFilters\KMP50.txt");
            
        }

    }
}
