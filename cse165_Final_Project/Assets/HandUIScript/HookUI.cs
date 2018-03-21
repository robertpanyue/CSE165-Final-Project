using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookUI : MonoBehaviour {
    public GameObject HandMenu;
    public GameObject hooknumber;
    private int number = 0;
   

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            number = int.Parse(hooknumber.GetComponent<Text>().text);
            if (number > 0)
            {
                Debug.Log("hook UIIIIIIIIIIIIIIIIIIIII");
                number--;
                GameObject.Find("RightHandAnchor").GetComponent<hook>().enabled = true;
                hooknumber.GetComponent<Text>().text = number.ToString();
                HandMenu.SetActive(false);
            }

        }
    }
}
