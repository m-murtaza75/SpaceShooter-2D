/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Type of enemy bullet associated with the game's bosses  
*/


using UnityEngine;

public class BossBullet : MonoBehaviour
{
	public float speed = 7f;
    public int damageValue = 9;
    public string playerTag = "Player";
    public string playerBulletTag = "playerBullet";
    private PlayerController playerControllerScript;
    private Rigidbody2D rb;	
	private Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
        playerControllerScript = GameObject.Find(playerTag).GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();		
		moveDirection = (playerControllerScript.transform.position - transform.position).normalized * speed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 4f); // Destroy after the specified seconds in 2nd parameter
	}
	
	// Handling bullet collision with player and it's bullet
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals(playerTag))
		{
            //Debug.Log("Hit!");
            playerControllerScript.DeductHealth(damageValue);
            Destroy(gameObject);
		}

        if (col.gameObject.CompareTag(playerBulletTag))
        {
            Debug.Log("Boss follow bullets collision detected");
            Destroy(gameObject);
            Destroy(col.gameObject);                        
            
        }
    }
}
