using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
	public float Tumble;

	private Rigidbody _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();

		_rb.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
