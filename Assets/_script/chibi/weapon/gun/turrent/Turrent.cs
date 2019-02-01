using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chibi.systems.weapon.gun.turrent
{
	public class Turrent : Chibi_behaviour
	{
		public Vector3 rotation_vector = Vector3.up;
		public float max_rotation_angle = 180f;

		[HideInInspector] public float current_rotation_angle = 0f;
	}
}