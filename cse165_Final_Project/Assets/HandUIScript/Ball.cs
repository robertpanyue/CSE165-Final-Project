using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public GameObject throwball;
    public GameObject HandMenu;
    public GameObject Player;
    public GameObject ballnumber;
    private int number = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            number = int.Parse(ballnumber.GetComponent<Text>().text);
            if (number > 0) { 
                Instantiate(throwball, Player.transform.position + new Vector3(Player.transform.forward.x * 0.9f, Player.transform.forward.y * 0.9f, Player.transform.forward.z * 0.9f), Quaternion.identity);
                number--;
                ballnumber.GetComponent<Text>().text = number.ToString();
                HandMenu.SetActive(false);
            }

        }
    }
}
