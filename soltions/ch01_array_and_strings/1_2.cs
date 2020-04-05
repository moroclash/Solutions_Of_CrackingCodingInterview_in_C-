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
        Check Permutation: Given two strings, write a method to decide if one is a permutation of the other

        book hints :

        #1   : Describe what it means for two strings to be permutations of each other. Now, look at
               that definition you provided. Can you check the strings against that definition? 

               Note :(the assuntion here that should  S1.length == S2.length to be one is permutation of other)

        #84  : There is one solution that is 0( N log N) time. Another solution uses some space,but is O(N) time
        #122 : Could a hash table be useful?
        #131 : Two strings that are permutations should have the same characters, but in different
               orders. Can you make the orders the same?
    */
    class Ch1_1_2
    {

        //This function take 2 inputs so asume s1=a and s2=b 
        // so it's take O(n log(n))
        public static bool IsHasAnyPermutation_V1(string s1, string s2){
            if(s1.Length != s2.Length) return false;
            char[] s1_chars = s1.ToCharArray();
            char[] s2_chars = s2.ToCharArray();
            Array.Sort(s1_chars);
            Array.Sort(s2_chars);
            for(int i=0; i<s1.Length; i++)
            {
                if(s1_chars[i] != s2_chars[i])
                    return false;   
            }
            return true;
        }

        //Using O( a * b )
        //here we will use hashTable to access in O(1)
        public static bool IsHasAnyPermutation_V2(string s1 , string s2){
            if(s1.Length != s2.Length) return false;
            Dictionary<char,int> chars = new Dictionary<char, int>();
            foreach (char c in s1)  //O(n)
               if(chars.ContainsKey(c))
                    chars[c] += 1;
                else
                    chars[c] = 1;   
            
            foreach (char c in s2)  //O(n)
            {
              if(!chars.ContainsKey(c))
                return false;
              else{
                  chars[c] -=1;
                  if(chars[c] <0 )
                    return false;
              }
            }
            return true;
        }




        static void Main(string[] args)
        {
            String s1= "edcbac";
            String s2 = "abccde";
            
            /* #resion O(a^2 * b) implementation V1 */ 
            Console.WriteLine(IsHasAnyPermutation_V1(s1,s2));
            /* #endregion */

            System.Console.WriteLine("**********************");
        
            /* #resion O(a * b) implementation V2 */ 
            System.Console.WriteLine(IsHasAnyPermutation_V2(s1,s2));
            /* #endregion */
        }
    }
}