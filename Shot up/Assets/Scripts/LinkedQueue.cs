using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
	public class LinkedQueue<T> : LinkedList<T>
	where T: class
	{
		public T Peek()
		{
			if (Count > 0)
			{
				return First.Value;
			}
			else
			{
				return null;
			}
		}

		public void Enqueue(T element)
		{
			AddLast(element);
		}

		public T Dequeue()
		{
			T node = Peek();
			if (Count > 0)
			{
				RemoveFirst();
			}
			return node;
		}
	}
}