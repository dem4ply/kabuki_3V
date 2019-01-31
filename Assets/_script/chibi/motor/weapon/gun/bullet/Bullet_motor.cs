using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace chibi.motor.weapons.gun.bullet
{
		public class Bullet_motor : Motor
		{
			protected float velocity_smooth_x, velocity_smooth_y;
			protected float velocity_smooth_z;

			public weapon.ammo.Ammo ammo;
		}
}
