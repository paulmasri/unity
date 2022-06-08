using System;

namespace PaulMasriStone.Interfaces
{
	public interface IJsonSerializer
	{
		string ToJson(bool pretty = false);
		bool FromJson(string json); // returns success; on fail, should leave the class untouched
	}
}
