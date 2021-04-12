
using System;
using System.Collections.Generic;


static public class ListsExtensions
{
	static public T GetRandomElement<T>(this IList<T> list)
	{
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	static public void RemoveSwapLast<T>(this IList<T> list, int index)
	{
		int lastItemIndex = list.Count - 1;

		list[index] = list[lastItemIndex];
		list.RemoveAt(lastItemIndex);
	}
}

static public class DictionariesExtensions
{
	static public void AddOrCreate<Key, Value>(this Dictionary<Key, List<Value>> dictionary, Key key, Value value)
	{
		if (!dictionary.TryGetValue(key, out List<Value> values))
		{
			values = new List<Value>();
			dictionary.Add(key, values);
		}

		values.Add(value);
	}

	static public void AddRange<Key, Value>(this IDictionary<Key, Value> dictionary, IEnumerable<Value> values, Func<Value, Key> keySelector)
	{
		foreach (Value value in values)
		{
			Key key = keySelector(value);
			dictionary.Add(key, value);
		}
	}
}
