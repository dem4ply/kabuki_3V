using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.motor
{
	public class Simple_gravity : ComponentSystem
	{
		struct group
		{
			public chibi.motor.Simple_gravity motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				entity.rigidbody.velocity += entity.motor.gravity * delta_time;
			}
		}
	}
}
