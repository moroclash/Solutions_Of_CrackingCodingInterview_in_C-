
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
        URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
        has sufficient space at the end to hold the additional characters, and that you are given the "true"
        length of the string. (Note: If implementing in Java, please use a character array so that you can
        perform this operation in place.)
        EXAMPLE
        Input: "Mr John Smith ", 13
        Output: "Mr%20John%20Smith"

        book hints :

        #53   : It's often easiest to modify strings by going from the end of the string to the beginning
        #118  : You might find you need to know the number of spaces. Can you just count them?  
    */
    class Ch1_1_3
    {

        // so it's take O(L) where L is length of string without last spaces
        // but here we return a copy of sender string
        public static string ReplaceWightSpaces_V1(string s, int length){
          StringBuilder temp = new StringBuilder();
          for (int i = 0; i < length; i++)   //O(L)
          {
             if(s[i] != ' ')
                temp.Append(s[i]);
             else
                temp.Append("%20");
          }  
          return temp.ToString();
        }


        //here we will replace in sender refrence 
        // O(L)
        public static void ReplaceWightSpaces_V2(char[] s, int length){
          int spaces_cout=0;
          for (int i = 0; i < length; i++)  //O(L)
          {
             if(s[i] == ' ') spaces_cout++; 
          }
        
          int len_of_holding_space = spaces_cout*2;
          int index = s.Length-1;
          for (int i = s.Length-1; i >= len_of_holding_space; i--)   //O(L)
          {
             if(s[i-len_of_holding_space] != ' ')
             {
                s[index] = s[i-len_of_holding_space];
                index--;
             }
             else
             {
                s[index] = '0';
                s[index-1] = '2';
                s[index-2] = '%';
                index -=3;
             }
          } 
        }

        
        static void Main(string[] args)
        {
            String s = " Mr John Smith      ";
            int len = 14;


            /* #resion O(L) implementation V1 */ 
            Console.WriteLine(ReplaceWightSpaces_V1(s, len));
            /* #endregion */

            System.Console.WriteLine("**********************");
        
            /* #resion O(L) implementation V2 */ 
            char[] chars = s.ToCharArray();
            ReplaceWightSpaces_V2(chars, len);
            Console.WriteLine(chars);
            /* #endregion */

            System.Console.WriteLine("**********************");
        }
    }
}