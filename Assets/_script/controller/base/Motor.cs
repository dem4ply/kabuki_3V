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
		public float max_speed = 4f;
	}
}