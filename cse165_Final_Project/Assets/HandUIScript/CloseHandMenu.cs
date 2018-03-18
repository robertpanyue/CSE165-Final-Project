using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHandMenu : MonoBehaviour {
    public GameObject Canvas;

    void OnTriggerEnter(Collider other)
    {
        Canvas.SetActive(false);    
    }
}
