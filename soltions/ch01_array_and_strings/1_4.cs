using System.Reflection.Metadata;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace soltions
{
    // question:
    /*
        Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation
        is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
        EXAMPLE
        Input: Tact Coa
        Output: True (permutations: "taco cat", "atco eta", etc.)
        
        book hints :

        #106  : You do not have to-and should not-generate all permutations. This would be very inefficient
        #121  : What characteristics would a string that is a permutation of a palindrome have?
        #134  : Have you tried a hash table? You should be able to get this down to 0( N) time. 
        #136  : Can you reduce the space usage by using a bit vector?  (i don't use it)
    */
    class Ch1_1_4
    {

        // so it's take O(n)
        // we will ignore all spaces, and cancel CaseSensitive
        public static bool CheckPalindeomPermutation_V1(string s){
            if(s == null || s.Length == 0) return false;
            s = s.ToLower();
            int num_of_spaces = 0;
            Dictionary<char,int> dict_chars = new Dictionary<char, int>();
            foreach(char c in s) //O(n)
            {
                if(c != ' ')
                {
                    if(dict_chars.ContainsKey(c))
                        dict_chars[c]++;
                    else
                        dict_chars[c] = 1;
                }
                else
                    num_of_spaces++;
            }

            if((s.Length - num_of_spaces) %2 == 1) //if odd
            {
                int checker = 0;
                foreach(KeyValuePair<char,int> item in dict_chars){  //O(n)
                    if(item.Value %2 == 1)
                    {
                        checker++;
                        if(checker > 1) return false;
                    }
                }   
            }
            else //it's even
            {
                foreach(KeyValuePair<char,int> item in dict_chars){  //O(n)
                    if(item.Value %2 == 1) return false; 
                }   
            }
            return true;
        }


        
        static void Main(string[] args)
        {
            String s = "tttto";

            /* #resion O(n) implementation V1 */ 
            Console.WriteLine(CheckPalindeomPermutation_V1(s));
            /* #endregion */

            System.Console.WriteLine("**********************");
        
        }
    }
}