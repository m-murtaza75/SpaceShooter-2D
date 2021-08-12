/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Script responsible for behaviour of Boss enemies along loading next level  
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    
    public HealthScript healthBar;
    private PlayerController playerControllerScript;
    private LaunchProjectiles launchProjectilesScript;
    public float speed = 9f;
	public float fireCoolDown = 1.4f;
    public float megaFireCoolDown = 3.2f;    
    public float damageTimer = 0.9f;
	public float minX = 2.5f;
	public float maxY = 5f;
    public int damageValue = 15;
    public int healthValue = 45;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";
    public bool moveUp = false;	
	public GameObject bullet;
	public Transform shootPoint;
	public Transform shootPoint2;
    public bool useMove = true;
    public bool useMegaAttack = false;
	public bool moveLeft = true;
	private float nextFire;
    private float megaFire;
    private float nextDamage;
    private string nextScene;

	// Initializing necessary components used by Boss enemies
	void Start()
	{
        healthBar.SetMaxHealth(healthValue);
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
        if(useMegaAttack)
        {
            launchProjectilesScript = GameObject.Find("FireBall").GetComponent<LaunchProjectiles>();
        }
        
        nextFire = Time.time;
        nextDamage = Time.time;
        megaFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
        if(useMove)
        {
            Move();
        }
        
		Fire();

        if(useMegaAttack)
        {
            MegaAttack();
        }
	}
	
	// Used by Level 1 Boss
	void Move()
	{
		if(moveLeft)
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);

			if (transform.position.x < minX)
			{
				moveLeft = false;
				moveUp = true;
			}
		}
		else if(moveUp)
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			Debug.Log("Going Up!!");

			if (transform.position.y > maxY)
			{
				//Debug.Log("PosY: " + transform.position.y);
				//Debug.Log("Going Up Stopped!!");
				moveUp = false;
			}
		}
		else // move down
		{
			transform.Translate(Vector3.down * Time.deltaTime * speed);

			if (transform.position.y < -maxY)
			{
				moveUp = true;
			}
		}
	}
	
	// Method used by each Boss to shoot two bullets
	void Fire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, shootPoint.position, Quaternion.identity);
			Instantiate(bullet, shootPoint2.position, Quaternion.identity);
			nextFire = Time.time + fireCoolDown;
		}
	}
	
	// Used by level 3 Boss
    void MegaAttack()
    {
        if(Time.time > megaFire)
        {
            launchProjectilesScript.SetSpawnProjectiles(true);
            megaFire = Time.time + megaFireCoolDown;
        }
    }

	// Handling Boss death, loading next level and detecting required collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerBulletTag))
        {
            Destroy(collision.gameObject);
            healthValue--;
            healthBar.SetHealth(healthValue);            
            if (healthValue <= 0)
            {

                if (gameObject.name.Contains("Boss1"))
                {
                    nextScene = "Level2";
                }
                else if(gameObject.name.Contains("Boss2"))
                {
                    nextScene = "Level3";
                }
                else
                {
                    //Load Win Screen
                    nextScene = "WinScene";
                }                    

                Destroy(gameObject);
                
                SceneManager.LoadScene(nextScene);
            }
        }

        if (collision.gameObject.CompareTag(playerTag))
        {
			// nextDamage is the time for the player to move away from Boss at the point of collision 
            if(Time.time > nextDamage)
            {
                playerControllerScript.DeductHealth(damageValue);
                nextDamage = Time.time + damageTimer;                
            }            
        }
    }
}