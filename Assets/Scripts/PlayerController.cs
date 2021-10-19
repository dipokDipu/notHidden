using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody theRb;
    public float speed;
    public bool power;

    private GameObject focusPoint;

    public GameObject powerUpPrefab;
    GameObject clonePowerRIng;
    // Start is called before the first frame update
    void Start()
    {
        theRb = GetComponent<Rigidbody>();
        focusPoint = GameObject.FindGameObjectWithTag("FocusPoint");
        
    }

    // Update is called once per frame
    void Update()
    {

        theRb.WakeUp();

        if (clonePowerRIng != null)
        {
            clonePowerRIng.transform.rotation = powerUpPrefab.transform.rotation;
            power = true;
        }
        else
        {
            power = false;
        }
        //float forwardInput = Input.GetAxis("Mouse Click");
    }

    private void FixedUpdate()
    {
        float forward = Input.GetAxisRaw("Vertical");
        float side = Input.GetAxisRaw("Horizontal");
        //int scrollValue = Mathf.RoundToInt((float)((Input.mouseScrollDelta.y) / (Mathf.Abs(Input.mouseScrollDelta.y) + 1f)));
        //print(scrollValue);
        //theRb.AddForce(Vector3.up * forwardInput * speed);
        //theRb.AddForce(focusPoint.transform.forward * scrollValue * speed);
        theRb.AddForce(focusPoint.transform.forward * forward * speed);
        theRb.AddForce(focusPoint.transform.right * side * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            if(clonePowerRIng == null)
            {
                //other.gameObject.SetActive(false);
                Destroy(other.gameObject);

                clonePowerRIng = Instantiate(powerUpPrefab, transform.position, transform.rotation, transform);

                Destroy(clonePowerRIng, 5.0f);
            }           
        }
    }
}
