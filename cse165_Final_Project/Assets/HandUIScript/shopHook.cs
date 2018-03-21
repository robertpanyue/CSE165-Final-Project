using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopHook : MonoBehaviour {

    public GameObject hooknumber1;
    public GameObject hooknumber2;
    public GameObject money;
    private int number = 0;
    private int currmoney = 0;

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            currmoney = int.Parse(money.GetComponent<Text>().text);
            if (currmoney >= 5)
            {
                number = int.Parse(hooknumber1.GetComponent<Text>().text);
                number++;
                hooknumber1.GetComponent<Text>().text = number.ToString();
                hooknumber2.GetComponent<Text>().text = number.ToString();
                currmoney = currmoney - 5;
                money.GetComponent<Text>().text = currmoney.ToString();
            }
        }
    }
}
