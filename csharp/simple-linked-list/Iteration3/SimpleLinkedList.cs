using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    class Node<T>
    {
        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
        
        public T Value { get; }
        public Node<T> Next { get; }
    }

    private Node<T> _head;

    public SimpleLinkedList()
    {
    }
    
    public SimpleLinkedList(T value) : this(new[] { value })
    {
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        foreach (var value in values)
            Push(value);
    }

    public int Count => this.Count();

    public T Value =>
        _head is null
            ? default(T)
            : _head.Value;

    public SimpleLinkedList<T> Push(T value)
    {
        var newNode = new Node<T>(value, _head);
        _head = newNode;
        
        return this;
    }

    public T Pop()
    {
        var value = _head.Value ?? default(T);
        _head = _head.Next;

        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = _head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}