using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : BaseReferenceDrawer {

    protected override void SetTooltip()
    {
        myTooltip = "This is a Float Reference";
    }

}
