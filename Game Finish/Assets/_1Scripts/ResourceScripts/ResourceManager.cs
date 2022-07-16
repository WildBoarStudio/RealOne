using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    //THIS CLASS IS THE MAIN RESOURCE CLASS.
    //Holds the dictionary for all the resources , has add , check , deduct functions accordingly
    //Class is a single instance , Singleton

    public static ResourceManager Instance { get; private set; }

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake()
    {
        //Sets the singleton pattern instance , initializes dictionary and loads resource type list from the resources folder , gives certain amount
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach(ResourceTypeSO resourceType in resourceTypeList.list  )
        {
            resourceAmountDictionary[resourceType] = 100;
        }
    }

    private void TestLogResourceAmountDictionary ()
    {
        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        //Adds resources to the proper type in the dictionary
        resourceAmountDictionary[resourceType] += amount;
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        //Checks amount of a certain resource type
        return resourceAmountDictionary[resourceType];
    }

    public void SpendResources(ResourceAmount[] resourceAmountArray)
    {
        //Takes an array of resources and spends them accordingly
        foreach(ResourceAmount resourceAmount in resourceAmountArray)
        {
            resourceAmountDictionary[resourceAmount.resourceType] -= resourceAmount.amount;
        }
    }

    public bool CanAfford(ResourceAmount[] resourceAmmountArray)
    {
        //Checks if we have enough of the resources needed , returns true/false accordingly
        foreach(ResourceAmount resourceAmount in resourceAmmountArray)
        {
            if(GetResourceAmount(resourceAmount.resourceType) < resourceAmount.amount)
            {
                TooltipSystem.Show("Not Enough " + resourceAmount.resourceType.nameString);
                return false;
            }
        }

        return true;
    }

}
