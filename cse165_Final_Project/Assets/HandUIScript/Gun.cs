using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour {
    public GameObject gun;
    public GameObject HandMenu;
    public GameObject Player;
    public GameObject gunnumber;
    private int number = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            number = int.Parse(gunnumber.GetComponent<Text>().text);
            if (number > 0)
            {
                gun.SetActive(true);
                number--;
                gunnumber.GetComponent<Text>().text = number.ToString();
                HandMenu.SetActive(false);
            }

        }
    }
}
