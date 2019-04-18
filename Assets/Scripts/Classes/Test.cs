using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class Test : MonoBehaviour
{
    LivinEntity test = new LivinEntity("Testosaurus", 10f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(test.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
