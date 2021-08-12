/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Script responsible for managing all the behaviours of the player ship.
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public Joystick playerJoystick;    // Joystick used as controller for player
    public GameObject playerBulletPrefab;
    public HealthScript healthBar;	// Player's health bar
    public Transform shootPoint;	// Position from where player shoots bullet 
    private FireButton fireButton;	// FireButton script
    public int maxHealth = 100;
    public int currentHealth;
    public int maxY = 5;
    public int maxX = -4;
    public int minX = -14;
    public float moveSpeed = 1f;
    public string enemyBulletTag = "enemyBullet";
    private bool isFiring;
    private bool dead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        fireButton = FindObjectOfType<FireButton>();
    }

    // Update is called once per frame
    void Update()
    {
		// vector to move in x and y directions
        Vector3 moveVector = (Vector3.right * playerJoystick.Horizontal + Vector3.up * playerJoystick.Vertical);
		
		// If player is not idle
        if (moveVector != Vector3.zero)
        {           
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
			
			// Setting the bounds of the x-y axis for player
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }

            if (transform.position.y < -maxY)
            {
                transform.position = new Vector3(transform.position.x, -maxY, transform.position.z);
            }

            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }

            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }


        // Handling fire through the fire button

        if (!isFiring && fireButton.isPressed)
        {
            //Debug.Log("Firing through fire button");
            isFiring = true;
            Instantiate(playerBulletPrefab, shootPoint.position, playerBulletPrefab.transform.rotation);
        }

        if (isFiring && !fireButton.isPressed)
        {
            isFiring = false;
        }


        // Handling fire through keyboard (For playing on PCs)
        if(!isFiring && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Firing through spacebar");
            isFiring = true;
            Instantiate(playerBulletPrefab, shootPoint.position, playerBulletPrefab.transform.rotation);
        }
		
		// When player dies show Game Over scene
        if(dead)
        {
            //Debug.Log("Player Dead!");
            SceneManager.LoadScene("GameOverScene");
        }
        
    }

    //Checking player collision with enemy bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyBulletTag))
        {            
            Destroy(collision.gameObject);            
            //Debug.Log("Enemy bullet & Player Collision working");
        }

    }
	
	// Method to calculate damage given by enemies to player
    public void DeductHealth(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took Damage: " + damage);
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            dead = true;
        }
    }

    public bool isDead()
    {
        return dead;
    }

}
