using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamTrigger : MonoBehaviour, ICamTrigger
{
    public bool fc { get => false; }

    public bool tc { get => false; }

    public bool dc { get => true; }

    public void ActiveCam()
    {
        Events.TriggerAlternationCam.Invoke(fc, tc, dc);
    }
}
