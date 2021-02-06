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
public class BoolReference
{
    public bool UseConstant = true;
    public bool ConstantValue;
    public BoolVariable Variable;

    public BoolReference()
    { }

    public BoolReference(bool value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public bool Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public void SetValue(bool value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value;
    }

    public void SetValue(BoolVariable value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value.Value;
    }

    public static implicit operator bool(BoolReference reference)
    {
        return reference.Value;
    }
}
