using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum State
{
    Idle, Walk, Attack, Dead
}

public class MonsterAiScript : MonoBehaviour
{
    private Animator ani;
    private NavMeshAgent agent;
    private AudioSource battle;
    private int HitCD = 0;

    public Transform monster;
    public Transform player;
    public Light light1;
    public Light light2;

    public GameObject Meatouter;
    public GameObject meat1;
    public GameObject meat2;
    public GameObject meat3;
    public GameObject meat4;
    public GameObject meat5;
    public GameObject meat6;

    public AudioSource Hit;
    public AudioSource Die;

    public GameObject WholeMons;

    float distance;
    int monsterCounter = 0;

    public State CurrentState;
    // Start is called before the first frame update
    void Start()
    {
        battle = transform.GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        distance = Vector3.Distance(player.position, monster.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, monster.position);
        switch (CurrentState)
        {
            case State.Idle:
                StateIdle();
                break;
            case State.Walk:
                StateWalk();
                break;
            case State.Attack:
                StateAttack();
                break;
            case State.Dead:
                StateDead();
                break;
        }

        if(distance <= 8 && !battle.isPlaying)
        {
            battle.Play();
        }
        else if(distance > 8)
        {
            battle.Pause();
        }

        if(CurrentState == State.Idle)
        {
            light1.enabled = false;
            light2.enabled = false;
        }
        else
        {
            light1.enabled = true;
            light2.enabled = true;
        }
    }

    public void StateIdle()
    {
        if (distance <= 8f)
        {
            ani.SetTrigger("Walk");
            CurrentState = State.Walk;
            
        }
    }

    public void StateWalk()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        agent.speed = 1f;
        agent.SetDestination(player.position);
        
        if (distance <= 1.25f)
        {
            ani.SetTrigger("Attack");
            CurrentState = State.Attack;
        }
        if (distance > 8f)
        {
            agent.speed = 0f;

            ani.SetTrigger("Idle");
            CurrentState = State.Idle;
        }
    }

    public void StateAttack()
    {
        
        agent.speed = 0f;
        monster.LookAt(player.position);
            

        if (distance > 8f)
        {
            ani.SetTrigger("Idle");
            CurrentState = State.Idle;
        }
        else if(distance > 2f)
        {
            ani.SetTrigger("Walk");
            CurrentState = State.Walk;
        }
    }

    public void StateDead()
    {
        agent.speed = 0;
        Destroy(WholeMons, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Blade" && CurrentState != State.Dead)
        {
            Hit.Play();
            // printing if collision is detected on the console
            // Debug.Log("Collision Detected");
            if (HitCD == 0)
            {

                int rnd = Random.Range(1, 6);
                if (rnd == 1)
                {
                    GameObject newBullet = GameObject.Instantiate(meat1, Meatouter.transform.position, Meatouter.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f;
                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1);
                }
                else if (rnd == 2)
                {
                    GameObject newBullet = GameObject.Instantiate(meat2, Meatouter.transform.position, Meatouter.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f;
                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1);
                }
                else if (rnd == 3)
                {
                    GameObject newBullet = GameObject.Instantiate(meat3, Meatouter.transform.position, Meatouter.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f;
                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1);
                }
                else if (rnd == 4)
                {
                    GameObject newBullet = GameObject.Instantiate(meat4, Meatouter.transform.position, Meatouter.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f;
                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1);
                }
                else if (rnd == 5)
                {
                    GameObject newBullet = GameObject.Instantiate(meat5, Meatouter.transform.position, Meatouter.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f;
                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1);
                }
                else if (rnd == 6)
                {
                    GameObject newBullet = GameObject.Instantiate(meat6, Meatouter.transform.position, Meatouter.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f;
                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1);
                }
                HitCD += 5;
            }
            else
            {
                HitCD -= 1;
            }
            

            //Debug.Log(rnd);


            monsterCounter++;

            if (monsterCounter == 30)
            {
                if (!Die.isPlaying)
                {
                    Die.Play();
                }
                ani.SetTrigger("Dead");
                CurrentState = State.Dead;

            }
            



        }
        

    }



}
