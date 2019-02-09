using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using chibi.controller.weapon.gun.bullet;

namespace tests.controller.weapon.gun.turrent
{
	public class Turrent_side_scroll : helper.tests.Scene_test
	{
		Assert_colision up, left, right, down;
		chibi.motor.weapons.gun.turrent.Turrent turrent;
		chibi.controller.weapon.gun.turrent.Controller_turrent controller;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/weapon/gun/turrent side scroll";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			( up, down, left, right ) = 
				helper.game_object.Find._<Assert_colision>(
					scene, "up", "down", "left", "right" );

			turrent = helper.game_object.Find._<
				chibi.motor.weapons.gun.turrent.Turrent>( scene, "turrent" );
			controller = helper.game_object.Find._<
				chibi.controller.weapon.gun.turrent.Controller_turrent>(
				scene, "turrent" );
		}

		[UnityTest]
		public IEnumerator move_down_should_can_hit_down_assert()
		{
			controller.desire_direction = Vector3.down;
			yield return new WaitForSeconds( 1 );
			controller.shot();
			yield return new WaitForSeconds( 1 );
			down.assert_collision_enter();

			helper.test.assert.many.assert_colision.assert_not_collision_enter(
				left, up, right );
		}

		[UnityTest]
		public IEnumerator move_right_should_can_hit_right_assert()
		{
			controller.desire_direction = Vector3.right;
			yield return new WaitForSeconds( 1 );
			controller.shot();
			yield return new WaitForSeconds( 1 );
			right.assert_collision_enter();

			helper.test.assert.many.assert_colision.assert_not_collision_enter(
				left, up, down );
		}

		[UnityTest]
		public IEnumerator move_left_should_can_hit_up_or_down()
		{
			controller.desire_direction = Vector3.left;
			yield return new WaitForSeconds( 1 );
			controller.shot();
			yield return new WaitForSeconds( 1 );
			helper.test.assert.many.assert_colision.assert_not_collision_enter(
				left, right );
			try
			{
				up.assert_collision_enter();
			}
			catch ( System.Exception e )
			{
				down.assert_collision_enter();
			}
		}

		[UnityTest]
		public IEnumerator move_up_should_can_hit_up_assert()
		{
			controller.desire_direction = Vector3.up;
			yield return new WaitForSeconds( 1 );
			controller.shot();
			yield return new WaitForSeconds( 1 );
			up.assert_collision_enter();

			helper.test.assert.many.assert_colision.assert_not_collision_enter(
				left, right, down );
		}

		[UnityTest]
		public IEnumerator multiple_shots()
		{
			controller.desire_direction = Vector3.up;
			yield return new WaitForSeconds( 1 );
			var bullet = controller.shot();
			yield return new WaitForSeconds( 1 );
			up.assert_collision_enter( bullet[0] );

			controller.desire_direction = Vector3.down;
			yield return new WaitForSeconds( 1 );
			bullet = controller.shot();
			yield return new WaitForSeconds( 1 );
			down.assert_collision_enter( bullet[0] );

			controller.desire_direction = Vector3.right;
			yield return new WaitForSeconds( 1 );
			bullet = controller.shot();
			yield return new WaitForSeconds( 1 );
			right.assert_collision_enter( bullet[0] );
		}
	}
}