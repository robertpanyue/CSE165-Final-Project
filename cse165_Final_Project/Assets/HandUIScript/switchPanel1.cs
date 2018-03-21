using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPanel1 : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject toolsPanel;
    public GameObject settingPanel;

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            mainPanel.SetActive(false);
            settingPanel.SetActive(true);
        }
    }
}
