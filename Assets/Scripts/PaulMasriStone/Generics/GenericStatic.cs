using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PaulMasriStone.Generic
{
	public static class GenericStatic
	{
		public static T DeepCopy<T>(this T item)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream stream = new MemoryStream();
			formatter.Serialize(stream, item);
			stream.Seek(0, SeekOrigin.Begin);
			T result = (T)formatter.Deserialize(stream);
			stream.Close();
			return result;
		}

		public static void Shuffle<T>(this IList<T> tList)
		{
			var count = tList.Count;
			var last = count - 1;
			for (var i = 0; i < last; i++)
			{
				var r = UnityEngine.Random.Range(i, count);
				var tmp = tList[i];
				tList[i] = tList[r];
				tList[r] = tmp;
			}
		}
	}
}