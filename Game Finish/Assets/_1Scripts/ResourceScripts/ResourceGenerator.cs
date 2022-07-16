using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float timerMax;
    private BuildingTypeSO buildingType;

    private void Awake()
    {
        buildingType = GetComponent<BuildingTypeHolder>().buildingTypeSO;
    }

    void Update()
    {
        CheckResourceTimer();   
    }

    private void CheckResourceTimer()
    {
        //deduct real time from the timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //if the timer goes lower then 0 we go into the resource manager instance and add resources accordingly, then update it in the resources UI so the user can see
            // set timer back to the maximum
            //IN FUTURE THIS WILL BE CHANGED
            timer = timerMax;
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);
            ResourcesUI.Instance.UpdateResourceAmount();
        }
    }
}
