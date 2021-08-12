/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Script to spawn wave of projectiles	 
*/

using UnityEngine;

public class LaunchProjectiles : MonoBehaviour
{
        
    public GameObject projectile;
    public Transform shootPoint;
    public int damageValue = 20;
    public string playerTag = "Player";
    public float radius, moveSpeed, minX, maxY;
    private PlayerController playerControllerScript;	
    private bool spawnProjectiles = false; 		// Indicator when to spawn projectiles


    void Start()
    {
		//Assigning the PlayerControllerScript so this script can communicate with it.
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
				
        if(spawnProjectiles)
        {
            SpawnProjectiles();
        }

        // For memory management purpose
        checkBounds();
    }

    public void SpawnProjectiles()
    {
        float angleStep = 15f;  
        float angle = 320f;

        // For projectiles to go on the left side of the world angle rotation will be anti-clockwise 
        while(angle > 190)
        {
			// Finding x-y coordinates of direction point
            float projectileDirXposition = shootPoint.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = shootPoint.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
			
			// converting the coordinates into vector 
            Vector3 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
			// Getting the direction to move towards
            Vector3 projectileMoveDirection = (projectileVector - shootPoint.position).normalized * moveSpeed;
			
			// Spawning the projectile
            var proj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
			
			// angleStep used for the angle gap between each projectile 
            angle -= angleStep;
        }

        spawnProjectiles = false;
      
    }
	
	
	// Function used by Boss Enemy to toggle spawning of projectiles 
    public void SetSpawnProjectiles(bool value)
    {
        spawnProjectiles = value;
    }
	
	// Destroys the projectile out of the specified range
    void checkBounds()
    {
        if(projectile.transform.position.x < minX || 
           projectile.transform.position.y > maxY ||
           projectile.transform.position.y < -maxY)
        {
            //Debug.Log("FireBall Destroyed");
            Destroy(projectile);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        

        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            playerControllerScript.DeductHealth(damageValue);
            Destroy(gameObject);
        }
    }

}