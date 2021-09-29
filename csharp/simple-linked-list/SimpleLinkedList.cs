using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private T _value;
    private SimpleLinkedList<T> _next;

    public SimpleLinkedList() : this(Enumerable.Empty<T>())
    {
    }

    public SimpleLinkedList(T value) : this(new[] { value })
    {
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        // _value = values.First();
        // var list = this;

        // foreach (var val in values.Skip(1))
        // {
        //     list.Add(val);
        //     list = list.Next;
        // }
    }

    public int Count { get { return 0; }}

    public T Value => _value;

    public SimpleLinkedList<T> Next => _next;

    public void Push(T value)
    {
        
    }

    public T Pop()
    {
        return default(T);
    }

    public void Reverse()
    {
    }

    public IEnumerator<T> GetEnumerator()
    {
        var list = this;

        while (list != null)
        {
            yield return list.Value;
            list = list.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}