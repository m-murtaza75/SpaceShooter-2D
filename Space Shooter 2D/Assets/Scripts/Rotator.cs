/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: This script is used for Asteroid GameObject 
*/

using UnityEngine;

public class Rotator : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float moveSpeed = 5f;
    public float rotateSpeed = 80f;
    public float minX = -15;
    public int damageValue = 6;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";


    void Start()
    {
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary Position
        Vector3 tPos = transform.position;
		
		// Moving towards left
        tPos.x -= moveSpeed * Time.deltaTime;
        transform.position = tPos;

        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }

        // Rotate around Z axis
        transform.Rotate(new Vector3(0f , 0f , rotateSpeed * Time.deltaTime), Space.World);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerBulletTag))
        {            
            Destroy(gameObject);
            Destroy(collision.gameObject);            
        }

        if(collision.gameObject.CompareTag(playerTag))
        {
            playerControllerScript.DeductHealth(damageValue);
            Destroy(gameObject);
        }
    }
}
