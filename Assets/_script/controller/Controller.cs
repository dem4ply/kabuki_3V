using UnityEngine;
using System.Collections;
using controller;
using controller.animator;

namespace chibi.controller
{
	public abstract class Controller : Chibi_behaviour
	{

		#region variables protected
		#endregion

		#region propiedades publicas
		public abstract Vector3 desire_direction
		{
			get;
			set;
		}

		public abstract Vector3 speed
		{
			get;
			set;
		}
		#endregion

		#region funciones publicas
		#endregion

		#region funciones protegidas
		#endregion
	}
}
