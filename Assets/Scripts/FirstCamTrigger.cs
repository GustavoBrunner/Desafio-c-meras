using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamTrigger : MonoBehaviour, ICamTrigger
{
    public bool fc { get => true; } 
    public bool tc { get => false; }
    public bool dc { get => false; }

    public void ActiveCam()
    {
        Events.TriggerAlternationCam.Invoke(fc, tc, dc);
    }
}
