using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : MonoBehaviour
{
    
    public Transform player; // Reference to the player GameObject
    public Transform ammunitionStore; // Reference to the ammunition store GameObject
    public Transform restaurant; // Reference to the restaurant GameObject
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        // Get the NavMeshAgent component attached to the same GameObject as this script
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Call the method to visit all destinations
        VisitAllDestinations();
    }

    public void VisitPlayer()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Set the destination for the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            Debug.LogError("Player reference is not set in EnemyPlayer script!");
        }
    }

    public void VisitAmmunitionStore()
    {
        // Check if the ammunition store reference is set
        if (ammunitionStore != null)
        {
            // Set the destination for the NavMeshAgent to the ammunition store's position
            navMeshAgent.SetDestination(ammunitionStore.position);
        }
        else
        {
            Debug.LogError("Ammunition Store reference is not set in EnemyPlayer script!");
        }
    }

    public void VisitRestaurant()
    {
        // Check if the restaurant reference is set
        if (restaurant != null)
        {
            // Set the destination for the NavMeshAgent to the restaurant's position
            navMeshAgent.SetDestination(restaurant.position);
        }
        else
        {
            Debug.LogError("Restaurant reference is not set in EnemyPlayer script!");
        }
    }

    public void VisitAllDestinations()
    {
        // Visit each destination sequentially
        VisitPlayer();
        WaitForDestinationReached(); // Wait for player destination to be reached before proceeding to the next destination

        VisitAmmunitionStore();
        WaitForDestinationReached(); // Wait for ammunition store destination to be reached before proceeding to the next destination

        VisitRestaurant();
        WaitForDestinationReached(); // Wait for restaurant destination to be reached
    }

    private void WaitForDestinationReached()
    {
        // Wait until the NavMeshAgent has reached its destination
        while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            // Wait until the agent has reached the destination
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Additional logic can be added here if needed
    }
}