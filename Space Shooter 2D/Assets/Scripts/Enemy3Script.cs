/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: 1st type of enemy behaviour implemented in this script.
	  This Enemy type shoots three bullets. Two of those bullets	 
	  are instantiated using this script.
*/


using UnityEngine;

public class Enemy3Script : MonoBehaviour
{    
    public float speed = 9f;
    public float fireCoolDown = 1.8f;    
    public GameObject bullet;
    public Transform shootPoint;
    public Transform shootPoint2;    
    private float nextFire;
    


    void Start()
    {
        nextFire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {    
        Fire();
    }
    
    void Fire()
    {
		// Used to shoot after the cool down gap 
        if (Time.time > nextFire)
        {
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
            Instantiate(bullet, shootPoint2.position, Quaternion.identity);
            nextFire = Time.time + fireCoolDown;
        }
    }   
}