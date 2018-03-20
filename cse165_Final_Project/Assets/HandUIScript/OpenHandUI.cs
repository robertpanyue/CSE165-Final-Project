using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHandUI : MonoBehaviour {
    public GameObject HandMenu ;


    void OnTriggerExit(Collider other)
    { 
        if (other.CompareTag("rightHand"))
        {
            HandMenu.SetActive(true);
        }
    }
}
