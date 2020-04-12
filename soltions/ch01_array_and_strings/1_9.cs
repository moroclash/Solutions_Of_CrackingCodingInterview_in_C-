using System.Diagnostics;
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
        String Rotation:Assumeyou have a method isSubstringwhich checks if oneword is a substring
        of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl 
        using only one call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat"). 

        book hints :
        #34  : If a string is a rotation of another, then it's a rotation at a particular point.
               For example, a rotation of waterbottle at character 3 means cutting waterbottle 
               at character 3 and putting the right half (erbottle) before the left half (wat). 
        
        #88  : We are essentially asking if there's a way of splitting the first string into
               two parts, x and y, such that the first string is xy and the second string is yx.
               For example, x = wat and y = erbottle. The first string is xy = waterbottle.
               The second string is yx = erbottlewat
        
        #104 : Think about the earlier hint. Then think about what happens when you concatenate
               erbottlewat to itself. You get erbottlewaterbottlewat. 

    */
    class Ch1_1_9
    {
        // so it's Runtime is O(n) but space is O(1)  
        public static bool CheckStringRotation_V1(string s1, string s2){
            // s2.contains() == s2.isSubstring()
            if(s1.Length != s2.Length || s2.Contains(s1))
                 return false;
            int index = 0;
            bool flage = false;
            for (int i = 0; i < s1.Length; i++)  //O(n)
            {
                if(s1[i] == s2[index])
                {
                    index++;
                    flage = true;
                }
                else if(flage)
                    return false;
            }             

            for (int i = 0; i < s1.Length-index ; i++) //O(n)
            {
                if(s1[i] != s2[index]) return false;
                index++;   
            }
            return true;
        }

        //this function take Runtime of IsSubstring() == Contains();
        public static bool CheckStringRotation_V2(string s1, string s2){
            if(s1.Length != s2.Length) return false;
            s2 += s2;
            return s2.Contains(s1);
        }

        static void Main(string[] args)
        {
            string s1 = "waterbottel";
            string s2 = "erbottelwat";

            Stopwatch stwa = new Stopwatch();
            stwa.Start();
            /* #resion O(n^2) implementation V1 */ 
            System.Console.WriteLine(CheckStringRotation_V1(s1,s2)); 
            /* #endregion */
            stwa.Stop();
            System.Console.WriteLine($"Time : {stwa.Elapsed.ToString()}");
            stwa.Reset();
            System.Console.WriteLine("**********************");

            System.Console.WriteLine(CheckStringRotation_V2(s1,s2)); 
        }
    }
}