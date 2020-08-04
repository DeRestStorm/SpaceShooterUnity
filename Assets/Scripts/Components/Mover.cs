using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float Speed = 5;

	private Rigidbody _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();

		_rb.velocity = transform.forward * Speed;
	}
}
