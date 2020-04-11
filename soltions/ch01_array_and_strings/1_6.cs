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
        String Compression: Implement a method to perform basic string compression using the counts
        of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
        "compressed" string would not become smaller than the original string, your method should return
        the original string. You can assume the string has only uppercase and lowercase letters (a - z)

        book hints :

        #92  : Do the easy thing first. Compress the string, then compare the lengths.
        #110 : Be careful that you aren't repeatedly concatenating strings together.
               This can be very inefficient
    */
    class Ch1_1_6
    {
        // so it's take O(n) where n is the length of string 
        public static string CompressString_v1(string s){
            if(s == null || s.Length == 0) return "";
            /*
              here exist tricky note the StringBuilder will double his size every time complete
              so if we have checked the number of non-compressed chars we can initialize StringBuilder
              and avoid the duplication 
            */
            StringBuilder tem = new StringBuilder();
            int count = 0;
            int count_of_not_compressed = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if(i != s.Length-1 && s[i] == s[i+1]){
                    count++;
                }
                else{
                    tem.Append($"{s[i]}{count+1}");
                    count_of_not_compressed++;
                    count = 0;
                }
            }
            if(count_of_not_compressed == s.Length) return s;
            return tem.ToString();
        }


        
        static void Main_6(string[] args)
        {
            String s = "abcdeaf";

            /* #resion O(n) implementation V1 */ 
            Console.WriteLine(CompressString_v1(s));
            /* #endregion */

            System.Console.WriteLine("**********************");
        
        }
    }
}