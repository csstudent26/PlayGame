using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public Transform ammunitionStore; // Reference to the ammunition store GameObject
    public Transform restaurant; // Reference to the restaurant GameObject
    public NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component
    public GameManager gameManager; // Reference to the PlayerManager

    // Enum to define the possible destinations
    public enum Destination
    {
        Player,
        AmmunitionStore,
        Restaurant
    }
    public Destination currentDestination; // Current destination the enemy is heading towards

    void Start()
    {
        // Get the NavMeshAgent component attached to the same GameObject as this script
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Start by visiting the player
        VisitPlayer();
    }

    // Method to visit the player
    public void VisitPlayer()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Set the destination for the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);
            currentDestination = Destination.Player; // Update the current destination
        }
        else
        {
            Debug.LogError("Player reference is not set in EnemyMovement script!");
        }
    }

    // Method to visit the ammunition store
    public void VisitAmmunitionStore()
    {
        // Check if the ammunition store reference is set
        if (ammunitionStore != null)
        {
            // Set the destination for the NavMeshAgent to the ammunition store's position
            navMeshAgent.SetDestination(ammunitionStore.position);
            currentDestination = Destination.AmmunitionStore; // Update the current destination
        }
        else
        {
            Debug.LogError("Ammunition Store reference is not set in EnemyMovement script!");
        }
    }

    // Method to visit the restaurant
    public void VisitRestaurant()
    {
        // Check if the restaurant reference is set
        if (restaurant != null)
        {
            // Set the destination for the NavMeshAgent to the restaurant's position
            navMeshAgent.SetDestination(restaurant.position);
            currentDestination = Destination.Restaurant; // Update the current destination
        }
        else
        {
            Debug.LogError("Restaurant reference is not set in EnemyMovement script!");
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger zone of this GameObject
    void OnTriggerEnter(Collider other)
    {    // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Increase enemy score when enemy reaches the player
            if (gameManager != null)
            {
                gameManager.IncreaseEnemyScore(1);
            }
            else
            {
                Debug.LogError("PlayerManager not found in the scene!");
            }
        }
        // Check the last visited destination to determine the next destination
        switch (currentDestination)
        {
            case Destination.Player:
                VisitAmmunitionStore();
                break;
            case Destination.AmmunitionStore:
                VisitRestaurant();
                break;
            case Destination.Restaurant:
                VisitPlayer();
                break;
            default:
                Debug.LogError("Invalid destination!");
                break;
        }
    }
}