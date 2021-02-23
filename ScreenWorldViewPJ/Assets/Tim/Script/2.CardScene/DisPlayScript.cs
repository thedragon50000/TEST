using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisPlayScript : MonoBehaviour {
    public Image imgChar;
    public Text txtName;
    public GameObject objParticle;
	// Use this for initialization
	void Start () {
        objParticle.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator CoDisPlayEvent(Sprite sprChar, string nameChar)
    {
        objParticle.SetActive(false);
        objParticle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        imgChar.sprite = sprChar;
        txtName.text = nameChar;
        
    } 
}
