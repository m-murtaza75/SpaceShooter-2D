/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: 2nd type of enemy behaviour implemented in this script.
*/

using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    private PlayerController playerControllerScript;
    public float speed = 2f;
    public float frequency = 5f;	// how often enemy go up and down
    public float magnitude = 0.5f;	// difference between upper and lower points
    public float minX = -15;
    public int damageValue = 6;
    public int healthValue = 2;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";
    public float minShootTime = 1.3f; // Min time to shoot a bullet 
    public float maxShootTime = 2.5f; // Max time to shoot a bullet
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
        pos = transform.position;
        Invoke("StartShooting", Random.Range(minShootTime, maxShootTime));
    }

    // Update is called once per frame
    void Update()
    {
        WaveMovement();

        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }


    void WaveMovement()
    {
        pos -= transform.right * Time.deltaTime * speed;	// Moves in the left direction
		
		// Modifies gameObject's y coordinate to get the WaveMovement using Sine function
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void StartShooting()
    {
        Instantiate(enemyBulletPrefab, shootPoint.position, enemyBulletPrefab.transform.rotation);
        Invoke("StartShooting", Random.Range(minShootTime, maxShootTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		// Damage dealt by player
        if (collision.gameObject.CompareTag(playerBulletTag))
        {
            Destroy(collision.gameObject);
            healthValue--;            
            if (healthValue <= 0)
            {                
                Destroy(gameObject);
            }

        }

        // Damage done to player when enemy ship and player ship collides
		if (collision.gameObject.CompareTag(playerTag))
        {            
            playerControllerScript.DeductHealth(damageValue);
            Destroy(gameObject);
        }
    }    
}
