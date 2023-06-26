using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController _instance 
    { 
        get
        {
            return instance;
        }    
            private set { } 
    }

    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
