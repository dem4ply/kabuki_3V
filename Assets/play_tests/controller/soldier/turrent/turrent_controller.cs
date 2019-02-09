using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using chibi.controller.weapon.gun.bullet;

namespace tests.controller.trigger
{
	public class turrent_controller : helper.tests.Scene_test
	{
		Assert_colision forward, left, right, back;
		chibi.controller.weapon.gun.turrent.Controller_turrent turrent;
		chibi.controller.npc.Soldier_controller npc;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/controller/soldier/turrent controller";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			( back, forward, left, right ) = 
				helper.game_object.Find._<Assert_colision>(
					scene, "back", "forward", "left", "right" );

			turrent = helper.game_object.Find._<
				chibi.controller.weapon.gun.turrent.Controller_turrent>(
				scene, "turrent" );

			npc = helper.game_object.Find._<
				chibi.controller.npc.Soldier_controller>( scene, "npc" );
		}

		[UnityTest]
		public IEnumerator when_grab_the_turrent_the_npc_should_no_move()
		{
			yield return new WaitForSeconds( 0.5f );
			npc.grab_turrent();
			yield return new WaitForSeconds( 0.5f );
			npc.desire_direction = Vector3.left;
			yield return new WaitForSeconds( 1f );
			left.assert_not_collision_enter( npc );
		}

		[UnityTest]
		public IEnumerator when_grab_and_release_the_npc_should_move()
		{
			yield return new WaitForSeconds( 0.5f );
			npc.grab_turrent();
			yield return new WaitForSeconds( 0.5f );
			npc.desire_direction = Vector3.left;
			yield return new WaitForSeconds( 0.5f );
			npc.release_turrent();
			yield return new WaitForSeconds( 1f );
			left.assert_not_collision_enter( npc );
		}

		[UnityTest]
		public IEnumerator when_shot_left_the_bullet_should_hit_left()
		{
			yield return new WaitForSeconds( 0.5f );
			npc.grab_turrent();
			yield return new WaitForSeconds( 0.5f );
			npc.desire_direction = Vector3.left;
			var bullet = npc.shot();
			yield return new WaitForSeconds( 1f );
			left.assert_collision_enter( bullet );
		}
	}
}