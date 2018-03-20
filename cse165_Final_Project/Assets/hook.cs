using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour {

    // ray
    public GameObject user;
    public GameObject laser;
    public GameObject test;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!hooked)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 10);

            Ray ray = new Ray(transform.position, transform.forward);
            // laser.transform.position = transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "box" || hit.collider.tag == "cow")
                {
                    Debug.Log("hooooooooooooooooooooooooooooooooooooooooooooook");
                    Debug.Log(OVRInput.Get(OVRInput.RawButton.RThumbstick));
                    if (OVRInput.Get(OVRInput.RawButton.RThumbstick))
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
           
            if (OVRInput.Get(OVRInput.RawButton.RHandTrigger) || OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.LThumbstick))
            {
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
                if (diff < 0)
                {
                    selectedBox.transform.Translate(-diff*10, 0, 0);
                }
                Debug.Log(diff);
            }
            else if (OVRInput.GetUp(OVRInput.RawButton.LThumbstick))
            {
                
            }
        }
    }

}
