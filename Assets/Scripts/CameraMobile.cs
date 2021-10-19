using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMobile : MonoBehaviour
{
    private Camera cam;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {

            
            Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(mousePointer , out hit))
            {
                if(hit.collider!=null)
                {
                    hit.collider.GetComponent<MeshRenderer>().material.color = new Color (Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f),1f);
                }
            }

        }

        if (Input.GetMouseButton(1))
        {
            dir = cam.ScreenToWorldPoint(Input.mousePosition) - cam.ScreenToWorldPoint(transform.position);
            transform.position = -dir;

            

        }

        //transform.position = Vector3.MoveTowards(transform.position, -dir, 5 * Time.deltaTime);
       



#endif
    }
}
