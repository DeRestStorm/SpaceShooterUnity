using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Helpers;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void Start()
    {
        var cameraHelper = new CameraHelper(Camera.main);
        var localScale = transform.localScale;
        localScale.x = cameraHelper.GetWidth();
        localScale.z = cameraHelper.GetHeight();
        transform.localScale = localScale;

        // gameObject.transform.localScale = Vector3.one * cameraHeight;
    }

    void OnTriggerExit(Collider other)
    {
        var poolingObject = other.GetComponent<IPoolingObject>();

        if (poolingObject != null)
        {
            poolingObject.ReturnToPool();
            return;
        }

        Destroy(other.gameObject);
    }
}