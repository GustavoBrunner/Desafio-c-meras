using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 10f;
    private Vector3 direction;
    private Rigidbody rb;
    [SerializeField]
    private Transform render;
    [SerializeField]
    private Transform orientation;
    private string movePhase = "normal";
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        render = GameObject.FindGameObjectWithTag("Render").GetComponent<Transform>();
        orientation = GameObject.Find("Sphere").GetComponent<Transform>();
    }
    protected virtual void Start()
    {
        Events.rotatePlayer.AddListener(RotatePlayer);
    }


    virtual protected void Update()
    {
        MovePlayer(movePhase);
    }

    private void RotatePlayer(float x, float y)
    {
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
    private void MovePlayer(string d)
    {
        switch (d)
        {
            case "direta":

                break;
            
            default:
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = Input.GetAxisRaw("Vertical");
                direction = orientation.forward * vertical + orientation.right * horizontal;
                rb.velocity = direction.normalized * speed;
                break;
        }

    }
    
}
