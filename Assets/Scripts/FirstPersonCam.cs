using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonCam : CameraController
{
    [SerializeField]
    private Animator animator;
    private Canvas canvas;
    protected override void Awake()
    {
        base.Awake();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //canvas.gameObject.SetActive(false);
        Events.Dolly.AddListener(TurnCamOff);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //MoveCam();
    }

    
    protected override void PlayAnimationOn(string cam)
    {
        if(cam == "Fix")
        {
            this.animator.SetTrigger("TurnFixOn");
        }
    }
    protected override void PlayAnimationOff()
    {
        this.animator.SetTrigger("TurnFixOff");
    }
    protected void TurnCamOff(bool b)
    {
        if(b) 
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
