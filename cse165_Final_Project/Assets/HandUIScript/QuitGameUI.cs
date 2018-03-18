using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameUI : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
