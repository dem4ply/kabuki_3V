using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.controller
{
	public class Controller : Chibi_behaviour
	{
		public Vector3 desire_direction;
		public float speed;
	}
}
