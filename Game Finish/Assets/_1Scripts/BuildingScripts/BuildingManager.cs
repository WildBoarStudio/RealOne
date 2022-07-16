using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    [SerializeField] private BuildingTypeListSO buildingTypeList;
    public bool isBuilding = false;
    void Start()
    {
        //Set the instance of the singleton, load all buildingTypes from resources folder
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingTypeListSO");
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(buildingTypeList.List[0]);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(buildingTypeList.List[1]);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(buildingTypeList.List[2]);
        }
    }

    public void buildBuilding(BuildingTypeSO building)
    {
        //called from the buttons when pressed on , sets building mode to true and Instantiates the ghostBuilding
        isBuilding = true;
        Instantiate(building.buildingPrefab);
    }

    public bool CanSpawn(BuildingTypeSO buildingType, Vector3 buildingPosition)
    {
        //checks the size of the building prefab
        Vector3 boxLimit = buildingType.buildingPrefab.GetComponent<BoxCollider>().size;
        float box = Mathf.Max(boxLimit.x, boxLimit.y);
        box = Mathf.Max(box , boxLimit.z);

        //after finding the largest x,y,z it checks in a sphere around that size + a certain offset if there are any
        //objects with the "CantBuildOn" component on them , returns false if so
        Collider [] colliders = Physics.OverlapSphere(buildingPosition, box + 5f);
        foreach(Collider collider in colliders)
        {
            if(collider.GetComponent<CantBuildOn>() != null && collider.GetComponent<CantBuildOn>().hasbeenBuilt == true)
            {
                return false;
            }
        }

        return true;
    }

}
