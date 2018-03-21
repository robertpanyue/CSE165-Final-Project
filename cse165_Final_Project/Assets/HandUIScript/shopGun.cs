using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopGun : MonoBehaviour {
    
    public GameObject gunnumber1;
    public GameObject gunnumber2;
    public GameObject money;
    private int number = 0;
    private int currmoney = 0;

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            currmoney = int.Parse(money.GetComponent<Text>().text);
            if (currmoney >= 10)
            {
                number = int.Parse(gunnumber1.GetComponent<Text>().text);
                number++;
                gunnumber1.GetComponent<Text>().text = number.ToString();
                gunnumber2.GetComponent<Text>().text = number.ToString();
                currmoney = currmoney - 10;
                money.GetComponent<Text>().text = currmoney.ToString();
            }
        }
    }
}
