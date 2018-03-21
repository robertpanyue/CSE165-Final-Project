using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHandMenu : MonoBehaviour {
    public GameObject Canvas;
    public GameObject Player;
    void OnTriggerExit(Collider other)
    {
        Player.GetComponent<movement>().setJumpMode(true);
        Canvas.SetActive(false);    
    }
}
