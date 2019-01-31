using System.Collections.Generic;
using UnityEngine;

namespace chibi.weapon
{
	public abstract class Weapon : Chibi_behaviour
	{
		public rol_sheet.Rol_sheet owner;

		public abstract void attack();
	}
}
