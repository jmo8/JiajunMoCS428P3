using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboardTrigger : MonoBehaviour
{
    public GameObject cannon;
    public GameObject bullet;
    public GameObject Parent;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "StarBall")
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.transform.parent = Parent.transform;
            
        }
            

    }
}
