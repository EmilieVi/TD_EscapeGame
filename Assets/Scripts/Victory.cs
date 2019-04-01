using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour {

    public Text text;
    public Text timerText;
    public float time;

    private void Update()
    {
            
    }

    void OnTriggerEnter(Collider other)
    {
        text.text = "Vous avez gagné!";
        Time.timeScale = 0;
    }

}
