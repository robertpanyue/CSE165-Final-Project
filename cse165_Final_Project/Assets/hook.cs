using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour {

    // ray
    public GameObject laser;
    private LineRenderer line;
    private GameObject selectedBox;
    public GameObject lefthand;
    private bool hooked = false;

    private float preHandPosition;
    private float currHandPosition;
    // Use this for initialization
    void Start () {
        
        laser.transform.position = transform.position;
        line = laser.GetComponent<LineRenderer>();
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        preHandPosition = 0.0f;
        hooked = false;
    }

    // Update is called once per frame
    void Update()
    {
        laser.SetActive(true);
        Debug.Log("hook update");
        if (!hooked)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 10);

            Ray ray = new Ray(transform.position, transform.forward);
            // laser.transform.position = transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "box" || hit.collider.tag == "cow" || hit.collider.tag == "car" || hit.collider.tag == "canbox" || hit.collider.tag == "shop"
                    || hit.collider.tag == "table" || hit.collider.tag == "clock" || hit.collider.tag == "d" || hit.collider.tag == "music" || hit.collider.tag == "hat")
                {
                    Debug.Log("hooooooooooooooooooooooooooooooooooooooooooooook");
                    Debug.Log(OVRInput.Get(OVRInput.RawButton.RThumbstick));
                    if (OVRInput.GetUp(OVRInput.RawButton.RThumbstick))
                    {
                        line.SetPosition(0, transform.position);
                        line.SetPosition(1, transform.position + transform.forward * 10);
                        hooked = true;
                        selectedBox = hit.transform.gameObject;
                    }
                }
            }
        }
        else
        {
           
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            {
                float distance = Vector2.Distance(selectedBox.transform.position, transform.position);
                currHandPosition = lefthand.transform.position.z;
                float diff = 0;
                if (preHandPosition == 0)
                {
                    preHandPosition = lefthand.transform.position.z;
                }
                else
                {
                    diff = currHandPosition - preHandPosition;
                    preHandPosition = currHandPosition;
                }
                if (diff < 0 && distance > 5.5)
                {
                    selectedBox.transform.Translate(-diff*10, 0, 0);
                }
            }
            if (OVRInput.GetUp(OVRInput.RawButton.RThumbstick))
            {
                Debug.Log("cancel hook");
                hooked = false;
                laser.SetActive(false);
                GameObject.Find("RightHandAnchor").GetComponent<hook>().enabled = false;
                GameObject.Find("player").GetComponent<movement>().setJumpMode(true);
            }
        }
    }

}
