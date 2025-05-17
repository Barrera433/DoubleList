using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList;

public class DoublyLinkedList<T>

{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
    }

    public void InserAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)// Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;

        }

    }

    public void InserAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }
    //Prints the List fron head to tail
    public String GettForward()
    {
        var output = String.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data}<=>";
            current = current.Next;
        }
        return output;
    }

    //Prints the List fron head to head
    public String GetBackward()
    {
        var output = String.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Substring(0, output.Length - 5);
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next; // Remuve head
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;// Remuve tail
                }
                break;
            }
            current = current.Next;
        }



    }

}
