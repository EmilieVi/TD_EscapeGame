using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socle : MonoBehaviour {

    public int order;
    public Objet _objet = null;
    public Objet objet
    {
        get
        {
            return _objet;
        }

        set
        {
            _objet = value;
            OnObjetChanged();
        }
    }
    TableObjet tableObj;

    void Start()
    {
        tableObj = GetComponentInParent<TableObjet>();
    }

    void OnObjetChanged()
    {
        tableObj.CheckObjectOrder();
    }

}
