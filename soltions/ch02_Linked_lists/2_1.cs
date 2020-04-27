using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace soltions
{
    // question:
    /*
       Remove Dups! Write code to remove duplicates from an unsorted linked list.
       FOLLOW UP
       How would you solve this problem if a temporary buffer is not allowed?  
     
        book hints :
        #9      : Have you tried a hash table? You should be able to do this in
                  a single pass of the linked list.
        #40     : Without extra space, you'll need O(N^2) time. Try using two pointers,
                  where the second one searches ahead of the first one.  
     */
    class Ch2_
    {

        
        public class CustomelinkedList<T>{
            private Node<T> head;
            private Node<T> Last;

            public void add(T data){
                Node<T> newNode = new Node<T>(){data = data};
                if(head == null)
                    head = newNode;
                if(Last == null)
                    Last = head;

                Last.Next = newNode;
                Last = newNode;
            }

            public bool remove(T data){
                Node<T> pointer = head;
                if(head.data.Equals(data)){
                    head = head.Next;
                    return true;
                }

                while(pointer.Next != null){
                    if(pointer.Next.data.Equals(data))
                    {
                        pointer.Next = pointer.Next.Next;
                        return true;
                    }
                    pointer = pointer.Next;
                }
                return false;
            }

            public override string ToString(){
                StringBuilder sb = new StringBuilder();
                if(head == null) return "";
                Node<T> pointer = head;
                while(pointer!=null){
                    sb.Append(pointer.data.ToString());
                    sb.Append(", ");
                    pointer = pointer.Next;
                }
                return sb.ToString();
            }

            private class Node<T>{
                public Node<T> Next;
                public T data;            
            }              


            //here we will use chache to solve problem, we will use HashSet
            //This function take O(n) 
            public void Remve_duplication_V1(){
                HashSet<T> cache = new HashSet<T>();
                if(head != null)
                {
                    Node<T> pointer = head;
                    cache.Add(pointer.data);
                    while(pointer.Next != null){
                        if(cache.Contains(pointer.Next.data)){
                            pointer.Next = pointer.Next.Next;                            
                        }
                        else{
                            cache.Add(pointer.Next.data);
                            pointer = pointer.Next;
                        }
                    }
                }
            }

            //here we will no use chache to solve problem
            //This function take O(n^2) 
            public void Remve_duplication_V2(){
                if(head != null)
                {
                    Node<T> pointer1 = head;
                    Node<T> pointer2 = head;
                    while(pointer1.Next != null){
                        pointer2 = pointer1;
                        while(pointer2.Next != null)
                        {
                            if(pointer1.data.Equals(pointer2.Next.data))
                                pointer2.Next = pointer2.Next.Next;
                            pointer2 = pointer2.Next;                               
                        }
                        pointer1 = pointer1.Next;
                    }
                }
            }

        }// end of class




        static void Main_1(string[] args)
        {
            CustomelinkedList<int> l_list = new CustomelinkedList<int>();
            l_list.add(5);
            l_list.add(6);
            l_list.add(7);
            l_list.add(7);
            l_list.add(8);
            l_list.add(9);
            l_list.add(5);
            l_list.add(10);
            l_list.add(11);
            System.Console.WriteLine(l_list.ToString());
            System.Console.WriteLine("*****************");
            // l_list.Remve_duplication_V1();
            l_list.Remve_duplication_V2();
            System.Console.WriteLine(l_list.ToString());


            /* #resion O(n^2) implementation V1 */ 
            // Console.WriteLine(IsUninqe_V1(non_unique));
            // Console.WriteLine(IsUninqe_V1(unique));
            /* #endregion */

            System.Console.WriteLine("**********************");

        }
    }


}