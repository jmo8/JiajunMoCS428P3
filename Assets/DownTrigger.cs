using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTrigger : MonoBehaviour
{
    public GameObject playerView;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DownTrue()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Vector3 newRotation = new Vector3(0, 0, 0);
        playerView.transform.eulerAngles = newRotation;
    }
}
