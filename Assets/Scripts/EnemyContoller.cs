using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    private GameObject player;
    private float speed = 5.0f;
    private Rigidbody enemyRb;
    private Vector3 followDirection;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    
        
        
    }
    private void FixedUpdate()
    {
        followDirection = (player.transform.position - transform.position).normalized;
        //Debug.Log((player.transform.position - transform.position).normalized.magnitude);
        enemyRb.AddForce( followDirection * speed);
        //StartCoroutine(printvalue());
    }

    private void OnCollisionEnter(Collision other)
    {
       

        if(other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            //Debug.Log("Ring");
            enemyRb.AddForce(-followDirection * speed * 10, ForceMode.VelocityChange);

            Destroy(gameObject, 5.0f);
        }

        else if(other.gameObject.CompareTag("GameOverPlane"))
        {
            Destroy(this.gameObject);
        }
    }

    /*IEnumerator printvalue()
    {
        Debug.Log("hello");
        
        
        yield return new WaitForSeconds(6f);
        Debug.Log(i);
    }*/
}
