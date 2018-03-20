using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonUI : MonoBehaviour {
    public GameObject panel1;
    public GameObject panel2;

    private void OnTriggerExit(Collider other)
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
