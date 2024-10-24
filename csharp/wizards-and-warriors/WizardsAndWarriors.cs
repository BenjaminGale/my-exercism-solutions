using System;

abstract class Character
{
    private readonly string _characterType;
    
    protected Character(string characterType) =>
        _characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() =>
        $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base(nameof(Warrior))
    {
    }

    public override int DamagePoints(Character target) =>
        target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool _hasPreparedSpell;

    public Wizard() : base(nameof(Wizard))
    {
    }

    public override int DamagePoints(Character target) =>
        _hasPreparedSpell ? 12 : 3;

    public void PrepareSpell() =>
        _hasPreparedSpell = true;

    public override bool Vulnerable() =>
        !_hasPreparedSpell;
}
