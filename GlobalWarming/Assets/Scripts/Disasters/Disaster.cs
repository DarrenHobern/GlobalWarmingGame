using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO make strenght-weakness table so picking a strength automatically indicates its weaknesses.
///      Also disallow picking clashing elements... maybe
/// </summary>
[System.Serializable]
public class Element
{
    [Header("Element Type")]
    public bool fire;
    public bool water;
    public bool earth;
    public bool air;
    public bool ice;
    public bool disease;
    public bool electricity;

}

public class Disaster : MonoBehaviour {

    [SerializeField] Element element;



}
