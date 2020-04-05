using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace soltions
{
    // question:
    /*
        Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
        cannot use additional data structures?
     */
    class Ch1_1_1
    {
        //Use Brute Force Algo 
        //This function take O(n^2) 
        public static bool IsUninqe_V1(string s){
            for(int i=0; i<s.Length; i++){ // will repate 1 + 2 + 3 + ... + n = n(n+1) /2 = n^2  
                for(int j=i+1; j<s.Length; j++) 
                    if( s[i].Equals(s[j]))
                        return false;
            }            
            return true;
        }

        //Using O( n log(n) )
        //here we will sort the string and check if s[i] == s[i+1]
        public static bool IsUninqe_V2(string s){
            
            char[] arr = s.ToCharArray();
            Array.Sort(arr); // O( n log(n) ) 
            
            for(int i=0; i<s.Length-1; i++)
                if(arr[i]==arr[i+1]) 
                    return false; 
            return true;
        }


        //Use another method that take O(n)
        //we will get set(s) and chaeck if set(s).length == s.length
        public static bool IsUninqe_V3(string s){
            HashSet<char> set = new HashSet<char>(s.ToCharArray());  //O(n)
            if(set.Count != s.Length)
                return false;         
            return true;
        }


        // we can assume that S is AscII so every char should be one of 128 unique char 
        // so we will init arr[128] and set True inside Char index
        // it will take O(n) but if we assume that unique chars is 128 only
        // so loop don't exceed 128 so it takes O(1)
        public static bool IsUninqe_V4(string s){
            if(s.Length > 128) return false;
            bool[] checker = new bool[128];
            
            for(int i=0; i<s.Length; i++){
                char c = s[i];
                if(checker[Convert.ToInt16(c)])
                    return false;
                else
                    checker[Convert.ToInt16(c)] = true;       
            }
            return true;
        }

        static void Main(string[] args)
        {
            String non_unique = "hellow";
            String unique = "abecd";
            
            /* #resion O(n^2) implementation V1 */ 
            Console.WriteLine(IsUninqe_V1(non_unique));
            Console.WriteLine(IsUninqe_V1(unique));
            /* #endregion */

            System.Console.WriteLine("**********************");

            /* #resion O(n log(n) ) V2 */
            Console.WriteLine(IsUninqe_V2(non_unique));
            Console.WriteLine(IsUninqe_V2(unique));
            /* #endresion */

            System.Console.WriteLine("**********************");

            /* #resion O(n) V3 */
            Console.WriteLine(IsUninqe_V3(non_unique));
            Console.WriteLine(IsUninqe_V3(unique));
            /* #endresion */
    
            System.Console.WriteLine("**********************");

            /* #resion O(1) V4 */
            Console.WriteLine(IsUninqe_V4(non_unique));
            Console.WriteLine(IsUninqe_V4(unique));
            /* #endresion */
        }
    }
}