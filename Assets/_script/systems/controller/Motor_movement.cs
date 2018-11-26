using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using System.Collections;
using chibi.controller;
using chibi.motor;

namespace chibi.systems.controller
{
	public class Motor_movement : ComponentSystem
	{

		struct group
		{
			public Controller controller;
			public Motor motor;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_velocity =
					entity.controller.desire_direction.normalized
					* entity.controller.speed;

				if ( desire_velocity.magnitude > entity.motor.max_speed )
					desire_velocity = desire_velocity.normalized
						* entity.motor.max_speed;
				entity.transform.Translate( desire_velocity * Time.deltaTime );
			}

		}


	}
}
