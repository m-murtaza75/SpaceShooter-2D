/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: 1st type of enemy behaviour implemented.
*/

using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;	// Position at which enemy bullet spawns
    private PlayerController playerControllerScript;
    public bool useMoveAbility = true; // For the purpose of using this script for enemies with about same behaviour
    public float speed = 2f;
    public float minX = -15;
    public int damageValue = 3;
    public int healthValue = 2;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";
    public float minShootTime = 1.2f;
    public float maxShootTime = 2.5f;    


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
        Invoke("StartShooting", Random.Range(minShootTime, maxShootTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(useMoveAbility)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < minX)
            {
                Destroy(gameObject);
            }
        }               
    }

    // To shoot after random range of time
	void StartShooting()
    {
        Instantiate(enemyBulletPrefab, shootPoint.position, enemyBulletPrefab.transform.rotation);
        // So this method keeps running
		Invoke("StartShooting", Random.Range(minShootTime, maxShootTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		// Damage dealt by player
        if(collision.gameObject.CompareTag(playerBulletTag))
        {
            Destroy(collision.gameObject);
            healthValue--;            
            if(healthValue <= 0)
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
