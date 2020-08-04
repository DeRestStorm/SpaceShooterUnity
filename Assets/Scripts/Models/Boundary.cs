using System;
using Helpers;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class Boundary
	{
		public float xMin, xMax, zMin, zMax;

		public Boundary(Camera _camera)
		{
			
			var cameraHelper = new CameraHelper(_camera);
			var with = cameraHelper.GetWidth();
			var height = cameraHelper.GetHeight();
			

			xMax = with / 2;
			xMin = -xMax;
			zMax = height / 2;
			zMin = -zMax;
			var offset = _camera.transform.position;
			zMin += offset.z;
			zMax += offset.z;
		}
	}
}

