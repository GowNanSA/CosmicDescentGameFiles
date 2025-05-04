// Type 1 AI, the enemy just chases you until you reach the end, player needs to dodge to avoid it 
using UnityEngine;
using UnityEngine.AI; // for built in stuff 
/// <summary>
/// REFERENCE USED https://youtu.be/UjkSFoLxesw?feature=shared
/// </summary>
// enemy type 1 


public class Enemy1AI : MonoBehaviour
{
    public Transform playerTarget;

    public NavMeshAgent agent;

    public LayerMask ground1, player1;

    // to allow the enemy to patrol the player 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // to allow enemy to attack should deplete health like... every 3 seconds of touch or smth 
    public float timeBeforeAttack;



    // state machine reference
    public float sightRange, attackRange; // player in sight 
    bool playerSeen, playerAttack; // bools to check if player is in range or in sight

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // search for the player 
        playerTarget = GameObject.Find("Player").transform;
        // assign navmesh agent 
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if the player is in sight or range 
        // check if in sight or attack possible
        playerSeen = Physics.CheckSphere(transform.position, sightRange, player1); // player is seen or not 
        playerAttack = Physics.CheckSphere(transform.position, attackRange, player1); // player can be attacked or not 


        // chase the player 
        if (!playerSeen) Patrol();
        if (playerSeen) Chase();
    }



    // patrol 
    void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomRangeZ = Random.Range(-walkPointRange, walkPointRange);
        float randomRangeX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomRangeX, transform.position.y, transform.position.z + randomRangeZ);

        // this is a raycast to check if this is on the ground from the tutorial I watched
        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground1))
            walkPointSet = true;
    }

    // chase and attack 
    void Chase()
    {
        agent.SetDestination(playerTarget.position);
        // we can include the attack and other AI elements in here later on 

        transform.LookAt(playerTarget);
    }

}
// will likely kill the player, lead to game over, or restart level when touched 