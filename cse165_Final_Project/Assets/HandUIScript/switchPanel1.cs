using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPanel1 : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject toolsPanel;
    public GameObject settingPanel;

    void OnTriggerExit(Collider other)
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(true);

    }
}
