using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{ 

    
    // Start is called before the first frame update
   public Transform player; // Reference to the player GameObject
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        // Get the NavMeshAgent component attached to the same GameObject as this script
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Check if the player reference is not null
        if (player == null)
        {
            Debug.LogError("Player reference is not set in EnemyMovement script!");
        }
    }

    void Update()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Set the destination for the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);
        }
}

}