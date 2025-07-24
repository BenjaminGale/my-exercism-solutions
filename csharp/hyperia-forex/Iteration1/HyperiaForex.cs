using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
            throw new ArgumentException("Must have the same currency.");

        return left.amount == right.amount;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) =>
        !(left == right);

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
            throw new ArgumentException("Must have the same currency.");

        return left.amount < right.amount;
    }

    public static bool operator >(CurrencyAmount left, CurrencyAmount right) =>
        !(left < right);

    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
            throw new ArgumentException("Must have the same currency.");

        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
            throw new ArgumentException("Must have the same currency.");

        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount currencyAmount, decimal multiplier) =>
        new CurrencyAmount(currencyAmount.amount * multiplier, currencyAmount.currency);
    
    public static CurrencyAmount operator *(decimal multiplier, CurrencyAmount currencyAmount) =>
        currencyAmount * multiplier;

    public static CurrencyAmount operator /(CurrencyAmount currencyAmount, decimal divisor) =>
        new CurrencyAmount(currencyAmount.amount / divisor, currencyAmount.currency);
    
    public static CurrencyAmount operator /(decimal divisor, CurrencyAmount currencyAmount) =>
        currencyAmount / divisor;

    public static explicit operator double (CurrencyAmount currencyAmount) =>
        (double)currencyAmount.amount;

    public static implicit operator decimal (CurrencyAmount currencyAmount) =>
        currencyAmount.amount;
}
