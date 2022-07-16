using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    private BuildingTypeSO buildingTypeSO;
    private RaycastHit hitInfo;
    private GameObject tooltipCheck;
    public void SetBuildingType(BuildingTypeSO buildingType)
    {
        //this function is called from the BuildingTypeSelectUI and gives each button the proper building associated to it
        buildingTypeSO = buildingType;
        Debug.Log(buildingType.nameString);
    }

    public BuildingTypeSO GetBuildingType()
    {
        return buildingTypeSO;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //on pointer enter , display proper information
        TooltipSystem.Show(buildingTypeSO.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //on pointer exit hide the tooltip
        TooltipSystem.Hide();
    }
}
