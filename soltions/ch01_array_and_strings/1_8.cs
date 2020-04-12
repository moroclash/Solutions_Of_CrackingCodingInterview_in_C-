using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
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
        Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
        column are set to 0

        book hints :
        #17  : If you just cleared the rows and columns as you found Os, you'd likely wind up clearing
               the whole matrix. Try finding the cells with zeros first before making any changes to the
               matrix. 
        #74  : Can you use O(N) additional space instead of O(N^2)? What information do you really
               need from the list of cells that are zero? 
        #102 : You probably need some data storage to maintain a list of the rows and columns that
               need to be zeroed. Can you reduce the additional space usage to 0(1) by using the
               matrix itself for data storage? 
    */
    class Ch1_1_8
    {
        // so it's Runtime is O(I*J) but space is O(Z) 
        // where I,J is Matrix Dimantion and Z is aNumber of Zeros in Matrix  
        public static int[,] CheckZeroElement_V1(int[,] M){
            HashSet<int> list_of_elemin_positions_I = new HashSet<int>();
            HashSet<int> list_of_elemin_positions_J = new HashSet<int>();

            //RunTime = O(I*J)
            for (int i = 0; i < M.GetLength(0); i++)  //O(I)
            {
               for (int j= 0; j < M.GetLength(1); j++)  //O(J)
               {
                  if( M[i,j] == 0 ){
                    list_of_elemin_positions_I.Add(i);
                    list_of_elemin_positions_J.Add(j);
                  }
               }
            }
            
            if(list_of_elemin_positions_I.Count == 0 || list_of_elemin_positions_J.Count == 0)
                return new int[M.GetLength(0),M.GetLength(1)];
            if(list_of_elemin_positions_I.Count == 0) return M;

            //RunTime =  O(Z * I) 
            for(int i = 0; i<list_of_elemin_positions_I.Count; i++)  
                for (int j = 0; j < M.GetLength(1); j++) //O(J)
                    M[list_of_elemin_positions_I.ElementAt(i), j] = 0;
            
            //RunTime = (Z * I)
            for(int i = 0; i<list_of_elemin_positions_J.Count; i++)  
                for (int j = 0; j < M.GetLength(0); j++) //O(I)
                    M[j,list_of_elemin_positions_J.ElementAt(i)] = 0;

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

        static void Main_8(string[] args)
        {
            int[,] x1 = new int[3,3]{{1,0,3}, {4,5,6}, {7,8,9}};
            int[,] x2 = new int[3,4]{{1,2,3,4}, {5,6,7,8}, {9,10,0,12}};
            int[,] x3 = new int[5,5]{{1,2,3,4,5}, 
                                     {6,7,8,9,10},
                                     {11,12,13,14,0},
                                     {16,17,18,19,20},
                                     {21,22,0,24,25}};

            Stopwatch stwa = new Stopwatch();
            stwa.Start();
            /* #resion O(IJ) implementation V1 */ 
            print(CheckZeroElement_V1(x1)); 
            System.Console.WriteLine("_______________________________");
            print(CheckZeroElement_V1(x2));
            System.Console.WriteLine("_______________________________");
             print(CheckZeroElement_V1(x3));
            /* #endregion */
            stwa.Stop();
            System.Console.WriteLine($"Time : {stwa.Elapsed.ToString()}");
            stwa.Reset();
            System.Console.WriteLine("**********************");

        }
    }
}