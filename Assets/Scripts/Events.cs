using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FloatEvent : UnityEvent<float, float> { } 
public class BoolEvent : UnityEvent<bool> { }
public class TriggerAlternationCam : UnityEvent<bool, bool, bool> { }
public class Events 
{
    public static UnityEvent ChangeCam = new UnityEvent();
    public static UnityEvent ChangeCam1 = new UnityEvent();
    public static BoolEvent Dolly = new BoolEvent();

    public static FloatEvent rotatePlayer = new FloatEvent();
    
    public static UnityEvent camAttachedFirst = new UnityEvent();
    public static UnityEvent camAttachedThird = new UnityEvent();

    public static TriggerAlternationCam TriggerAlternationCam = new TriggerAlternationCam();

}
