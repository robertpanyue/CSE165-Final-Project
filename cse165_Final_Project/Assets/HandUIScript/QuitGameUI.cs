using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameUI : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
