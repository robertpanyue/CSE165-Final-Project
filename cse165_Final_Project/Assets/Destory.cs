using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoty : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "StartCube")
        {
            Destroy(collision.gameObject);
        }
    }
}
