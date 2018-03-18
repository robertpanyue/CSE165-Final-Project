using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHandUI : MonoBehaviour {
    public GameObject HandMenu;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("touchtouch----------");
        HandMenu.SetActive(true);
    }
}
