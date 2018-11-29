using UnityEngine;
using System.Collections.Generic;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor
{
	[ RequireComponent( typeof( Rigidbody ) ) ]
	public class Motor : Chibi_behaviour
	{
		public unsigned_vector3 period_to_desice_direction;
		private Vector3 _desire_direction;
		public float desire_speed;
		public float max_speed = 4f;
		public Vector3 current_speed = Vector3.zero;

		public manager.Collision manager_collisions;

		protected Rigidbody ridgetbody;

		public Vector3 velocity
		{
			get {
				return ridgetbody.velocity;
			}
		}

		public virtual Vector3 desire_velocity
		{
			get {
				return desire_direction.normalized
					* Mathf.Clamp( desire_speed, 0, max_speed );
			}
		}

		public virtual Vector3 desire_direction
		{
			get {
				return _desire_direction;
			}

			set {
				_desire_direction = value;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			ridgetbody = GetComponent<Rigidbody>();
			if ( !ridgetbody )
				Debug.Log( string.Format(
					"no se encontro un ridgetbody en el objeco {0}", name ) );
		}
	}
}