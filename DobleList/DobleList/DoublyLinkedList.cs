using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList;

public class DoublyLinkedList<T> where T : IComparable<T> 

{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
    }

    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)// Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
           DoubleNode<T> Current = _head;
            while (Current != null && Current.Data!.CompareTo(data) < 0) 
            {
                Current = Current.Next!;
            }
            if (Current == _head) // insertar al principio 
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
            else if (Current == null) // insertar al final 
            {
                _tail!.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
            else // insertar en el medio 
            {
                newNode.Next = Current;
                newNode.Prev = Current!.Prev;
                Current.Prev!.Next = newNode;
                Current.Prev = newNode;
            }

        }

    }

    public String ShowForward() // mostrar hacia adelante 
    {
        var output = string.Empty;
        var Current = _head;
        while (Current != null)
        {
            output += $"{Current.Data}<=>";
            Current = Current.Next!;
        }
        return output.EndsWith("<=>") ? output.Substring(0, output.Length - 3) :output;
    }
  
    public String ShowBackward() // Mostrar hacia atras 
    {
        var output = String.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.EndsWith("<=>") ? output.Substring(0, output.Length - 3) : output;

    }


    public void SortDescending()
    {
        List<T> list = new List<T>();
        DoubleNode<T>? current = _head;
        while (current != null)
        {
            list.Add(current.Data!);
            current = current.Next!;
        }

        list.Sort((a, b) => b.CompareTo(a)); //Lista descendente

        _head = null;  
        _head = null;

        foreach (var item in list) // Reinsertar lista 
        {
            Add(item);
        }
        ReverseList();
    }    

    private void ReverseList()
    {
        DoubleNode<T>? current = _head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }
        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    public List<T>  GetModes()
    {
        Dictionary<T, int> occurrences = new Dictionary<T, int>();
        DoubleNode <T>? current = _head;
        while (current != null)
        {
            if (current.Data != null)
            {
                if (occurrences.ContainsKey(current.Data))
                {
                    occurrences[current.Data] ++;
                }
                else
                {
                    occurrences[current.Data] = 1;
                }
            }
            current = current!.Next;
        }

        int maxOccurrence  = 0;
        foreach (var pair in occurrences)
        {
            if (pair.Value > maxOccurrence)
            {
                maxOccurrence = pair.Value;
            }
        }

        List<T> modes = new List<T>();
        foreach (var pair in occurrences)
        {
            if (pair.Value == maxOccurrence)
            {
                modes.Add(pair.Key);
            }
        }
        return modes;
    }
    public String ShowGraph()
    {
        Dictionary<T, int> occurrences = new Dictionary<T, int>();
        DoubleNode<T>? current = _head;
        while (current != null)
        {
            if (current.Data != null)
            {
                if (occurrences.ContainsKey(current.Data))
                {
                    occurrences[current.Data]++;
                }
                else
                {
                    occurrences[current.Data] = 1;

                }
            }
            current = current!.Next;
        }

        String graph = "";
        foreach (var pair in occurrences.OrderBy(Key => Key.Key))
        {
            graph += $"{pair.Key}{new String('*',pair.Value)}\n";
        }

        return graph;
    }

    public bool Exists (T data) // Existencia de datos 
    {
        DoubleNode<T>? current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current!.Next;
        }

        return false;
    }
    public void RemoveFirstOcurrence(T data)
    {
        DoubleNode<T>? current = _head;
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

                    if (_head != null)
                    {
                        _head.Prev = null;
                    }
                }
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                }

                return;
            }
            current = current.Next;
        }

    }

     public void RemoveAllOcurrence(T data)
    {
        DoubleNode<T>? current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head) // Si es el primer elemento
                {
                    _head = current.Next;
                    if (_head != null)
                    {
                        _head.Prev = null;
                    }
                }
                else if (current == _tail) // Si es el último elemento
                {
                    _tail = current.Prev;
                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                }
                else // Si es un elemento intermedio
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }


            }
            current = current.Next;
        }
    }

}
