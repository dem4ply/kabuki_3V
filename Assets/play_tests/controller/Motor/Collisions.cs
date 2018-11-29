using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;

namespace tests.controller.motor.npc.isometric
{
	public class Collisions : helper.tests.Scene_test
	{
		chibi.controller.npc.Controller_npc motor;

		public override string scene_dir
		{
			get {
				return
					"tests/scene/controller/motor/npc/" +
					"motor isometric collisions";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();

			motor = helper.game_object.Find._<
				chibi.controller.npc.Controller_npc>( scene, "npc" );
		}

		[UnityTest]
		public IEnumerator should_be_grounded()
		{
			yield return new WaitForSeconds( 1 );
			Assert.IsTrue( motor.is_grounded );
		}

		[UnityTest]
		public IEnumerator should_be_walled()
		{
			yield return new WaitForSeconds( 2 );
			Assert.IsTrue( motor.is_walled );
		}
	}
}
