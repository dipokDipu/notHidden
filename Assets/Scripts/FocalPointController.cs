using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPointController : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float horizontalInput = Input.GetAxis("Mouse X");
        float horizontalInput = Input.GetAxis("Mouse Click"); 
        transform.Rotate(Vector3.down * (horizontalInput * Time.deltaTime * rotationSpeed));
        
        
    }
}
