using UnityEngine;


/// <summary>
/// T needs to be the Type you want the SO Variable to be. Add the Create AssetMenu Attribute with "Basic Variables/Simple SOV/*Name of the Variable*"
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseSOV<T> : ScriptableObject {

#if UNITY_EDITOR
    [Multiline]
#endif
    public string description = "";


    [SerializeField]
    protected T Value;
    

    public virtual void SetValue(T value)
    {
        Value = value;
    }
    public virtual void SetValue(BaseSOV<T> value)
    {
        Value = value.GetValue();
    }
    
    public virtual T GetValue()
    {
        return Value;
    }

    //To be able to automatically set the value of a normal Variable to the value of the SOV simply by using the = operator
    public static implicit operator T(BaseSOV<T> reference)
    {
        return reference.GetValue();
    }



}
