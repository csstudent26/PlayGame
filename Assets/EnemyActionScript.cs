using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActionScript : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public Transform ammunitionStore; // Reference to the ammunition store GameObject
    public Transform restaurant; // Reference to the restaurant GameObject
    public int points = 0; // Points accumulated by the enemy
    public NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SeekPlayer();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player detected, add points
            points += 5;
            Debug.Log("Enemy found the player! Points: " + points);
            // Go to ammunition store
            GoToLocation(ammunitionStore);
        }
        else if (other.CompareTag("AmmunitionStore"))
        {
            // Reached ammunition store, go to restaurant
            GoToLocation(restaurant);
        }
        else if (other.CompareTag("Restaurant"))
        {
            // Reached restaurant, seek player again
            SeekPlayer();
        }
    }

    public void SeekPlayer()
    {
        // Set destination to player's position
        navMeshAgent.SetDestination(player.position);
    }

    public void GoToLocation(Transform destination)
    {
        // Set destination to the specified location
        navMeshAgent.SetDestination(destination.position);
    }
}
