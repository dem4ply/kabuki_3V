using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.motor
{
	public class Vertical_jump : ComponentSystem
	{
		struct group
		{
			public chibi.motor.Vertical_jump motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				if ( entity.motor.want_to_jump && entity.motor.is_grounded )
					entity.rigidbody.velocity += entity.motor.desire_velocity;
			}
		}
	}
}
