using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using chibi.controller.npc;

namespace tests.controller.motor.isometric.jump
{
	public class Vertical_jump : helper.tests.Scene_test
	{
		Assert_colision jump, jump_2, jump_3;
		Controller_npc controller;

		public override string scene_dir
		{
			get {
				return "tests/scene/controller/motor/npc/motor isometric";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			jump = helper.game_object.Find._<Assert_colision>(
				scene, "assert jump 1" );

			jump_2 = helper.game_object.Find._<Assert_colision>(
				scene, "assert jump 2" );

			jump_3 = helper.game_object.Find._<Assert_colision>(
				scene, "assert jump 3" );

			controller = helper.game_object.Find._<Controller_npc>(
				scene, "npc" );
		}

		[UnityTest]
		public IEnumerator when_move_to_up_should_touch_collider_up()
		{
			yield return new WaitForSeconds( 2 );
			controller.jump();
			yield return new WaitForSeconds( 1 );
			jump.assert_collision_enter( controller.gameObject );
			jump_2.assert_collision_enter( controller.gameObject );
			jump_3.assert_not_collision_enter();
		}
	}
}
