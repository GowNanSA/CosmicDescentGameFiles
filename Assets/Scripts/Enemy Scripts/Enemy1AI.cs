// Type 1 AI, the enemy just chases you until you reach the end, player needs to dodge to avoid it 
using System.Drawing;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI; // for built in stuff 
/// <summary>
/// REFERENCE USED https://youtu.be/UjkSFoLxesw?feature=shared
/// </summary>
// enemy type 1 


public class EnemyType1AI : MonoBehaviour
{
    public Transform playerTarget;

    public NavMeshAgent agent;

    public LayerMask ground1, player1;

    // to allow the enemy to patrol the player 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public NavMeshSurface surface;


    // state machine reference
    public float sightRange = 10f;
        //attackRange; // player in sight s = 10f
    bool playerSeen, playerAttack; // bools to check if player is in range or in sight

    public Transform playerRespawnPoint; 

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
        //playerAttack = Physics.CheckSphere(transform.position, attackRange, player1); // player can be attacked or not 


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

        Vector3 distanceToWalkPoint = new Vector3(transform.position.x - walkPoint.x, 0f, transform.position.z - walkPoint.z);
        //Debug.Log(distanceToWalkPoint);

        if (distanceToWalkPoint.magnitude < .5f)
        {
            //Debug.Log("reached");
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        //Debug.Log("searching for walk point");
        //float randomRangeZ = Random.Range(-walkPointRange, walkPointRange);
        //float randomRangeX = Random.Range(-walkPointRange, walkPointRange);

        //walkPoint = new Vector3(transform.position.x + randomRangeX, transform.position.y, transform.position.z + randomRangeZ);

        // Get a random point within the bounds of the NavMesh surface
        Vector3 randomPoint = GetRandomPointOnNavMesh();
        //Debug.Log(randomPoint);

        // Check if the generated point is valid
        if (randomPoint != Vector3.zero)
        {
            walkPoint = randomPoint;
            walkPointSet = true;
        }

        // this is a raycast to check if this is on the ground from the tutorial I watched
        //if (Physics.Raycast(walkPoint, -transform.up, 2f, ground1))
        //    walkPointSet = true;
    }

    Vector3 GetRandomPointOnNavMesh()
    {
        // Get the bounds of the NavMeshSurface in local space
        Bounds navMeshBounds = surface.navMeshData.sourceBounds;

        // Convert the bounds to world space by applying the NavMeshSurface's transform
        Vector3 navMeshCenterInWorld = surface.transform.position;
        Quaternion navMeshRotationInWorld = surface.transform.rotation;
        Vector3 navMeshScaleInWorld = surface.transform.lossyScale;

        // Apply the transform to the bounds corners to get the bounds in world space
        Vector3 min = surface.transform.TransformPoint(navMeshBounds.min);
        Vector3 max = surface.transform.TransformPoint(navMeshBounds.max);

        // Generate a random point within the NavMesh bounds (world space)
        Vector3 randomPoint = new Vector3(
            Random.Range(min.x, max.x),
            surface.transform.position.y, // Temporarily set Y to 0, will correct below
            Random.Range(min.z, max.z)
        );

        return randomPoint;


        // Check if the generated point is on the NavMesh
        //NavMeshHit hit;
        //if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        //{
        //    // Return the valid NavMesh point
        //    return hit.position;
        //}

        // If not valid, return Vector3.zero, which will make the agent search for a new point
        //return Vector3.zero;
    }

    // chase and attack 
    void Chase()
    {
        agent.SetDestination(playerTarget.position);
        // we can include the attack and other AI elements in here later on 

        transform.LookAt(playerTarget);
    }


    // mob touches player and sends back to start point 
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Teleport the player to their starting position
            Transform playerTransform = playerRespawnPoint.transform;
            collision.gameObject.transform.position = Vector3.zero;
        }
    }


}
// will likely kill the player, lead to game over, or restart level when touched 