/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Type of enemy which follows player and have ability to shoot left and right 	 
*/

using UnityEngine;

public class Follow : MonoBehaviour
{

    public EnemyBullet enemyBullet;
    public Transform shootPoint;
    public Transform shootPoint2;
    private PlayerController playerControllerScript; // To access player controller script    
    public float speed;
    public int damageValue = 12;
    public int healthValue = 4;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";
    public float minShootTime = 1.2f;
    public float maxShootTime = 1.8f;    

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
        Invoke("ShootTarget", Random.Range(minShootTime, maxShootTime));        	
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget(); 
    }

    void ShootTarget()
    {
		// When player is in front of the enemy 
        if(playerControllerScript.transform.position.x < transform.position.x)
        {
            enemyBullet.SetGoLeft(true);
            Instantiate(enemyBullet, shootPoint.position, enemyBullet.transform.rotation);
            
        }
        else // When player is behind the enemy
        {
            
            Instantiate(enemyBullet, shootPoint2.position, enemyBullet.transform.rotation);
            enemyBullet.SetGoLeft(false);
        }
        Invoke("ShootTarget", Random.Range(minShootTime, maxShootTime));
    }
	
	// Continuously follows the player
    void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerControllerScript.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerBulletTag))
        {
            Destroy(collision.gameObject);
            healthValue--;            
            if (healthValue <= 0)
            {                
                Destroy(gameObject);
            }

        }

        if (collision.gameObject.CompareTag(playerTag))
        {            
            playerControllerScript.DeductHealth(damageValue);
            Destroy(gameObject);
        }
    }
}
