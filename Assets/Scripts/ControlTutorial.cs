using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTutorial : MonoBehaviour
{
    public void setTurotialText()
    {  
        this.gameObject.SetActive(false); 
    }
    void Start()
    {
        Invoke("setTurotialText", 20f);
    }

    void Update()
    {
        
    }
}
