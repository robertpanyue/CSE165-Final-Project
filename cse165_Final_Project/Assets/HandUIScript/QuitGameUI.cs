using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameUI : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        
    }
}
