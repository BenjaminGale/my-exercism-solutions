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
    public event EventHandler<int> Updated;
    public event EventHandler<int> Changed;
    
    public abstract int Value { get; set; }

    protected void OnValueChanged(int changedValue)
    {
        Updated?.Invoke(this, changedValue);
        Changed?.Invoke(this, changedValue);
    }
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
            if (_value == value) return;
                
            _value = value;
            OnValueChanged(_value);
        }
    }
}

public class ComputeCell : Cell
{
    private readonly IEnumerable<Cell> _producers;
    private readonly Func<int[], int> _compute;
    private int _value;
    private bool _valueChanged;
    
    public ComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute)
    {
        _producers = producers;
        _compute = compute;
        _value = ComputeValue();

        foreach (var producer in _producers)
        {
            producer.Updated += (_, _) => OnUpdated();
            producer.Changed += (_, _) => OnChanged();
        }
    }

    private void OnUpdated()
    {
        var newValue = ComputeValue();

        if (_value == newValue) return;
        
        _value = newValue;
        _valueChanged = true;
    }

    private void OnChanged()
    {
        if (!_valueChanged) return;
        
        OnValueChanged(_value);
        _valueChanged = false;
    }

    private int ComputeValue() =>
        _compute(_producers.Select(c => c.Value).ToArray());
    
    public override int Value
    {
        get => _value;
        set => throw new InvalidOperationException("Can't change value of ComputeCell.");
    }
}
