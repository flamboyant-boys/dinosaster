using UnityEngine;



/// <summary>
/// T1 needs to be the base Type, while T2 needs to be the SO Variable. Also: You need to add "using System;" and the [Serializable] Attribute to the Derrived Class.
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public abstract class BaseReference <T1, T2>
//Basically to make sure that T2 is an SO Variable for the base Type T1
where T2 : BaseSOV<T1>

{
    //All of the Fields have to be Serialized to be useable by the Property Drawer
    [SerializeField]
    bool useNormalType = true;
    [SerializeField]
    T1 normalTypeVariable;
    [SerializeField]
    T2 _SOVariable;

    static T1 standardValue = default(T1);

    public BaseReference()
    { }

    public BaseReference(T1 value) : this(value, null)
    { }
    public BaseReference(T2 soVar) : this(standardValue, soVar)
    { }
    public BaseReference(T1 value, T2 soVar)
    {
        if(soVar != null)
        {
            useNormalType = false;
        }
        else
        {
            useNormalType = true;
        }

        normalTypeVariable = value;
        SOVariable = soVar;
    }

    public T1 Value
    {
        get { return useNormalType ? normalTypeVariable : _SOVariable.GetValue(); }
        set {
            if (useNormalType)
            {
                normalTypeVariable = value;
            }
            else
            {
                _SOVariable.SetValue(value);
            }
        }
    }
    public T2 SOVariable
    {
        get { return _SOVariable; }
        set { _SOVariable = value; }
    }

    public static implicit operator T1(BaseReference<T1, T2> reference)
    {
        return reference.Value;
    }
    public static implicit operator T2(BaseReference<T1, T2> reference)
    {
        return reference.SOVariable;
    }






}


