using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAutoDes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Auto_Destroy", 30);
    }

    void Auto_Destroy()
    {
        Destroy(gameObject);
    }
}
