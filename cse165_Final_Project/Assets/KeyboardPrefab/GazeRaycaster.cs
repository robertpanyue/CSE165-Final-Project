using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GazeRaycaster : MonoBehaviour {

    public float loadingTime;
    public Image circle;
    private string lastTargetName = "";
    public GameObject StartMenu;
    public GameObject KeyText;
    public Text nameText;
    public GameObject Gazepoint;
    public GameObject Keyboard;

    private void Start()
    {
        GameObject.Find("player").GetComponent<movement>().enabled = false;
    }
    void FixedUpdate() {
        RaycastHit hit;
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        nameText.text = KeyText.GetComponent<Text>().text;

        if (Physics.Raycast(transform.position, fwd, out hit)) {

            if (hit.transform.tag == "VRGazeInteractable") {
                if (lastTargetName == hit.transform.name) {
                    return;
                }

                if (lastTargetName == "") {
                    lastTargetName = hit.transform.name;
                }

                if (hit.transform.name != lastTargetName) {
                    circle.fillAmount = 0f;
                    lastTargetName = hit.transform.name;
                    return;
                }

                StartCoroutine(FillCircle(hit.transform));
                return;
            } else if (hit.transform.tag == "Start") {
                lastTargetName = hit.transform.name;
                StartCoroutine(FillCircle(hit.transform));
            } else if (hit.transform.tag == "Quit") {
                lastTargetName = hit.transform.name;
                StartCoroutine(FillCircle(hit.transform));
            }

            else {
                circle.fillAmount = 0f;
                lastTargetName = "";
            }
        } else {
            circle.fillAmount = 0f;
            lastTargetName = "";
        }
    }

    private IEnumerator FillCircle(Transform target) {
        float timer = 0f;
        circle.fillAmount = 0f;
        while (timer < loadingTime) {
            if (target.name != lastTargetName) {
                yield break;
            }
            timer += Time.deltaTime;
            circle.fillAmount = timer / loadingTime;
            yield return null;
        }
        circle.fillAmount = 1f;
        if (target.GetComponent<Button>()) {
            target.GetComponent<Button>().onClick.Invoke();
        }
        if (target.tag == "Start") {
            SceneManager.LoadScene("Game");
        }

        if (target.tag == "Quit")
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        circle.fillAmount = 0f;
        lastTargetName = "";
    }



}
