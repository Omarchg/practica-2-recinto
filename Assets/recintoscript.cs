using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recintoscript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed = 10f;
    private bool Recinto = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Recinto)
        {
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(horizontal, 0, vertical);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Recinto = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Recinto = true;
            
        }
    }
}
