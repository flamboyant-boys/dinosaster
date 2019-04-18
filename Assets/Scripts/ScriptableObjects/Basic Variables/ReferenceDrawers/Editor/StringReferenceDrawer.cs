using System;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringReference))]
public class StringReferenceDrawer : BaseReferenceDrawer
{
    protected override void SetTooltip()
    {
        myTooltip = "This is a String Reference";
    }
}
