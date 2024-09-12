using System;
using System.Linq;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    
    private int _start;
    private int _end;
    
    public CircularBuffer(int capacity) =>
        _buffer = new T[capacity];

    public T Read()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        return _buffer[_start++ % _buffer.Length];
    }

    public void Write(T value)
    {
        if (IsFull)
            throw new InvalidOperationException();

        _buffer[_end++ % _buffer.Length] = value;
    }

    public void Overwrite(T value)
    {   
        _buffer[_end++ % _buffer.Length] = value;

        if (!IsFull)
            _start++;
    }

    public void Clear() =>
        _start = _end = 0;

    private bool IsEmpty =>
        _start == _end;

    private bool IsFull =>
        (_end - _start) == _buffer.Length;
}
