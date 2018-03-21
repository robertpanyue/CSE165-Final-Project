using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHandUI : MonoBehaviour {
    public GameObject HandMenu;
    public GameObject Player;
    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "hands:b_r_index2")
        {
            Player.GetComponent<movement>().setJumpMode(false);
            HandMenu.SetActive(true);
        }
    }
}
