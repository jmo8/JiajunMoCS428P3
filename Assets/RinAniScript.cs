using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RinAniScript : MonoBehaviour
{
    private Animator ani;
    
    AudioSource BGM;
    public GameObject Rin;
    public GameObject Player;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        BGM = transform.GetComponent<AudioSource>();
        distance = Vector3.Distance(Player.transform.position, Rin.transform.position);
        ani = GetComponent<Animator>();
        
    }

    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, Rin.transform.position);
        if(distance <= 5 && !BGM.isPlaying)
        {
            BGM.Play();
        }
        else if(distance > 5)
        {
            BGM.Pause();
        }

        if(distance < 3)
        {
            ani.SetTrigger("bowTrigger");
        }
        else
        {
            ani.SetTrigger("idleTrigger");
        }
        
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag != "StarBall")
    //    {
    //        ani.SetTrigger("bowTrigger");
    //        if(paused == 0)
   //         {
    //            BGM.Play();
    //        }
     //       else
     //       {
     //           BGM.UnPause();
    //        }
            
    //    }
        
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag != "StarBall")
   //     {
   //         ani.SetTrigger("idleTrigger");
   //         BGM.Pause();
   //         paused = 1;
   //     }
            
   // }
}
