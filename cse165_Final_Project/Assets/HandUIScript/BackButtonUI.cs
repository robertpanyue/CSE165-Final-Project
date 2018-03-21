using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonUI : MonoBehaviour {
    public GameObject panel1;
    public GameObject panel2;
    private float time;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
    }
}
