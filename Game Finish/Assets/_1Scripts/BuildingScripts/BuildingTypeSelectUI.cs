using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{

    BuildingTypeListSO buildingTypeList;
    GameObject[] arr;
    Transform btnTemplate;
    ButtonScript buttonScript;

    private void Start()
    {
        GetRefferences();
        CycleButtons();
    }

    public void GetRefferences()
    {
        //grab refferences and sets true / false what is needed

        btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);
        btnTemplate.gameObject.AddComponent<Outline>();
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buttonScript = btnTemplate.GetComponent<ButtonScript>();
        if (buttonScript == null) Debug.Log("REEE");
    }

    public void CycleButtons()
    {
        //cycles through building buttons adds the proper functions and stores in array so we can turn off and on

        int index = 0;

        arr = new GameObject[buildingTypeList.List.Count + 1];
        arr[0] = btnTemplate.gameObject;
        foreach (BuildingTypeSO buildingType in buildingTypeList.List)
        {
            //for each building type we instantiate our button template , set it active store in array , move it to the correct position and set the image as the buildng sprite
            // afterwards we get the onclick and add a function to it that will make the button match with the certain buildingtype
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);
            arr[index] = btnTransform.gameObject;
            float offsetAmount = 160f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            btnTransform.Find("Image").GetComponent<Image>().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.buildBuilding(buildingType);

            });
            btnTransform.GetComponent<ButtonScript>().SetBuildingType(buildingType);
            index++;
        }
    }

    public void OnClick()
    {
        //Cycles through buttons and hides , shows
        for(int i = 0; i< buildingTypeList.List.Count; i++)
        {
            arr[i].SetActive(!arr[i].gameObject.activeSelf);
        }
    }

}
