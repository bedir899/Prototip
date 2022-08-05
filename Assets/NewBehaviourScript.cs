using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float force = 300;

    private Rigidbody rb;
    private Camera targetCamera;
    private Vector3 playerPos;
    private Vector3 originalRbPos;
    private float distance;
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!targetCamera)
            return;

        if (Input.GetMouseButtonDown(0)){
            rb = GetRigidbody();
        }
        if (Input.GetMouseButtonUp(0) && rb)
        {
            rb = null;
        }
    }

    void FixedUpdate()
    {
        if (rb)
        {
            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance)) - playerPos;
            rb.velocity = (originalRbPos + mousePositionOffset - rb.transform.position) * force * Time.deltaTime;
        }
        
    }

    Rigidbody GetRigidbody()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit)
        {
          
                if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
                {
                    distance = Vector3.Distance(ray.origin, hitInfo.point);
                    playerPos = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
                    originalRbPos = hitInfo.collider.transform.position;
                    return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
                }
            
           
            
           
            
        }

        return null;
    }
}