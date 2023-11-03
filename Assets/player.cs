using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject PantallaDerrota;
    public float speed = 10f;
    public Rigidbody rb;
    private bool canJump = true;
    public Transform recinto;
    private bool Recinto = false;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        
        transform.Translate(horizontal, 0, vertical);


        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            canJump = false;
        }
        if(Recinto)
        {
            
            transform.position = recinto.position;
            rb.isKinematic=true;
        }
        else
        {
            rb.isKinematic=false;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Recinto = false;
            transform.position += new Vector3(5f, 0f, 0f);
        }
    }

   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            canJump = true; // Player can jump again when grounded
        }
        if (collision.gameObject.CompareTag("SueloDerrota"))
        {
            PantallaDerrota.SetActive(true);
            Time.timeScale = 0;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("recinto"))
        {
           Recinto = true;
            
        }
    }
}
