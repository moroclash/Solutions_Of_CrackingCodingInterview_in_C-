using System.Reflection;
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
        Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
        before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
        to be after the elements less than x (see below). The partition element x can appear anywhere in the
        "right partition"; it does not need to appear between the left and right partitions.
        EXAMPLE
        Input:
        Output:
        3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5]
        3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8 

        book hints :
        #3   : There are many solutions to this problem, most of which are equally optimal in runtime.
               Some have shorter, cleaner code than others. Can you brainstorm different solutions? 
        
        #24  : Consider that the elements don't have to stay in the same relative order. We only need
               to ensure that elements less than the pivot must be before elements greater than the
               pivot. Does that help you come up with more solutions? 
     */
    class Ch2_4
    {
        
        public class Node<T>{
            public Node<T> Next;
            public T data;            
        }

        public class CustomelinkedList<T>{
            public Node<T> head;
            public Node<T> Last;
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

        }// end of class


        //here we will use another LinkedList
        //Runtime is O(n)
        public static CustomelinkedList<int> Linked_List_Partitioning_V1(CustomelinkedList<int> l_list, int value){
            CustomelinkedList<int> newLList = new CustomelinkedList<int>();
            Node<int> left = null , right= null, pointer = l_list.head;
            while(pointer != null){
                Node<int> newNode = new Node<int>(){data = pointer.data};
                int compare = pointer.data.CompareTo(value); 
                if(compare == 0|| compare == 1){
                    if(right == null){
                        right = newNode;
                        newLList.Last = right;
                    }
                    else{
                        right.Next = newNode;
                        right = newNode;
                    }
                }else{
                    if(left == null){
                        left = newNode;
                        newLList.head = newNode;
                    }else{
                        left.Next = newNode;
                        left = newNode;
                    }
                }
                pointer = pointer.Next;
            }
            left.Next = newLList.Last;
            newLList.Last = right;
            return newLList;
        }



        //here we will update current LinkedList
        //Runtime is O(n)
        public static void Linked_List_Partitioning_V2(CustomelinkedList<int> l_list, int value){
            Node<int> newHead = l_list.head , newTail= l_list.head;
            
            int compare;
            while(l_list.head != null){
                Node<int> next = l_list.head.Next;
                compare = l_list.head.data.CompareTo(value);
                if(compare == -1)
                {
                    l_list.head.Next = newHead;
                    newHead = l_list.head;
                }else{
                    newTail.Next = l_list.head;
                    newTail = l_list.head;
                }
                l_list.head = next;
            }
            newTail.Next = null;
            l_list.head = newHead;
            l_list.Last = newTail;
        }




        static void Main_4(string[] args)
        {
            CustomelinkedList<int> l_list = new CustomelinkedList<int>();
            l_list.add(3);
            l_list.add(5);
            l_list.add(8);
            l_list.add(5);
            l_list.add(10);
            l_list.add(2);
            l_list.add(1);
            System.Console.WriteLine("*****************");
            System.Console.WriteLine(l_list.ToString());
            // CustomelinkedList<int> newOne =  Linked_List_Partitioning_V1(l_list,5);
            // System.Console.WriteLine(newOne.ToString());
            Linked_List_Partitioning_V2(l_list,5);
            System.Console.WriteLine(l_list.ToString());
            System.Console.WriteLine("**********************");
        }
    }


}