using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrimitiveExample : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        var s = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var dataObject = s.AddComponent<DataObject>();
        dataObject.setValue(14.0f); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
