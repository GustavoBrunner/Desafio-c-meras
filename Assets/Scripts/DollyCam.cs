using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollyCam : CameraController
{
    private CinemachineVirtualCamera dolly;
    [SerializeField]
    private Animator animator;
    private Canvas canvas;
    protected override void Awake()
    {
        base.Awake();
        dolly = GetComponent<CinemachineVirtualCamera>();
        dolly.m_Follow = GameObject.FindGameObjectWithTag("Player")
            .transform.Find("Render").GetComponent<Transform>();
        dolly.m_LookAt = GameObject.FindGameObjectWithTag("Player")
            .transform.Find("Render").GetComponent<Transform>();
        
        animator = GetComponent<Animator>();
        Events.Dolly.AddListener(SetDollyActive);
    }
    
    private void SetDollyActive(bool b)
    {
        Debug.Log("dolly ativada");
        gameObject.SetActive(b);
    }
    protected override void PlayAnimationOn(string cam)
    {
        if(cam == "Dolly")
        {
            this.animator.SetTrigger("DollyOn");
        }
    }
    protected override void PlayAnimationOff()
    {
        this.animator.SetTrigger("DollyOff");
    }
}
