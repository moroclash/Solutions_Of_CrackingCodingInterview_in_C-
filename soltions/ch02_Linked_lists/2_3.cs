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
        Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
        the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
        that node.
        EXAMPLE
        lnput:the node c from the linked lista->b->c->d->e->f
        Result: nothing is returned, but the new linked list looks like a->b->d->e->f 

        book hints :
        #72   :  Picture the list 1->5->9->12. Removing 9 would make it look like 1->5->12. You only
                 have access to the 9 node. Can you make it look like the correct answer? 
     */
    class Ch2_3
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

            public class Node<T>{
                public Node<T> Next;
                public T data;            
            }              


            //assume no size property is avilable 
            //This function take O(n), and space complexity O(1) 
            public void Delete_Middel_element_V1(){
                //count size
                int count = 0;
                Node<T> pointer = head;
                while(pointer != null)
                {
                    pointer = pointer.Next;
                    count++;
                }
                count =  (int)Math.Ceiling(count/2.0) -2; 
                pointer = head;
                for(int i=0; i< count; i++)
                {
                    pointer =  pointer.Next;
                }
                pointer.Next = pointer.Next.Next;
            }


        }// end of class




        static void Main_3(string[] args)
        {
            CustomelinkedList<int> l_list = new CustomelinkedList<int>();
            l_list.add(5);
            l_list.add(6);
            l_list.add(7);
            l_list.add(8);
            l_list.add(9);
            l_list.add(10);
            // l_list.add(11);
            System.Console.WriteLine("*****************");
            System.Console.WriteLine(l_list.ToString());
            l_list.Delete_Middel_element_V1();
            System.Console.WriteLine(l_list.ToString());
            System.Console.WriteLine("**********************");

        }
    }


}