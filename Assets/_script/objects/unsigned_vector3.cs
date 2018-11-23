using UnityEngine;
using System.Collections;


namespace chibi
{
	public class unsigned_vector3
	{

		protected float _x, _y, _z;

		public float x
		{
			get {
				return _x;
			}
			set {
				_x = value > 0 ? value : 0f;
			}
		}

		public float y
		{
			get {
				return _y;
			}
			set {
				_y = value > 0 ? value : 0f;
			}
		}

		public float z
		{
			get {
				return _z;
			}
			set {
				_z = value > 0 ? value : 0f;
			}
		}
	}
}