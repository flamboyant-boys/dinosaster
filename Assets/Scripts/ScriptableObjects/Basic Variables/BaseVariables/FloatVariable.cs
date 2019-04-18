using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "A Float Variabel", menuName = "Basic Variables/Simple SOV/Float Variable")]
public class FloatVariable : BaseSOV<float> {

    public void ApplyChange(float amount)
    {
        Value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        Value += amount.Value;
    }

}
