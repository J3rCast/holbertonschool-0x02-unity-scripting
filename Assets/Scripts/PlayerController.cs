using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public Rigidbody rb;
	private int score = 0;
	public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
