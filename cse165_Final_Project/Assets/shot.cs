using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {

    public ParticleSystem muzzleFlash;
    private GameObject nextBox;
    public GameObject flame;
    private int count;
    private bool destroyed;
	// Use this for initialization
	void Start () {
        nextBox = null;
        count = 0;
        destroyed = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            muzzleFlash.Play();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject impact = Instantiate(flame, hit.point, Quaternion.LookRotation(hit.normal));
            
                Destroy(impact, 2f);

                nextBox = GameObject.Find("player").GetComponent<movement>().getNextBox();
                //Debug.Log(hit.collider.tag);

                if (hit.collider.gameObject == nextBox)
                {
                    count++;
                    if (count > 10)
                    {
                        Destroy(nextBox);
                        count = 0;
                        destroyed = true;
                        GameObject.Find("player").GetComponent<movement>().setJumpMode(true);
                        GameObject.Find("gun").SetActive(false);
                    }


                }
            }
        }

    }

    public void setDestroy(bool a)
    {
        destroyed = a;
    }


    public bool getDestroy()
    {
        return destroyed;
    }
}
