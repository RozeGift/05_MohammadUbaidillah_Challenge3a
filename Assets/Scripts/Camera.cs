using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject CameraMove;
    Vector3 posoffset = new Vector3(0f, 2f, -6f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CameraMove.transform.position + posoffset, 0.1f);
    }
}
