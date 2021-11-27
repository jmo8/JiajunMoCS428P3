using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuList : MonoBehaviour
{
    public GameObject Origin;
    public GameObject Mego;
    public GameObject Land;
    public GameObject Dancing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Origin.activeSelf)
        {
            SceneManager.LoadScene(0);
        }
        else if (Mego.activeSelf)
        {
            SceneManager.LoadScene(1);
        }
        else if (Land.activeSelf)
        {
            SceneManager.LoadScene(2);
        }
        else if (Dancing.activeSelf)
        {
            SceneManager.LoadScene(3);
        }
    }
}
