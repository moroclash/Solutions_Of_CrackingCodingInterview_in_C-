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
        Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list  
     
        book hints :
        #8   : What if you knew the linked list size? What is the difference between 
               finding the Kth-tolast element and finding the Xth element? 
        #25  : If you don't know the linked list size, can you compute it? How does this impact the runtime? 
        #41  : Try implementing it recursively. If you could find the (K-l)th to last element,
               can you find the Kth element? 
        #67  : You might find it useful to return multiple values. Some languages don't directly support
               this, but there are workarounds in essentially any language. What are some of those
               workarounds? 
        #126 : Can you do it iteratively? Imagine if you had two pointers pointing to adjacent nodes
               and they were moving at the same speed through the linked list. When one hits the end
               of the linked list, where will the other be?   
     */
    class Ch2_2
    {

        
        public class CustomelinkedList<T>{
            private Node<T> head;
            private Node<T> Last;
            public int Size { get; set; } = 0;

            public void add(T data){
                Node<T> newNode = new Node<T>(){data = data};
                if(head == null)
                    head = newNode;
                if(Last == null)
                    Last = head;

                Last.Next = newNode;
                Last = newNode;
                this.Size++;
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


            //return Kth-to-last element (we will assume that Linked List has size property) 
            //This function take O(n) 
            public void Return_Kth_element_V1(int kth,out T data){
                int count = 1;
                Node<T> pointer = head;
                data = default(T);
                while(pointer != null){
                    if(kth == this.Size - count + 1)
                    {
                        data = pointer.data;
                        break;
                    }
                    count++;
                    pointer = pointer.Next;
                }
            }

            //we can compute size of Linked List and the Runtime will be O(N)

            //return Kth-to-last element (we will that Linked List hasn't size property) 
            //so we will solve it recursively 
            //This function take O(n), but Space complexity will be O(N) 
            public void Return_Kth_element_V2(int kth,out T data){
                Return_Kth_recursively(kth,out data, head);           
            }

            private int Return_Kth_recursively(int kth,out T data, Node<T> pointer){
                data = default(T);
                if(pointer == null)
                    return 1;

                int index = Return_Kth_recursively(kth,out data, pointer.Next);
                
                if(index == kth)
                    data = pointer.data;
                
                return index+1;
            }




            //return Kth-to-last element (we will that Linked List hasn't size property) 
            //so we will solve it using 2 pointers 
            //This function take O(n), but Space complexity will be O(1) 
            public void Return_Kth_element_V3(int kth,out T data){
                Node<T> pointer1 = head, pointer2 = head;
                data = default(T);
                bool Size_flage = false;
                if(kth == 0) Size_flage = true;
                for(int i=1; i<kth; i++)
                {
                    if(pointer2.Next == null)
                    {
                        Size_flage = true;
                        break;
                    }
                    pointer2 = pointer2.Next;
                }
                if(!Size_flage){
                    while(pointer2.Next != null){
                        pointer1 = pointer1.Next;
                        pointer2 = pointer2.Next;
                    }
                    data = pointer1.data;
                }
            }



        }// end of class




        static void Main(string[] args)
        {
            CustomelinkedList<int> l_list = new CustomelinkedList<int>();
            l_list.add(5);
            l_list.add(6);
            l_list.add(7);
            l_list.add(8);
            l_list.add(9);
            l_list.add(10);
            l_list.add(11);
            System.Console.WriteLine("*****************");
            int output;
            // l_list.Return_Kth_element_V1(2,out output);
            // l_list.Return_Kth_element_V2(3,out output);
            l_list.Return_Kth_element_V3(0,out output);
            System.Console.WriteLine(output);
            System.Console.WriteLine("**********************");

        }
    }


}