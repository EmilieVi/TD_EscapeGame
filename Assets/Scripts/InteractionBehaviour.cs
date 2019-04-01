using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionBehaviour : MonoBehaviour {

    [SerializeField] float distance;
    [SerializeField] float boxSize;
    [SerializeField] LayerMask layers;
    [SerializeField] LayerMask socleLayer;
    [SerializeField] Camera cam;
    [SerializeField] Text text;
    [SerializeField] Animator buttonAnimator;
    [SerializeField] Transform anchor;
    GameObject grabbed = null;
    public bool hasKey = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2")&&grabbed!=null)
        {
            grabbed.transform.parent = null;
            grabbed.transform.GetComponent<Rigidbody>().isKinematic = false;
            grabbed = null;
        }
        if (Input.GetButtonDown("Fire1"))//Clic gauche
        {
            RaycastHit hitInfo;
            if (grabbed != null)
            {
                if (Physics.BoxCast(cam.transform.position, Vector3.one * boxSize, cam.transform.forward, out hitInfo, cam.transform.rotation, distance, socleLayer))
                {
                    Transform hTrans = hitInfo.transform;
                    hTrans.GetComponent<Socle>().objet = grabbed.transform.GetComponent<Objet>();
                    grabbed.transform.GetComponent<Objet>().socle = hTrans.GetComponent<Socle>();
                    grabbed.transform.parent = null;
                    grabbed.transform.position = hTrans.position + (Vector3.up * 0.1f);
                    grabbed.transform.rotation = Quaternion.identity;
                    grabbed.transform.GetComponent<Rigidbody>().isKinematic = true;
                    grabbed = null;
                }
            }
            else
            {
                if (Physics.BoxCast(cam.transform.position, Vector3.one * boxSize, cam.transform.forward, out hitInfo, cam.transform.rotation, distance, layers))
                {
                    Transform hTrans = hitInfo.transform;
                    if (hTrans.CompareTag("Tiroir"))
                    {
                        Animator anim = hTrans.GetComponent<Animator>();
                        //anim.SetTrigger("OpenDrawer");
                        anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
                    }
                    else if (hTrans.CompareTag("Clef"))
                    {
                        Destroy(hTrans.gameObject);
                        text.text = "Clé récupérée";
                        hasKey = true;
                        StartCoroutine(CleanTextCoroutine(3));
                    }
                    else if (hTrans.CompareTag("Chest"))
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
                    }
                    else if (hTrans.CompareTag("Button"))
                    {
                        buttonAnimator.SetBool("IsOpen", true);
                    }
                    else if (hTrans.CompareTag("Grabbable"))
                    {
                        grabbed = hTrans.gameObject;
                        hTrans.parent = anchor;
                        hTrans.localPosition = Vector3.zero;
                        hTrans.localRotation = Quaternion.identity;
                        hTrans.GetComponent<Rigidbody>().isKinematic = true;
                        if (hTrans.GetComponent<Objet>().socle != null)
                        {
                            hTrans.GetComponent<Objet>().socle.objet = null;
                            hTrans.GetComponent<Objet>().socle = null;
                        }
                    }
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
