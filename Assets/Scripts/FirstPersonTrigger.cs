using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CameraController controller = other.GetComponent<CameraController>();
        if (controller != null)
        {
            Debug.Log("Camera dentro");
            Events.camAttachedFirst.Invoke();
        }
    }
}
