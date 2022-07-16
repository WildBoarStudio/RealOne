using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    public BuildingManager buildingManager;
    public GhostBuilding ghostBuilding;

    private NavMeshAgent navMeshAgent;
    private RaycastHit hitInfo;

    private void Start()
    {
        // Grab Refferences
        navMeshAgent = GetComponent<NavMeshAgent>();
        buildingManager = GameObject.Find("GameManager").GetComponent<BuildingManager>();
    }
    private void Update()
    {
        CheckMouseClick();
    }

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
           //buildingmanager is building gets set to true when we are building so we don't want to move when we are building
            if (buildingManager.isBuilding == true)
            {
                return;
            }

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                navMeshAgent.ResetPath();
                navMeshAgent.SetDestination(hitInfo.point);
            }
        }
        
    }
}
