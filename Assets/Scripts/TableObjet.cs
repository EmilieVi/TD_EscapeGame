using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObjet : MonoBehaviour {

    public Socle[] socles;
    public Animator anim;
    public Animator checkAnim;

    public void CheckObjectOrder()
    {
        if (!checkAnim.GetBool("IsOpen"))
            return;
        for(int i = 0; i < socles.Length; i++)
        {
            if (socles[i].objet != null)
            {
                if (socles[i].objet.order != i + 1)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        anim.SetTrigger("OpenDoor");
    }
}
