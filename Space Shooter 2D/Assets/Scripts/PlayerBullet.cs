/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Behaviour of the bullet used by the player to shoot. 
*/

using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;
    public float rightBound = 13.45f;    
   

    // Update is called once per frame
    void Update()
    {
		// Moving in the right (x) direction 
        transform.Translate(Vector3.right * Time.deltaTime * speed);
		
		// Destroys player bullet on exceeding this limit
        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }

    }

}
