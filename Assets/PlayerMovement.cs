using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Transform temple; // Reference to the temple GameObject
    public Transform peoplesCentre; // Reference to the people's center GameObject
    public Transform hotel; // Reference to the hotel GameObject
    public NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component
    public GameManager gameManager;
    // Enum to define the possible destinations
    public enum Destination
    {
        Temple,
        PeoplesCentre,
        Hotel
    }
    public Destination currentDestination; // Current destination the player is heading towards

    void Start()
    {
        // Get the NavMeshAgent component attached to the same GameObject as this script
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Start by visiting the temple
        VisitTemple();
    }

    // Method to visit the temple
    public void VisitTemple()
    {
        // Check if the temple reference is set
        if (temple != null)
        {
            // Set the destination for the NavMeshAgent to the temple's position
         //   navMeshAgent.SetDestination(temple.position);
         //
            currentDestination = Destination.Temple; // Update the current destination
        }
        else
        {
            Debug.LogError("Temple reference is not set in PlayerMovement script!");
        }
    }
    
   
    // Method to visit the people's centre
    public void VisitPeoplesCentre()
    {
        // Check if the people's centre reference is set
        if (peoplesCentre != null)
        {
            // Set the destination for the NavMeshAgent to the people's centre's position
            navMeshAgent.SetDestination(peoplesCentre.position);
            currentDestination = Destination.PeoplesCentre; // Update the current destination
        }
        else
        {
            Debug.LogError("People's Centre reference is not set in PlayerMovement script!");
        }
    }

    // Method to visit the hotel
    public void VisitHotel()
    {
        // Check if the hotel reference is set
        if (hotel != null)
        {
            // Set the destination for the NavMeshAgent to the hotel's position
            navMeshAgent.SetDestination(hotel.position);
            currentDestination = Destination.Hotel; // Update the current destination
        }
        else
        {
            Debug.LogError("Hotel reference is not set in PlayerMovement script!");
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger zone of this GameObject
    void OnTriggerEnter(Collider other)
    {   
          // Check if the collider belongs to one of the specific buildings
        if (other.CompareTag("Temple") || other.CompareTag("Peoples Centre") || other.CompareTag("Hotel"))
        {
            // Increase player score by 3 if the player reaches a specific building
            if (gameManager != null)
            {
                gameManager.IncreasePlayerScore(3);
            }
            else
            {
                Debug.LogError("GameManager not found in the scene!");
            }
        }
            // Check if the collider belongs to one of the specific buildings
       

        // Check the last visited destination to determine the next destination
        switch (currentDestination)
        {
            case Destination.Temple:
                VisitPeoplesCentre();
                break;
            case Destination.PeoplesCentre:
                VisitHotel();
                break;
            case Destination.Hotel:
                // You can add additional logic here if needed, or you can loop back to the temple
               // break;
                 VisitPeoplesCentre();
                break;
            default:
                Debug.LogError("Invalid destination!");
                break;
        }
    }
}