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
		protected Vector3 _desire_direction;
		protected float _speed;

		public motor.Motor motor;

		public Vector3 desire_direction
		{
			get {
				return _desire_direction;
			}

			set {
				_desire_direction = value;
				motor.desire_direction = value;
			}
		}

		public float speed {
			get {
				return _speed;
			}

			set {
				_speed = value;
				motor.desire_speed = value;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			load_motors();
		}

		protected virtual void load_motors()
		{
			motor = GetComponent<motor.Motor>();
			if ( !motor )
			{
				Debug.LogError(
					string.Format(
						"no se encontro un motor en el object {0}" +
						"se agrega un motor", name ) );
				motor = gameObject.AddComponent<motor.Motor>();
			}
		}
	}
}
