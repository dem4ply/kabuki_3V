using UnityEngine;
using System.Collections.Generic;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor
{
	public class Motor_npc : Motor
	{
		protected manager.Collision manager_collisions;

		protected override void _init_cache()
		{
			base._init_cache();
			manager_collisions = new manager.Collision();
		}

		#region manejo de coliciones
		protected virtual void _proccess_collision( Collision collision )
		{
			if ( chibi.tag.consts.is_scenary( collision ) )
			{
				__validate_normal_points( collision );
				_process_collision_scenary( collision );
			}
		}

		protected virtual void _process_collision_scenary( Collision Collision )
		{
		}

		protected virtual void OnCollisionEnter( Collision collision )
		{
			_proccess_collision( collision );
		}

		protected virtual void OnCollisionExit( Collision collision )
		{
			manager_collisions.remove( collision.gameObject );
		}
		#endregion

		#region debug functions
		protected virtual void __validate_normal_points( Collision collision )
		{
			List<Vector3> normal_points = new List<Vector3>();
			foreach ( ContactPoint contact in collision.contacts )
			{
				normal_points.Add( contact.normal );
			}
			Vector3 first = normal_points[ 0 ];
			for ( int i = 1; i < normal_points.Count; ++i )
				if ( first != normal_points[ i ] )
				{
					string msg = string.Format(
						"se encontro una colision en la que los normal points " +
						"no son iguales con {0} y {1}, lista de nomral" +
						"points {2}", this, collision.gameObject, normal_points );
					Debug.LogWarning( msg );
				}
		}
		#endregion
	}
}