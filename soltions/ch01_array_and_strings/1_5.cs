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
        One Away: There are three types of edits that can be performed on strings: insert a character,
        remove a character, or replace a character. Given two strings, write a function to check if they are
        one edit (or zero edits) away.
        EXAMPLE
        pale, ple -> true
        pales, pale -> true
        pale, bale -> true
        pale, bake -> false  
        
        book hints :

        #23  : Start with the easy thing. Can you check each of the conditions separately? 
        #97  : What is the relationship between the "insert character" option and the "remove character" option?
               Do these need to be two separate checks?
        #130 : Can you do all three checks in a single pass?
    */
    class Ch1_1_5
    {

        // so it's take O(n) where n is the length of small string 
        // we will ignore CaseSensitive
        public static bool CheckOneEdit_V1(string s1, string s2){
            if(s1 == null || s2 == null) return false;
            int abs = Math.Abs(s1.Length - s2.Length);
            if(abs > 1) return false;

            string small = s1.ToLower();
            string big = s2.ToLower();
            if(s1.Length >= s2.Length){
                small = s2.ToLower();
                big = s1.ToLower();
            }

            int index = 0;
            int checker = 0;
            for (int i = 0; i < small.Length; i++) //O(n) where n is length of small string
            {
                if(small[i] != big[index]){
                    if(abs == 0)
                    {
                        checker++;
                        index++;
                    }
                    else
                    {
                        if(small[i] != big[index+1]) return false;
                        else{
                            checker++;
                            index +=2;
                        }
                    }
                }
                else
                {
                    index++;
                }
                if(checker > 1) return false;   
            }            


            return true;
        }


        
        static void Main(string[] args)
        {
            String s1 = "pale";
            String s2 = "bake";

            /* #resion O(n) implementation V1 */ 
            Console.WriteLine(CheckOneEdit_V1(s1,s2));
            /* #endregion */

            System.Console.WriteLine("**********************");
        
        }
    }
}