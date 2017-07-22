using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ChangeColor : MonoBehaviour, ITrackableEventHandler
{
    //delivered cube of the scene
    public GameObject cube;
    Color green = new Color(0,1,0, 1);
    Color red = new Color(1, 0, 0, 1);

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    //checks for status changes
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //Trackable found
            cube.GetComponent<Renderer>().sharedMaterial.color = green;
        }
        else
        {
           // Trackable lost
            cube.GetComponent<Renderer>().sharedMaterial.color = red;
        }
    }
}