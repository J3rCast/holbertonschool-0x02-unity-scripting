using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public Rigidbody rb;
	private int score = 0;
	public int health = 5;

    void Update()
    {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }

    void FixedUpdate()
    {
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Trap")
		{
			health -= 1;
			Debug.Log("Health: " + health);
		}

		if (other.gameObject.tag == "Pickup")
		{
			score += 1;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Goal")
		{
			Debug.Log("You win!");
		}
	}
}
