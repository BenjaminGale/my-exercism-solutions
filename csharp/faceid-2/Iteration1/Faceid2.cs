using System;
using System.Collections.Generic;

public sealed class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object other)
    {
        if (other is null) return false;
        if (object.ReferenceEquals(this, other)) return true;

        var otherFacialFeatures = other as FacialFeatures;

        if (otherFacialFeatures is null) return false;

        return otherFacialFeatures.EyeColor == EyeColor &&
            otherFacialFeatures.PhiltrumWidth == PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        int hashcode = 7;
        hashcode = hashcode * 31 + EyeColor.GetHashCode();
        hashcode = hashcode * 31 + PhiltrumWidth.GetHashCode();
        return hashcode;
    }
}

public sealed class Identity
{
    public static readonly Identity Admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object other)
    {
        if (other is null) return false;
        if (object.ReferenceEquals(this, other)) return true;

        var otherIdentity = other as Identity;

        if (otherIdentity is null) return false;

        return otherIdentity.Email == Email &&
            otherIdentity.FacialFeatures.Equals(FacialFeatures);
    }

    public override int GetHashCode()
    {
        int hashcode = 7;
        hashcode = hashcode * 31 + Email.GetHashCode();
        hashcode = hashcode * 31 + FacialFeatures.GetHashCode();
        return hashcode;
    }
}

public class Authenticator
{
    private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) =>
        identity.Equals(Identity.Admin);

    public bool Register(Identity identity) =>
        _registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) =>
        _registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        object.ReferenceEquals(identityA, identityB);
}
