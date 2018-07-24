using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targetable : MonoBehaviour {

    [Tooltip("in seconds")][SerializeField] protected float channelDuration = 3f;
    protected float channelTime = 0;
    public abstract void Channel(float power);  //TODO better name please
    
    public void ResetChannel()
    {
        channelTime = 0;
    }
}
