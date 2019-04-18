using System;

[Serializable]
public class FloatReference : BaseReference<float, FloatVariable> {


    public FloatReference() : base()
    { }
    public FloatReference(float value) : base(value)
    { }
    public FloatReference(FloatVariable value) : base(value)
    { }
    public FloatReference(float value, FloatVariable floatVar) : base(value, floatVar)
    { }


}
