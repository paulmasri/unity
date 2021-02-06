// ----------------------------------------------------------------------------
// Based on...
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using System;

[Serializable]
public class StringReference
{
    public bool UseConstant = true;
    public string ConstantValue;
    public StringVariable Variable;

    public StringReference()
    { }

    public StringReference(string value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public string Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public void SetValue(string value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value;
    }

    public void SetValue(StringVariable value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value.Value;
    }

    public static implicit operator string(StringReference reference)
    {
        return reference.Value;
    }
}
