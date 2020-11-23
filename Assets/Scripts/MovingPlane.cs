using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    float speedPlat = 10f;
    float zlimit = 28.4f;
    bool hitwall = false;
    bool hitplayer = false;
    bool moveback = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hitplayer == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speedPlat);
            moveback = true;
            
        }

        if(transform.position.z <= zlimit && hitplayer == true)
        {
            moveback = false;
            
        }
        if(moveback == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speedPlat);
        }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            hitplayer = true;
        }

  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag( "PlaneB" ))
        {
            
        }
    }
}

