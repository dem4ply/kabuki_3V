using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chibi.controller.npc
{
	public class Soldier_controller : Controller
	{
		public chibi.controller.weapon.gun.turrent.Controller_turrent turrent;
		public chibi.controller.npc.Controller_npc npc;
		public Transform hold_turrent_position;

		public void change_owner_turrent()
		{
			throw new System.NotImplementedException();
		}

		public void release_turrent()
		{
			throw new System.NotImplementedException();
		}

		public void hold_turrent()
		{
			throw new System.NotImplementedException();
		}

		protected override void load_motors()
		{
			//base.load_motors();
		}
	}
}
