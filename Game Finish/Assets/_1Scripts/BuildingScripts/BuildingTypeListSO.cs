using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="ScriptableObjects/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject
{
    //scriptable object holds a list of buildings
    public List<BuildingTypeSO> List;
}
