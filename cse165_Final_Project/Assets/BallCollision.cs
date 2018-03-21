using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    private GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {

        float dis = Vector3.Distance(Player.transform.position, transform.position);
	    if (dis > 0) {
            Player.GetComponent<movement>().setJumpMode(true);  
        }
        Debug.Log(dis);
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "soda")
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
