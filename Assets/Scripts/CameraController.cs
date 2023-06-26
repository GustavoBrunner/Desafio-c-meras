using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraController : MonoBehaviour
{
    protected Transform tf;
    protected Transform camPlace;
    protected Transform ThirdPcamPlace;
    private float m_horizontal;
    private float m_vertical;
    private Quaternion c_rotation;
    private float rot_speed = 400;
    private float x_rot;
    private float y_rot;
    [SerializeField]
    protected Transform Orientation;
    [SerializeField]
    protected GameObject[] cams = new GameObject[5];
    protected int CamIndex;
    protected float transition_speed = 12f;
    protected bool isFirstPerson;
    protected bool isThirdPerson;
    protected bool isDollyActive;
    virtual protected void Awake()
    {
        tf = GetComponent<Transform>();
        camPlace = GameObject.FindGameObjectWithTag("CamPlaceHolder")
            .GetComponent<Transform>();
        ThirdPcamPlace = GameObject.FindGameObjectWithTag("ThirdPCamPlaceHolder")
            .GetComponent<Transform>();
        Orientation = GameObject.FindGameObjectWithTag("Orientation")
            .GetComponent<Transform>();
        //Events.camAttachedFirst.AddListener(AttachFirstPCam);
        //Events.camAttachedThird.AddListener(AttachThirdPCam);
        transform.position = camPlace.transform.position;
        
        isDollyActive = false;
        isFirstPerson = true;
        isThirdPerson = false;

        foreach (var cam in cams)
        {
            if(cam.gameObject.name != "CameraContainerFixa")
            {
                cam.gameObject.SetActive(false);
            }
        }
    }
    
    protected virtual void SetCamActive()
    {
        this.gameObject.SetActive(true);
    }
    protected virtual void SetCamInactive()
    {
        this.gameObject.SetActive(false);
    }
    protected virtual void MoveCam()
    {
        
    }
    protected virtual void Update()
    {
        UpdatePosition();
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            isFirstPerson = false;
            isThirdPerson = true;
            Debug.Log("Primeira pessoa");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            isThirdPerson = false;
            isFirstPerson = true;
            Debug.Log("Terceira pessoa");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            isDollyActive = true;
            Events.Dolly.Invoke(isDollyActive);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            isDollyActive = false;
            Events.Dolly.Invoke(isDollyActive);
        }

    }
    private void UpdatePosition()
    {
        UpdateCamPosition();

        m_vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * rot_speed;
        m_horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * rot_speed;
        y_rot += m_horizontal;
        x_rot -= m_vertical;

        if (isFirstPerson)
        {
            x_rot = Mathf.Clamp(x_rot, -90, 90);
            //Debug.Log($"{x_rot}");
        }
        if(isThirdPerson)
        {
            x_rot = Mathf.Clamp(x_rot, -45, 25);
            //Debug.Log($"{x_rot}");  
        }
        this.tf.rotation = Quaternion.Euler(x_rot, y_rot, 0f);
        Orientation.rotation = Quaternion.Euler(0f, y_rot, 0f);

        Events.rotatePlayer.Invoke(x_rot, y_rot);

        
    }
    private void ThirdPersonActive()
    {
        
        transform.position = Vector3.Lerp(transform.position,
            ThirdPcamPlace.position,
            transition_speed * Time.deltaTime);
        
    }
    private void FirstPersonActive()
    {
        transform.position = Vector3.Lerp(transform.position,
            camPlace.position,
            transition_speed * Time.deltaTime);
        
    }
    private void UpdateCamPosition()
    {
        if(isFirstPerson)
        {
            FirstPersonActive();
        }
        if(isThirdPerson)
        {
            ThirdPersonActive();
        }
    }
    
    protected virtual void PlayAnimationOn(string cam)
    {
        Debug.Log("AnimationPlaying - Turning cam On");
    }
    protected virtual void PlayAnimationOff()
    {
        Debug.Log("AnimationPlaying - Turning cam Off");
    }
    protected virtual void PlayAnimationOnDolly()
    {
        //teste
    }
}
