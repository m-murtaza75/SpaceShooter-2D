/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Enemy bullet behaviour is implemented in this script.	 
*/

using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 9f;
    public float minX = -15;
    public int damageValue = 1;    
    public bool goLeft = true;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";
    private PlayerController playerControllerScript;
    //public GameObject enemyBullet;

    void Start()
    {
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else // Used by FollowEnemy to shoot in the right direction
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }

    }
	
	// Handling collision with player and it's bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerBulletTag))
        {            
            Destroy(collision.gameObject);            
            Destroy(gameObject);            
        }

        if (collision.gameObject.CompareTag(playerTag))
        {
            playerControllerScript.DeductHealth(damageValue);
            Destroy(gameObject);
        }
    }

    // To indicate the bullet going in the left/right direction. 
	public void SetGoLeft(bool value)
    {
        goLeft = value;
    }

}