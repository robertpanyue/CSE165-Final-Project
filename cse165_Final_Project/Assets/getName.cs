using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour {
	void Update () {
       
        PlayerPrefs.SetString("name", GetComponent<Text>().text);
        Debug.Log(PlayerPrefs.GetString("name"));
    }
}
