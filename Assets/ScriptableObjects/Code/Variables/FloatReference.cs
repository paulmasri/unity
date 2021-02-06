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
public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference()
    { }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public void SetValue(float value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value;
    }

    public void SetValue(FloatVariable value)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to set the value of a constant");
        else
            Variable.Value = value.Value;
    }

    public void ApplyChange(float amount)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to change the value of a constant");
        else
            Variable.Value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        if (UseConstant)
            Debug.LogWarning("Trying to change the value of a constant");
        else
            Variable.Value += amount.Value;
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}
