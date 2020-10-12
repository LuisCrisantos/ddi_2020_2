﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
	public float distance;
	public float speed;

	private bool z;

	void Update ()
	{
		float dist = Vector3.Distance (player.transform.position, transform.position);

		Vector3 behind = player.transform.position - new Vector3 (player.transform.forward.x * distance, player.transform.forward.y - 2.0f, player.transform.forward.z * distance);

		if(!z && Input.GetKey(KeyCode.Z))
		{
			z = true;
		}
		else if(z)
		{
			transform.LookAt(player.transform);

			transform.position = Vector3.MoveTowards(transform.position, behind, 30 * Time.deltaTime);

			if(transform.position == behind)
			{
				z = false;
			}
		}
		else
		{
			if (dist < distance)
			{
				transform.LookAt(player.transform);
			}
			else if (dist > distance * 2)
			{
				transform.LookAt(player.transform);

				transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z - distance), speed * 3 * Time.deltaTime);
			}
			else if (dist < distance * 2 && dist > distance)
			{
				transform.LookAt(player.transform);

				transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z - distance), speed * Time.deltaTime);
			}
		}
	}
   /* public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    void Start()
    {
        initalOffset = transform.position - targetObject.position;
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = cameraPosition;
    }*/

    
}