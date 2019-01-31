using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.weapon.gun
{
	public class Gun : ComponentSystem
	{
		struct group
		{
			public chibi.weapon.gun.Gun gun;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				Debug.Log( entity.gun.gameObject.name );
			}
		}
	}
}
