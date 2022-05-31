// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.



namespace SLua
{
	using System;
	using System.Collections.Generic;

	public class WeakDictionary<K, V>
	{
		Dictionary<K, WeakReference> _dict = new Dictionary<K, WeakReference>();

		public V this[K key]
		{
			get
			{
				WeakReference w = _dict[key];
                // IsAlive is not reliable in IL2CPP
                V value = (V)w.Target;
				if (value != null)
					return value;
				return default(V);
			}

			set
			{
				Add(key, value);
			}
		}

		public int AliveCount{
			get{
				int cnt = 0;
				foreach (var pair in _dict) {
                    if (pair.Value.IsAlive && ((V)pair.Value.Target)!=null) {
						cnt++;
					}
				}
				return cnt;
			}
		}

		public ICollection<K> Keys
		{
			get
			{
				return _dict.Keys;
			}
		}
		public ICollection<V> Values
		{
			get
			{
				List<V> l = new List<V>();
				foreach (K key in _dict.Keys)
				{
					l.Add((V)_dict[key].Target);
				}
				return l;
			}
		}

		public void Add(K key, V value)
		{
			if (_dict.ContainsKey(key))
			{
				if (_dict[key].Target != null)
					throw new ArgumentException("key exists");

				_dict[key].Target = value;
			}
			else
			{
				WeakReference w = new WeakReference(value);
				_dict.Add(key, w);
			}
		}

		public bool ContainsKey(K key)
		{
			return _dict.ContainsKey(key);
		}
		public bool Remove(K key)
		{
			return _dict.Remove(key);
		}
		public bool TryGetValue(K key, out V value)
		{
			WeakReference w;
			if (_dict.TryGetValue(key, out w))
			{
				value = (V)w.Target;
				return value!=null;
			}
			value = default(V);
			return false;

		}
	}
}