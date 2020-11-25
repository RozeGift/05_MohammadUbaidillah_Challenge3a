using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 10f;
    int flagdestroyed = 0;
    int coinsCollected = 0;
    bool allcoinscollected = false;
    bool rotate = false;
    float currentime = 0f;
    float totaltime = 10f;
    
    public Animator playerAnim;
    public Rigidbody playerRb;
    public GameObject Text;
    public GameObject RotatePlane;
    public GameObject EndFlag;
    public GameObject PlayerOnMovingPlane;
    // Start is called before the first frame update
    void Start()
    {
        Text.GetComponent<Text>().text = "Time:" + 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate == true)
        {
            currentime = Time.deltaTime;
            totaltime -= currentime;
            int TotalTimer = (int)totaltime;
            Text.GetComponent<Text>().text = "Time:" + TotalTimer;
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("isRun", true);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("isRun", true);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0 ,90, 0);
            playerAnim.SetBool("isRun", true);
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRun", false);
        }
        if (rotate == true)
        {
            RotatePlane.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if(transform.position.y < -0.5)
        {
            SceneManager.LoadScene("Lose");
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlaneB"))
        {
            PlayerOnMovingPlane.transform.parent = collision.gameObject.transform;
        }
        if(collision.gameObject.CompareTag("EndFlag"))
        {
            SceneManager.LoadScene("Win");
            Destroy(EndFlag);
        }
        

    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneB"))
        {
            PlayerOnMovingPlane.transform.parent = null;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinsCollected++;
            Destroy(other.gameObject);
            if(coinsCollected == 4)
            {
                allcoinscollected = true;
            }
        }
        if(other.gameObject.tag == "Pylon" && allcoinscollected == true)
        {
            rotate = true;
        }
        
    }



}
