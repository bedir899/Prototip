using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
   
    public float time;
    public float forwardSpeed = 20f;
    private GameObject bullet;

    void Start()
    {
        bullet = this.gameObject;
        bullet.transform.Translate(Vector3.forward*forwardSpeed*Time.deltaTime);
        Debug.Log("geldi");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    public void slow(){
        Time.timeScale=time;
        Time.fixedDeltaTime=Time.timeScale*0.02f;
    }
    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag=="reflector")
        {
            Destroy(this.gameObject); 
        }
    }
}
