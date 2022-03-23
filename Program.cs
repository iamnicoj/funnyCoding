using System;

namespace CalculatorProgram
{
   
    class Program
    {
        private static List<string> processed;
        private static int highestPalindrome;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer (or exit):");
            var test = Console.ReadLine();

            while(test != "exit")
            {
                Console.WriteLine("Highest Palindrome:");                
                Console.WriteLine(solution(test));
                
                Console.WriteLine("Enter integer (or exit):");
                test = Console.ReadLine();
            }
        }

        public static string solution(string s){

            processed= new List<string>();
            highestPalindrome = -1;

            processString("", s);
            if(highestPalindrome != -1)
                return highestPalindrome.ToString();

            return "";
        }

        private static void processString(string root, string pending)
        {
            if (processed.IndexOf(root + pending)> -1){
                return;
            }

            processed.Add(root);
            
            if (root != null && root.Length > 0 && 
               root.SequenceEqual(root.Reverse()) && 
               Int32.Parse(root) > highestPalindrome)
            {
                    highestPalindrome = Int32.Parse(root);
            }

            // Go through a string permutation for peding string
            for(int i = 0; i < pending.Length; i++)
            {
                var left = pending.Substring(0, i );
                var right = pending.Substring(i + 1);
                processString(root + pending[i], left + right);
            }
            return;
        }
    }
}




