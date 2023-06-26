using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCamTrigger : MonoBehaviour, ICamTrigger
{
    public bool fc { get => false; }

    public bool tc { get => true; }

    public bool dc { get => false; }

    public void ActiveCam()
    {
        Events.TriggerAlternationCam.Invoke(fc, tc, dc);
    }
}
