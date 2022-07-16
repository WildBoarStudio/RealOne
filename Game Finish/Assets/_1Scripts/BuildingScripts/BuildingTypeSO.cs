using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    //ScriptableObject holding the following information
    public ResourceAmount[] constructionResourceCostArray;
    public ResourceGeneratorData resourceGeneratorData;
    public string nameString;
    private ResourceTypeSO resourceType;
    private Image icon;
    private ResourceTypeListSO buildingCost;
    private AudioSource sound;
    public Transform buildingPrefab;
    public Sprite sprite;
}
