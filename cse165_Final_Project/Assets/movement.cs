using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Gazepoint;
    public GameObject Keyboard;

    public List<GameObject> blockList;
    private CharacterController controller;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject head;
    private float verticalVelocity;
    private float gravity = 50.0f;
    private float jumpForce = 19.5f;
    private Vector3 preHandPosition;
    private Vector3 releaseHandPosition;
    private float xdiff = 0f;
    private float zdiff = 0f;
    private int count = 1;
    private bool spawn = true;
    private Vector3 headforward;
    private bool jump = false;

    //score
    private int score;
    public GameObject scorePanel1;
    private GameObject nextBlock;
    public GameObject currBlock;
    private bool gameMode;
    private int index = 0;

    //gameMode
    public bool jumpMode;
    public bool throwMode;
    public bool gunMode;
    public bool hookMode;

    //shop
    public GameObject shopMenu;
    public GameObject mainMenu;
    public GameObject handMenu;
    public GameObject grabber;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpMode = true;
        throwMode = false;
        gunMode = false;
        hookMode = false;
        score = int.Parse(scorePanel1.GetComponent<Text>().text);

    }

    public void setJumpMode(bool a)
    {
        jumpMode = a;

    }

    // Update is called once per frame
    void Update()
    {

        

        if (jumpMode)
        {
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


                if ((OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) || OVRInput.GetUp(OVRInput.RawButton.LHandTrigger)))
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
            }
            else
            {

                verticalVelocity -= gravity * Time.deltaTime;

            }



            //make the movement
            Vector3 moveVector = Vector3.zero;
            moveVector.x = headforward.x * 70.0f * xdiff;
            moveVector.y = verticalVelocity;
            moveVector.z = headforward.z * 70.0f * zdiff;
            controller.Move(moveVector * Time.deltaTime);



            if (count <= 1 && spawn && controller.isGrounded)
            {

                SpawnBlock();
                spawn = false;
            }

            count++;
        }
        else
        {
            OVRGrabbable grabble = grabber.GetComponent<OVRGrabber>().grabbedObject;

            /*
            if (grabble != null)
            {
                grabble.transform.GetComponent<Rigidbody>().useGravity = true;
            }
            */
            

        }


        //handmenu


    }


    void SpawnBlock()
    {
        
        int dir = Random.Range(0, 3);
        float dist = Random.Range(9f, 10.5f);

  
        switch (dir)
        {
            //right
            case 0:
                nextBlock = Instantiate(blockList[index], new Vector3(transform.position.x + 3.8f + dist, 71.7f, transform.position.z + 3f), Quaternion.identity);
                nextBlock.transform.Rotate(0, 180f, 0);
                break;
            //left
            case 1:
                nextBlock = Instantiate(blockList[index], new Vector3(transform.position.x + 3.8f - dist, 71.7f, transform.position.z - 3f), Quaternion.identity);
                break;
            //forward
            case 2:
                nextBlock = Instantiate(blockList[index], new Vector3(transform.position.x - 2f, 71.7f, transform.position.z - 3f + dist), Quaternion.identity);
                nextBlock.transform.Rotate(0, 90f, 0);
                break;
            //back
            case 3:
                nextBlock = Instantiate(blockList[index], new Vector3(transform.position.x + 3.8f, 71.7f, transform.position.z - 3f - dist), Quaternion.identity);
                nextBlock.transform.Rotate(0, -90f, 0);
                break;
        }
        index++;
        if (index > 9)
        {
            index = 0;
        }

    }




    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "startcube")
        {
            score += 10;
            scorePanel1.GetComponent<Text>().text = score.ToString();
            Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
    }
    */
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "ground")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        


        if (hit.transform.name != currBlock.transform.name)
        {
            score = int.Parse(scorePanel1.GetComponent<Text>().text);
            score += 10;
            scorePanel1.GetComponent<Text>().text = score.ToString();

            if (currBlock != null)
            {

                Destroy(currBlock);
                currBlock = nextBlock;
                spawn = true;
                count = 1;
                
            }


            if (hit.transform.name == "shop(Clone)")
            {
                handMenu.SetActive(true);
                mainMenu.SetActive(false);
                shopMenu.SetActive(true);
            }

        }


    }


}
