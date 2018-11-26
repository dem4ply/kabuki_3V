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
	public class Motor_movement_side_scroll : ComponentSystem
	{

		struct group
		{
			public Controller controller;
			public Motor_side_scroll motor;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_direction = new Vector3(
					entity.controller.desire_direction.x,
					entity.controller.desire_direction.z,
					entity.controller.desire_direction.y
				);
				Vector3 desire_velocity =
					desire_direction * entity.controller.speed;

				if ( desire_velocity.magnitude > entity.motor.max_speed )
					desire_velocity = desire_velocity.normalized
						* entity.motor.max_speed;
				entity.transform.Translate( desire_velocity * Time.deltaTime );
			}

		}


	}
}
