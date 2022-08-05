using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    
    public Transform laserStartPoint;
    private Vector3 direction;
    private LineRenderer lr;
    private GameObject tempReflector;
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        direction = laserStartPoint.forward;
        lr.positionCount = 2;
        lr.SetPosition(0, laserStartPoint.position);
    }
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(laserStartPoint.position,direction,out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("reflector"))
            {
                tempReflector = hit.collider.gameObject;
                Vector3 temp = Vector3.Reflect(direction, hit.normal);
                hit.collider.gameObject.GetComponent<LaserReflector>().OpenRay(hit.point, temp);
            }
            lr.SetPosition(1, hit.point);
        }
        else
        {
            if (tempReflector)
            {
                tempReflector.GetComponent<LaserReflector>().CloseRay();
            }
            lr.SetPosition(1, direction * 200);
        }
    }
    
}
