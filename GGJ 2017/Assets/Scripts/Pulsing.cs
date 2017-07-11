using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour {

    private Vector3 originalScale;

    public HealthBar HB;

    public int speedpulse;
    public int size = 10;

    public float alphaLevel = 0f;

    bool increase;

    public enum colour { Blue, Green, Red, Yellow };
    public colour spriteColour;

	private Transform parent;
	public bool moveWith;

    // Use this for initialization
    void Start () {
        HB = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
		parent = transform.parent;
		transform.SetParent (null);
        originalScale = transform.localScale;
        increase = true;
    }
	
	// Update is called once per frame
	void Update () {

		if (moveWith == true) {

			if (parent != null)
			{
				transform.position = parent.position;	
			}

			if (increase == true)
			{
				transform.localScale = new Vector3 (originalScale.x += 1 * Time.deltaTime * speedpulse, originalScale.y += 1 * Time.deltaTime * speedpulse, originalScale.z += 1 * Time.deltaTime * speedpulse);
				alphaLevel += 0.0025f;
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaLevel);
			}
			else
			{
				transform.localScale = new Vector3 (originalScale.x = 1, originalScale.y = 1, originalScale.z = 1);
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);

				if (parent == null)
				{
					Destroy (gameObject);
				}
			}
		}
		else
		{
			if (increase == true)
			{
				transform.localScale = new Vector3 (originalScale.x += 1 * Time.deltaTime * speedpulse, originalScale.y += 1 * Time.deltaTime * speedpulse, originalScale.z += 1 * Time.deltaTime * speedpulse);
				alphaLevel += 0.0025f;
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaLevel);
			}
			else
			{
				transform.localScale = new Vector3 (originalScale.x = 1, originalScale.y = 1, originalScale.z = 1);
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);

				if (parent != null) {
					transform.position = parent.position;
				}
				else
				{
					Destroy (gameObject);
				}
			}
		}
        if (originalScale.x >= size && originalScale.y >= size && originalScale.z >= size)
        {
            increase = false;
        }
        if (originalScale.x <= 1 && originalScale.y <= 1 && originalScale.z <= 1)
        {
            increase = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if ((int)spriteColour != (int)col.GetComponent<ChangePlayerColours>().spriteColour)
            {
                int health = HB.health--;
                print("poi");
            }
            else
            {
				/*
                int health = HB.health++;
                print(col.GetComponent<ChangePlayerColours>().spriteColour);
                print(spriteColour);
                */
            }
        }
    }
}
