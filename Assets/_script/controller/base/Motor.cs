using UnityEngine;
using System.Collections.Generic;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor
{
	public class Motor : Chibi_behaviour
	{
		public unsigned_vector3 period_to_desice_direction;
		public Vector3 desire_direction;
		public float desire_speed;
		public float max_speed = 4f;

		public Vector3 current_speed = Vector3.zero;
	}
}