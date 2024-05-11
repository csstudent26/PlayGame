using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
   






    public int pointsPerFind = 5;
    public string ammunitionStoreTag = "AmmunitionStore";
    public int points = 0;
    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            points += pointsPerFind;
            Debug.Log("Enemy found the player! Points: " + points);
        }

        if (other.CompareTag(ammunitionStoreTag))
        {
            RefillAmmunition();
        }
    }

    private void RefillAmmunition()
    {
        // Logic to refill ammunition goes here
        Debug.Log("Enemy refilled ammunition at the Ammunition Store.");
    }

    public void NavigateToAmmunitionStore()
    {
        GameObject[] ammunitionStores = GameObject.FindGameObjectsWithTag(ammunitionStoreTag);
        if (ammunitionStores.Length > 0)
        {
            GameObject nearestAmmunitionStore = FindNearestAmmunitionStore(ammunitionStores);
            navMeshAgent.SetDestination(nearestAmmunitionStore.transform.position);
        }
        else
        {
            Debug.LogError("No Ammunition Store found in the scene.");
        }
    }

    private GameObject FindNearestAmmunitionStore(GameObject[] ammunitionStores)
    {
        GameObject nearestStore = null;
        float nearestDistance = Mathf.Infinity;
        foreach (GameObject store in ammunitionStores)
        {
            float distance = Vector3.Distance(transform.position, store.transform.position);
            if (distance < nearestDistance)
            {
                nearestStore = store;
                nearestDistance = distance;
            }
        }
        return nearestStore;
    }
}
