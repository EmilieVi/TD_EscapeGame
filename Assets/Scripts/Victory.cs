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
        timerText.text = "Temps :"+Mathf.FloorToInt(time - Time.time)/60+" : "+ Mathf.FloorToInt(time - Time.time) % 60;
        if (Time.time > time)
        {
            text.text = "Vous avez perdu!";
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        text.text = "Vous avez gagné!";
        Time.timeScale = 0;
    }

}
