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
        Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
        bytes, write a method to rotate the image by 90 degrees. Can you do this in place? 

        book hints :

        #51  : Try thinking about it layer by layer. Can you rotate a specific layer?
        #100 : Rotating a specific layer would just mean swapping the values in four arrays. If you were
               asked to swap the values in two arrays, could you do this? Can you then extend it to four
               arrays? 

    */
    class Ch1_1_7
    {
        // so it's Runtime is O(n^2) but space is O(n^2)  
        public static int[,] RotatMatrix90_v1(int[,] M){
            if(M == null || M.Rank != 2 || M.GetLength(0) != M.GetLength(1) ) return new int[1,1];
            int n = M.GetLength(0);
            int[,] temp = new int[n,n];
            for (int i = 0; i < n; i++) //O(n)
            {
                for (int j = 0; j < n; j++) //O(n)
                {
                    temp[j,n-i-1] = M[i,j];   
                }   
            }
            return temp;            
        }


        // so it's Runtime O(n^2) but more efficient in run time and Space is O(1) 
        public static int[,] RotatMatrix90_v2(int[,] M){
            if(M == null || M.Rank != 2 || M.GetLength(0) != M.GetLength(1) ) return new int[1,1];
            int n = M.GetLength(0);
            int temp1,temp2;
            int ni,nj,tem_index;
            for (int i = 0; i < n/2; i++) //O(n/2)
            {
                for (int j = i; j < n-i-1; j++) //O(n)
                {
                    //replace 1 cill
                    ni =j;  nj = n-1-i;
                    temp1 = M[ni,nj]; 
                    M[ni,nj] = M[i,j];

                    //replace 2 cill
                    tem_index = ni;
                    ni = nj;
                    nj = n-1-tem_index;
                    temp2 = M[ni,nj];
                    M[ni,nj] = temp1;

                    //replcae 3 cill
                    tem_index = ni;
                    ni = nj;
                    nj = n-1-tem_index;
                    temp1 = M[ni,nj];
                    M[ni,nj] = temp2;

                    //relpce 4 cill
                    tem_index = ni;
                    ni = nj;
                    nj = n-1-tem_index;
                    M[ni,nj] = temp1;
                }   
            }
            return M;            
        }
        
        static Action<int[,]> print= delegate(int[,] x){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    sb.Append($"{x[i,j]}  ");   
                }   
                sb.Append("\n");
            }
            System.Console.WriteLine(sb.ToString());
        };

        // I will asume that he need to rotate matrix 90-degree with clockwise 
        static void Main_7(string[] args)
        {
            int[,] x1 = new int[3,3]{{1,2,3}, {4,5,6}, {7,8,9}};
            int[,] x2 = new int[4,4]{{1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16}};
            int[,] x3 = new int[5,5]{{1,2,3,4,5}, 
                                     {6,7,8,9,10},
                                     {11,12,13,14,15},
                                     {16,17,18,19,20},
                                     {21,22,23,24,25}};

            Stopwatch stwa = new Stopwatch();
            stwa.Start();
            /* #resion O(n^2) implementation V1 */ 
            print(RotatMatrix90_v1(x1)); 
            System.Console.WriteLine("_______________________________");
            print(RotatMatrix90_v1(x2));
            System.Console.WriteLine("_______________________________");
            print(RotatMatrix90_v1(x3));
            /* #endregion */
            stwa.Stop();
            System.Console.WriteLine($"Time : {stwa.Elapsed.ToString()}");
            stwa.Reset();
            System.Console.WriteLine("**********************");
            
            stwa.Start();
            /* #resion O(n^2) implementation V2 */ 
            print(RotatMatrix90_v2(x1)); 
            System.Console.WriteLine("_______________________________");
            print(RotatMatrix90_v2(x2));
            System.Console.WriteLine("_______________________________");
            print(RotatMatrix90_v2(x3));
            /* #endregion */
            stwa.Stop();
            System.Console.WriteLine($"Time : {stwa.Elapsed.ToString()}");
            stwa.Reset();
            System.Console.WriteLine("**********************");

        }
    }
}