using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
    //Scriptable Object holds data for the name of resource and sprite
    public string nameString;
    public Sprite sprite;
}
