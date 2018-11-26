using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor
{
	[Serializable]
	public struct Motor_data : IComponentData
	{
		public float period_to_desice_direction;
		public float max_speed;
	}

	public class Motor : Chibi_behaviour
	{
		public unsigned_vector3 period_to_desice_direction;
		public float max_speed;
	}
}