using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setName : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(PlayerPrefs.GetString("name"));
        this.GetComponent<Text>().text = PlayerPrefs.GetString("name");
    }
}
