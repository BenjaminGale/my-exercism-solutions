using System;
using System.Linq;
using System.Collections.Generic;

public class Reactor
{
    public InputCell CreateInputCell(int value) =>
        new InputCell(value);

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) =>
        new ComputeCell(producers, compute);
}

public abstract class Cell
{
    public event EventHandler<int> Changed;
    public abstract int Value { get; set; }

    protected void OnChanged(int changedValue) =>
        Changed?.Invoke(this, changedValue);
}

public class InputCell : Cell
{
    private int _value;
    
    public InputCell(int value) =>
        _value = value;
    
    public override int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnChanged(_value);
            }
        }
    }
}

public class ComputeCell : Cell
{
    private readonly IEnumerable<Cell> _producers;
    private readonly Func<int[], int> _compute;
    private int _value;
    private int producersChanged = 0;

    public ComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute)
    {
        _producers = producers;
        _compute = compute;
        _value = ComputeValue();
        
        producers.Last().Changed += (_, _) =>
        {
            var newValue = ComputeValue();
                
            if (newValue != _value)
            {
                _value = newValue;
                OnChanged(_value);
            }
        };
    }

    private int ComputeValue() =>
        _compute(_producers.Select(c => c.Value).ToArray());
    
    public override int Value
    {
        get => _value;
        set => throw new InvalidOperationException("Can't change value of ComputeCell.");
    }
}
