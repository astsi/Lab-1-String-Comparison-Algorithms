using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace PAA_Lab1_15719
{
    public static class ApplyingAlgorithms
    {
        public static void ApplyRabinKarp(String fullText, String pattern, String pathDst)
        {
            
            Stopwatch s = new Stopwatch();
            s.Start();

            //primena algoritma
            int[] alg = Algorithms.RabinKarp(fullText, pattern);

            //upis u fajl
            using (StreamWriter sw = File.CreateText(pathDst))
            {
                for (int i = 0; i < alg.Length; i++)
                {
                    sw.Write(alg[i]);
                    sw.Write(" ");
                }
            }
            s.Stop();
            Console.WriteLine("Rabin Karp for pattern" + pattern.Length + ": " + s.Elapsed);

        }

        public static void ApplyKMP(String fullText, String pattern, String pathDst)
        {
           
            Stopwatch s = new Stopwatch();

            s.Start();

            //primena algoritma

            int[] alg = Algorithms.KMP(fullText, pattern);

            //upis u fajl
            using (StreamWriter sw = File.CreateText(pathDst))
            {
                for (int i = 0; i < alg.Length; i++)
                {
                    sw.Write(alg[i]);
                    sw.Write(" ");
                }
            }
            s.Stop();
            Console.WriteLine("Knut Morris Prat for pattern" + pattern.Length + ": " + s.Elapsed);
        }

        public static void ApplySoundEx(String fullText, String pattern, String pathDst)
        {
            Algorithms a = new Algorithms();
            Stopwatch s = new Stopwatch();

            s.Start();

            List<String> listOfWords = Algorithms.StrExtract(fullText);

            //upis u fajl i primena algoritma

            using (StreamWriter sw = File.CreateText(pathDst))
            {
                for (int i = 0; i < listOfWords.Count; i++)
                {
                    String value = a.Compare(listOfWords[i], pattern);
                    if (value != "")
                    {
                        sw.Write(value);
                        sw.Write(" ");
                    }
                }
            }
                s.Stop();
                Console.WriteLine("SoundEx for pattern" + pattern.Length + ": " + s.Elapsed);
        }

        public static void ApplyLevenstein(String fullText, String pattern, String pathDst)
        {
            Stopwatch s = new Stopwatch();

            s.Start();

            List<String> listOfWords = Algorithms.StrExtract(fullText);

            //upis u fajl i primena algoritma

            using (StreamWriter sw = File.CreateText(pathDst))
            {
                for (int i = 0; i < listOfWords.Count; i++)
                {
                    int value = Algorithms.Levenstein(listOfWords[i], pattern);
                    if (value <= 3)
                    {
                        sw.Write(listOfWords[i]);
                        sw.Write(" ");
                    }
                }
            }
            s.Stop();
            Console.WriteLine("Levenstein for pattern" + pattern.Length + ": " + s.Elapsed);
        }
    }
}
