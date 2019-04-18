using UnityEngine;
using System;

[Serializable]
public class LayerMaskReference : BaseReference<LayerMask, LayerMaskVariable> {

    public LayerMaskReference() : base()
    { }
    public LayerMaskReference(LayerMask mask) : base(mask)
    { }
    public LayerMaskReference(LayerMaskVariable maskVar) : base(maskVar)
    { }
    public LayerMaskReference(LayerMask mask, LayerMaskVariable maskVar) : base(mask, maskVar)
    { }

}
