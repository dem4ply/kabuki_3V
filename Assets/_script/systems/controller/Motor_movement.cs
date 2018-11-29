using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.motor
{
	public class Motor_movement : ComponentSystem
	{

		struct group
		{
			public Motor motor;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_velocity =
					entity.motor.desire_direction.normalized
					* entity.motor.desire_speed;

				if ( desire_velocity.magnitude > entity.motor.max_speed )
					desire_velocity = desire_velocity.normalized
						* entity.motor.max_speed;
				entity.transform.Translate( desire_velocity * delta_time );
				entity.motor.current_speed = desire_velocity;
			}
		}
	}
}
