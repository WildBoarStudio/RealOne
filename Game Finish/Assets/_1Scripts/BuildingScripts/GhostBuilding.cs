using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBuilding : MonoBehaviour
{
    [SerializeField] private int vectorDistance;
    [SerializeField] private BuildingTypeSO buildingType;

    private Vector3 mouseVector;
    private RaycastHit hitInfo;

    public LayerMask whatCanBeBuiltOn;
    private Vector3 yVector;
    public BuildingManager buildingManager;
    private BuildingTypeListSO buildingTypeList;

    public bool ghostBuilding = true;


    void Start()
    {
        //Grab proper refferences and set a y scale
        buildingType = GetComponent<BuildingTypeHolder>().buildingTypeSO;
        buildingManager = GameObject.Find("GameManager").GetComponent<BuildingManager>();
        mouseVector = Input.mousePosition;
        yVector = new Vector3(0, this.transform.localScale.y, 0);

        //set the building to proper rotation
        this.transform.Rotate(0, 0, 0);
    }

    void Update()
    {
        CheckBuildingRotation();
        CheckMouseMovement();
        TryBuilding();
    }

    private void CheckBuildingRotation()
    {
        //if player presses t then building spins 90 degrees
        if(Input.GetKeyDown(KeyCode.T))
        {
            this.transform.Rotate(0, transform.rotation.y + 90, 0);
        }
    }

    private void CheckMouseMovement()
    {
        // Cast ray only when mouse is moving so we don't have to move it every frame , position of the building that is being built

        if (mouseVector != Input.mousePosition)
        {
            mouseVector = Input.mousePosition;
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hitInfo, vectorDistance, whatCanBeBuiltOn))
            {

                //this.transform.position = hitInfo.point + yVector;
                this.transform.position = hitInfo.point + yVector / 2;
            }
        }
    }

    private void TryBuilding()
    {
        //if presses left mouse button but can't build return proper error message to tool tip
        if (Input.GetMouseButtonDown(0))
        {
            if (!ResourceManager.Instance.CanAfford(buildingType.constructionResourceCostArray))
            {
                return;
            }
            if (!BuildingManager.Instance.CanSpawn(buildingType, this.transform.position))
            {
                Debug.Log("No");
                return;
            }

            //if can build , deduct resources , set is building to false , set all needed scripts and others to the settings needed , turn this script off

            ResourceManager.Instance.SpendResources(buildingType.constructionResourceCostArray);
            buildingManager.isBuilding = false;
            GetComponent<ResourceGenerator>().enabled = true;
            GetComponent<CantBuildOn>().hasbeenBuilt = true;
            this.enabled = false;
        }
    }
}
