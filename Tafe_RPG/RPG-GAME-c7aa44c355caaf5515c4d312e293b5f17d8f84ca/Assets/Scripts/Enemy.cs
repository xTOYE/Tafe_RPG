using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum AISate
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    [Space(5), Header("Base Stats")]
    public AISate state;
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange, baseDamage;
    public int curWaypoint, difficulty;
    [Header("Base References")]
    public GameObject self;
    public Animator anim;
    public Transform player;
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject healthCanvas;
    public Image healthBar;

    private void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = self.GetComponent<NavMeshAgent>();
        curWaypoint = 1;
        agent.speed = moveSpeed;
        Patrol();
    }
    private void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Bite Attack", false);

        Patrol();
        Seek();
        Attack();
        Die();
    }
    public void Patrol()
    {
        //no waypoint no continue
        if(waypoints.Length == 0 || Vector3.Distance(player.position,self.transform.position) <= sightRange || curHealth < 0)
        {
            return;
        }
        anim.SetBool("Walk", true);
        //follow waypoints
        //set agent to target
        agent.destination = waypoints[curWaypoint].position;
        //are we at the waypoint
        if(self.transform.position.x == agent.destination.x)
        if(self.transform.position.z == agent.destination.z)
        {
                if(curWaypoint < waypoints.Length-1)
                {
                    // finds next waypoint
                    curWaypoint++;
                }
                else
                {
                    //if at end of patrol go back to start
                    curWaypoint = 1;
                }
        }
        // if so go to next waypoint
    }
    public void Seek()
    {
        if (Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange || curHealth < 0)
        {
            return;
        }
        state = AISate.Seek;
        anim.SetBool("Run", true);
        //if player in sight range chase
        agent.destination = player.position;
    }
    public virtual void Attack()
    {if(Vector3.Distance(player.position, self.transform.position) > attackRange || curHealth < 0 || player.GetComponent<PlayerHandler>().curHealth < 0)
        {
            return;
        }
        //if player in attack range attack
        state = AISate.Attack;
        anim.SetBool("Bite Attack", true);
    }
    public void Die()
    {
        if(curHealth > 0)
        {
            //die
            return;
        }
        state = AISate.Die;
        anim.SetTrigger("Die");

        //drops loot
    }
}
