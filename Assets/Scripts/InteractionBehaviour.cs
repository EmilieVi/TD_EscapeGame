using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionBehaviour : MonoBehaviour {

    [SerializeField] float distance;
    [SerializeField] float boxSize;
    [SerializeField] LayerMask layers;
    [SerializeField] Camera cam;
    [SerializeField] Text text;
    [SerializeField] Animator buttonAnimator;
    public bool hasKey = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))//Clic gauche
        {
            RaycastHit hitInfo;
            if (Physics.BoxCast(cam.transform.position,Vector3.one*boxSize,cam.transform.forward,out hitInfo,cam.transform.rotation,distance,layers))
            {
                Transform hTrans = hitInfo.transform;
                if (hTrans.CompareTag("Tiroir"))
                {
                    Animator anim = hTrans.GetComponent<Animator>();
                    //anim.SetTrigger("OpenDrawer");
                    anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
                }else if (hTrans.CompareTag("Clef"))
                {
                    Destroy(hTrans.gameObject);
                    text.text = "Clé récupérée";
                    hasKey = true;
                    StartCoroutine(CleanTextCoroutine(3));
                }else if (hTrans.CompareTag("Chest"))
                {
                    if (hasKey)
                    {
                        hTrans.GetComponentInParent<Animator>().SetBool("IsOpen", true);
                    }
                    else
                    {
                        text.text = "Le coffre est fermé à clé";
                        StartCoroutine(CleanTextCoroutine(3));
                    }
                }else if (hTrans.CompareTag("Button"))
                {
                    buttonAnimator.SetBool("IsOpen",true);
                }
            }
        }
	}

    IEnumerator CleanTextCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        text.text = "";
    }
}
