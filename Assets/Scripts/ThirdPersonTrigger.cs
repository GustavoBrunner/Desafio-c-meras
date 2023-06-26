using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CameraController controller = other.GetComponent<CameraController>();
        if (controller != null )
        {
            Debug.Log("Camera dentro");
            Events.camAttachedThird.Invoke();
        }
    }
}
