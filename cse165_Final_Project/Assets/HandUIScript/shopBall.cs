using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopBall : MonoBehaviour {


    public GameObject ballnumber1;
    public GameObject ballnumber2;
    public GameObject money;
    private int number = 0;
    private int currmoney = 0;

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            currmoney = int.Parse(money.GetComponent<Text>().text);
            if (currmoney >= 2)
            {
                number = int.Parse(ballnumber1.GetComponent<Text>().text);
                number++;
                ballnumber1.GetComponent<Text>().text = number.ToString();
                ballnumber2.GetComponent<Text>().text = number.ToString();
                currmoney = currmoney - 2;
                money.GetComponent<Text>().text = currmoney.ToString();
            }
        }
    }
}
