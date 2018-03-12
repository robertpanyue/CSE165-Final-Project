using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class KeyboardManager : MonoBehaviour {

    public bool isUppercase = false;
    public int maxInputLength;
    public Text inputText;
    public Transform characters;


 

    private string Input {
        get { return inputText.text;  }
        set { inputText.text = value;  }
    }

    private Dictionary<GameObject, Text> keysDictionary = new Dictionary<GameObject, Text>();

    private bool capslockFlag;

    private void Awake() {
            
        for (int i = 0; i < characters.childCount; i++) {
            GameObject key = characters.GetChild(i).gameObject;
            Text text = key.GetComponentInChildren<Text>();
            keysDictionary.Add(key, text);

            key.GetComponent<Button>().onClick.AddListener(() => {
                GenerateInput(text.text);
            });

        }
        capslockFlag = isUppercase;
        CapsLock();
    }

    public void Backspace() {
        if (Input.Length > 0) {
            Input = Input.Remove(Input.Length - 1);
        } else {
            return;
        }
    }

    public void Clear() {
        Input = "";
    }

    public void CapsLock() {
        if (capslockFlag) {
            foreach (var pair in keysDictionary) {
                pair.Value.text = ToUpperCase(pair.Value.text);
            }
        } else {
            foreach (var pair in keysDictionary) {
                pair.Value.text = ToLowerCase(pair.Value.text);
            }
        }
        capslockFlag = !capslockFlag;
    }
        
    public void GenerateInput(string s) {
        if (Input.Length > maxInputLength) { return; }
        Input += s;
    }

    private string ToLowerCase(string s) {
        return s.ToLower();
    }

    private string ToUpperCase(string s) {
        return s.ToUpper();
    }

}
