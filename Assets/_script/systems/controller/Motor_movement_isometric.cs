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
	public class Motor_movement_isometric : ComponentSystem
	{

		struct group
		{
			public Controller controller;
			public Motor_npc_isometric motor;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_direction = new Vector3(
					entity.controller.desire_direction.x, 0,
					entity.controller.desire_direction.z );

				Vector3 desire_velocity =
					desire_direction * entity.controller.speed;

				if ( desire_velocity.magnitude > entity.motor.max_speed )
					desire_velocity = desire_velocity.normalized
						* entity.motor.max_speed;
				entity.transform.Translate( desire_velocity * delta_time );
			}

		}
	}
}
