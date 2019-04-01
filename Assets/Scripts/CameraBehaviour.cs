using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField]Camera cam;
    [SerializeField]float camSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update () {
        Vector3 rotation = Vector3.zero;
        float xMouseAxis = Input.GetAxisRaw("Mouse X");
        float yMouseAxis = -Input.GetAxisRaw("Mouse Y");
        if (xMouseAxis != 0)
        {
            rotation.y = xMouseAxis * camSpeed * Time.deltaTime;
        }

        if (yMouseAxis != 0)
        {
            rotation.x = yMouseAxis * camSpeed * Time.deltaTime;
        }
        cam.transform.Rotate(rotation);
        CorrectZAxisCamera();
    }

    void CorrectZAxisCamera()
    {
        Vector3 rotation = cam.transform.eulerAngles;
        rotation.z = 0;
        cam.transform.eulerAngles = rotation;
    }
}
