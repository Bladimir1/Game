﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseController : MonoBehaviour
{
	public float sensitiveX = 5f;
	public float sensitiveY = 5f;


	public float minX = -360;
	public float maxX = 360;
	public float minY = -60;
	public float maxY = 60;

	private Quaternion originalRot;
	private float rotX = 0;
	private float rotY = 0;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb){
        	rb.freezeRotation = true;
        }

        originalRot = transform.localRotation;
    }

    private void Update()
    {
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        rotX = rotX % 360;
        rotY = rotY % 360;
        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * xQuaternion * yQuaternion;
    }
}
