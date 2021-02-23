using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {
    public Image imgChar;
    public Sprite sprChar;

    public Text txtName;
    public string nameChar;
    
	// Use this for initialization
	void Start () {
        imgChar.sprite = sprChar;
        txtName.text = nameChar;
    }
}
