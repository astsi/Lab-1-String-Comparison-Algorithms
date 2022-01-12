using System;
using System.Collections.Generic;
using System.Text;

namespace PAA_Lab1_15719
{
    public class Algorithms
    {
        public Algorithms()
        {

        }
        // Rabin-Karp
        public static int[] RabinKarp(string text, string pattern)
        {
            List<int> retVal = new List<int>();
            int tHash = 0;
            int pHash = 0;
            int Q = 100007;
            int D = 256;

            for (int i = 0; i < pattern.Length; ++i)
            {
                tHash = (tHash * D + text[i]) % Q;
                pHash = (pHash * D + pattern[i]) % Q;
            }

            if (tHash == pHash)
                retVal.Add(0);

            int pow = 1;

            for (int k = 1; k <= pattern.Length - 1; ++k)
                pow = (pow * D) % Q;

            for (int j = 1; j <= text.Length - pattern.Length; ++j)
            {
                tHash = (tHash + Q - pow * text[j - 1] % Q) % Q;
                tHash = (tHash * D + text[j + pattern.Length - 1]) % Q;

                if (tHash == pHash)
                    if (text.Substring(j, pattern.Length) == pattern)
                        retVal.Add(j);
            }

            return retVal.ToArray();
        }

        //Knut-Morris-Pratt
        public static void ComputeKMPArray(String pattern, int[] patternArray )
        {
            int m = pattern.Length;
            int len = 0;
            int i = 1;
            patternArray[0] = 0;

            while(i< m)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    patternArray[i] = len;
                    i++;
                }
                else
                {
                    if (len!= 0)
                    {
                        len = patternArray[len - 1];
                    }
                    else
                    {
                        patternArray[i] = 0;
                        i++;
                    }
                }
                
            }
        }

        public static int[] KMP(String text, String pattern )
        {
            List<int> retVal = new List<int>();
            int M = pattern.Length;
            int N = text.Length;
            int[] array = new int[M];

            int i = 0;
            int j = 0;

            ComputeKMPArray(pattern, array);

            while(i < N)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    retVal.Add(i - j);
                    j = array[j - 1];
                }
                else if (i < N && pattern[j] != text[i])
                {
                    if (j != 0)
                        j = array[j - 1];
                    else
                        i++;
                }
            }

            return retVal.ToArray();
        }

        //SoundEx algorithm
       public string GetSoundEx(String value)
        {
            value = value.ToUpper();
            StringBuilder soundEx = new StringBuilder();

            foreach(char ch in value)
            {
                if (char.IsLetter(ch))
                    AddCharacter(soundEx, ch);             
            }

            RemovePlaceholders(soundEx);
            FixLength(soundEx);
            return soundEx.ToString();
        }

        private void AddCharacter(StringBuilder soundEx, char ch)
        {
            if (soundEx.Length == 0)
                soundEx.Append(ch);
            else
            {
                String code = GetSoundExDigit(ch);
                if (code != soundEx[soundEx.Length - 1].ToString())
                    soundEx.Append(code);
            }
        }

        private String GetSoundExDigit(char ch)
        {
            String chString = ch.ToString();

            if ("BFPV".Contains(chString))
                return "1";
            else if ("CGJKQSXZ".Contains(chString))
                return "2";
            else if ("DT".Contains(chString))
                return "3";
            else if (ch == 'L')
                return "4";
            else if ("MN".Contains(chString))
                return "5";
            else if (ch == 'R')
                return "6";
            else
                return ".";
        }

        private void RemovePlaceholders(StringBuilder soundEx)
        {
            soundEx.Replace(".", "");
        }

        private void FixLength(StringBuilder soundEx)
        {
            int length = soundEx.Length;
            if (length < 4)
                soundEx.Append(new String('0', 4 - length));
            else
                soundEx.Length = 4;
        }

        public String Compare(String value1, String value2)
        {
            int matches = 0;
            String soundEx1 = GetSoundEx(value1);
            String soundEx2 = GetSoundEx(value2);

            for (int i = 0; i < 4; i++)
                if (soundEx1[i] == soundEx2[i])
                    matches++;

            if (matches == 4)
                return value1;
            else
                return "";

        }

        //Words extraction
        public static List<String> StrExtract(String Text)
        {
            
            List<String> extractedStrings = new List<string>();
            int begInd = 0;
            String lastString = "";
            for (int i = 0; i < Text.Length; i++)
            {

                if (!Char.IsLetter(Text[i]) || Char.IsNumber(Text[i]))
                {
                    if (i-1 > 0)

                    if (Char.IsLetter(Text[i - 1]) || Char.IsNumber(Text[i-1]))
                    {
                        lastString = Text.Substring(begInd, (i - begInd));
                        extractedStrings.Add(lastString);
                        begInd = i + 1;
                    }
                    else
                        begInd = i + 1;
                }
       
            }
            return extractedStrings;
        }
        
        //Levenstein algorithm
        public static int Levenstein(String text1, String text2)
        {
            int n = text1.Length;
            int m = text2.Length;
            int[,] dist = new int[n + 1, m + 1];

            if (n==0)
                return m;

            if (m == 0)
                return n;

            for (int i = 0; i<= n; dist[i,0] = i++)
            { }

            for (int j = 0; j <= m; dist[0,j] = j++)
            { }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (text2[j - 1] == text1[i - 1]) ? 0 : 1;

                    dist[i, j] = Math.Min(
                        Math.Min(dist[i - 1, j] + 1, dist[i, j - 1] + 1),
                        dist[i - 1, j - 1] + cost);
                }
            }

            return dist[n, m];
        }

    }
}
