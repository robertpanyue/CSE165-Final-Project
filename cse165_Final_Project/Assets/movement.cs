using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public List<GameObject> blockList;
    private CharacterController controller;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject head;
    private float verticalVelocity;
    private float gravity = 30.0f;
    private float jumpForce = 12.0f;
    private Vector3 preHandPosition;
    private Vector3 releaseHandPosition;
    private float xdiff = 0f;
    private float zdiff = 0f;
    private int count = 1;
    private bool spawn =true;
    private Vector3 headforward;
    // Use this for initialization
    void Start() {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update() {
        if (controller.isGrounded)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
            {
                preHandPosition = new Vector3(Mathf.Min(leftHand.transform.position.x, rightHand.transform.position.x), Mathf.Min(leftHand.transform.position.y, rightHand.transform.position.y), Mathf.Min(leftHand.transform.position.z, rightHand.transform.position.z));
                Debug.Log("Down");
            }
            verticalVelocity = -gravity * Time.deltaTime;
            xdiff = 0;
            zdiff = 0;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            
        }

        Debug.Log(spawn);

        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) || OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            verticalVelocity = jumpForce;
            //calculate the diff
            releaseHandPosition = new Vector3(Mathf.Min(leftHand.transform.position.x, rightHand.transform.position.x), Mathf.Min(leftHand.transform.position.y, rightHand.transform.position.y), Mathf.Min(leftHand.transform.position.z, rightHand.transform.position.z));
            xdiff = Mathf.Abs(releaseHandPosition.x - preHandPosition.x);
            zdiff = Mathf.Abs(releaseHandPosition.z - preHandPosition.z);
            headforward = head.transform.forward;
            Debug.Log("Up");
            spawn = true;
            count = 1;
        }

        //make the movement
        Vector3 moveVector = Vector3.zero;
        moveVector.x = headforward.x * 70.0f * xdiff;
        moveVector.y = verticalVelocity;
        moveVector.z = headforward.z * 70.0f * zdiff;
        controller.Move(moveVector * Time.deltaTime);



        if (count <=1 && spawn && controller.isGrounded)
        {
            SpawnBlock();
            spawn = false;
        }

        count++;

 
    }


    void SpawnBlock()
    {
        int index = Random.Range(0, blockList.Count-1);
        int dir = Random.Range(0, 3);
        float dist = Random.Range(5f, 20.0f);
        switch (dir)
        {
            case 0:
                Instantiate(blockList[index], new Vector3 (transform.position.x + dist, transform.position.y-15f, transform.position.z), Quaternion.identity);
                break;
            case 1:
                Instantiate(blockList[index], new Vector3(transform.position.x - dist, transform.position.y-15f, transform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(blockList[index], new Vector3(transform.position.x , transform.position.y-15f, transform.position.z + dist), Quaternion.identity);
                break;
            case 3:
                Instantiate(blockList[index], new Vector3(transform.position.x, transform.position.y-15f, transform.position.z - dist), Quaternion.identity);
                break;
        }
        
    }
}



