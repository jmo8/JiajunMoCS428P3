using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickerDes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Auto_Destroy", 10);
    }

    void Auto_Destroy()
    {
        Destroy(gameObject);
    }
}
