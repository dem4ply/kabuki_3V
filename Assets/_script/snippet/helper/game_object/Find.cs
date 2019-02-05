using UnityEngine;
using System.Linq;

namespace helper
{
	namespace game_object
	{
		public class Find
		{
			/// <summary>
			/// busca los hijos del gameobject de manera recursiva
			/// </summary>
			/// <param name="obj">padre en el qeu se buscaran</param>
			/// <param name="name">nombre del object qe se busca</param>
			/// <returns>hijo encontrado</returns>
			public static GameObject _( GameObject obj, string name )
			{
				Transform result = _( obj.transform, name );
				if ( result != null )
					return result.gameObject;
				return null;
			}

			public static Transform _( Transform obj, string name )
			{
				Transform result = obj.Find( name );
				if ( result != null )
					return result;
				for ( int i = 0; i < obj.childCount; ++i )
				{
					result = _( obj.GetChild( i ), name );
					if ( result != null )
						return result;
				}
				return null;
			}

			public static T _<T>( GameObject obj, string name )
				where T : MonoBehaviour
			{
				GameObject result = _( obj, name );
				if ( result != null )
					return result.GetComponent<T>();
				return null;
			}

			public static ( T, T ) _<T>(
				GameObject obj, string name1, string name2 )
				where T : MonoBehaviour
			{
				return (
					_<T>( obj, name1 ),
					_<T>( obj, name2 )
				);
			}

			public static ( T, T, T ) _<T>(
				GameObject obj, string name1, string name2, string name3 )
				where T : MonoBehaviour
			{
				return (
					_<T>( obj, name1 ),
					_<T>( obj, name2 ),
					_<T>( obj, name3 )
				);
			}

			public static ( T, T, T, T ) _<T>(
				GameObject obj, string name1, string name2, string name3,
				string name4 )
				where T : MonoBehaviour
			{
				return (
					_<T>( obj, name1 ),
					_<T>( obj, name2 ),
					_<T>( obj, name3 ),
					_<T>( obj, name4 )
				);
			}

			public static ( T, T, T, T, T ) _<T>(
				GameObject obj, string name1, string name2, string name3,
				string name4, string name5 )
				where T : MonoBehaviour
			{
				return (
					_<T>( obj, name1 ),
					_<T>( obj, name2 ),
					_<T>( obj, name3 ),
					_<T>( obj, name4 ),
					_<T>( obj, name5 )
				);
			}

			public static ( T, T, T, T, T, T ) _<T>(
				GameObject obj, string name1, string name2, string name3,
				string name4, string name5, string name6 )
				where T : MonoBehaviour
			{
				return (
					_<T>( obj, name1 ),
					_<T>( obj, name2 ),
					_<T>( obj, name3 ),
					_<T>( obj, name4 ),
					_<T>( obj, name5 ),
					_<T>( obj, name6 )
				);
			}

			public static GameObject[] all( string name )
			{
				GameObject[] result = GameObject.FindObjectsOfType<GameObject>();
				return result.Where( obj => obj.name == name ).ToArray();
			}
		}
	}
}