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
public class IntReference
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntVariable Variable;

    public IntReference()
    { }

    public IntReference(int value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public void SetValue(int value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value;
    }

    public void SetValue(IntVariable value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value.Value;
    }

    public void ApplyChange(int amount)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to change the value of a constant");
        else
            Variable.Value += amount;
    }

    public void ApplyChange(IntVariable amount)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to change the value of a constant");
        else
            Variable.Value += amount.Value;
    }

    public static implicit operator int(IntReference reference)
    {
        return reference.Value;
    }
}
