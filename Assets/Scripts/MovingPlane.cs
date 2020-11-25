using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    float speedPlat = 1f;
    int boxcount = 1;

    public GameObject movingplane; 

    Vector3 pointa = new Vector3(1f, 1f, 41.2f);
    Vector3 pointb = new Vector3(1f, 1f, 28.14f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(boxcount <= 0)
        {
            movingplane.transform.position = Vector3.Lerp(pointa, pointb, Mathf.PingPong(Time.time, 1) * speedPlat);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        boxcount--;
    }
}



    
    


