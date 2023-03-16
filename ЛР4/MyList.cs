	internal class List
	{
		public class Node<T>
		{
			public Node<T> prev;
			public Node<T> pos;
			public T val;
			public Node(T v)
			{
				val = v;
				prev = null;
				pos = null;
				//			Console.WriteLine("Node(T val)");
			}

		};

		public class MyList<T>
		{
			public Node<T> first;
			public Node<T> last;
			int size;

			public MyList()
			{
				last = null;
				first = null;
				size = 0;
			}

			public void PushBack(T v)
			{
				if (size != 0)
				{
					Node<T> p = new Node<T>(v);
					p.prev = last;
					last.pos = p;
					last = p;
				}
				else
				{
					first = new Node<T>(v);
					last = first;
				}
				size++;
			}

			public void PushFront(T v)
			{
				if (size != 0)
				{
					Node<T> p = new Node<T>(v);
					p.pos = first;
					first.prev = p;
					first = p;
				}
				else
				{
					first = new Node<T>(v);
					last = first;
				}
				size++;
			}

			public void insert(T v, int plase)
			{
				if (plase == 0)
				{
					PushFront(v);
				}
				else if (plase >= size)
				{
					PushBack(v);
				}
				else
				{
					Node<T> cur = first;
					for (int i = 0; i < plase - 1; i++)
					{
						cur = cur.pos;
					}
					Node<T> p = new Node<T>(v);
					Node<T> tmp = cur.pos;
					cur.pos = p;
					p.prev = cur;

					tmp.prev = p;
					p.pos = tmp;
					size++;
				}
			}

			public T pop_front()
			{
				T x = this.first.val;
				first = first.pos;
				first.prev = null;
				return x;

			}
			public T pop_back()
			{
				T x = this.last.val;
				last = last.prev;
				last.pos = null;
				return x;
			}
			public int get_size()
			{
				return size;
			}

			public int find(T data)
			{
				Node<T> cur = first;
				int i = 0;
				while (cur != null)
				{
					if (cur.val.Equals(data))
					{
						return i;
					}
					cur = cur.pos;
					i++;
				}
				return -1;
			}
			public bool remove(T data)
			{
				int f = find(data);
				if (f == -1)
				{
					return false;
				}
				else if (f == 0)
				{
					if (size == 1)
					{
					first = null;
					last = null;
					}
					else
					{
					first = first.pos;
					first.prev = null;
					}
				}
				else if (f == size - 1)
				{
					last = last.prev;
					last.pos = null;
				}
				else
				{
					Node<T> cur = first;
					for (int i = 0; i < f; i++)
					{
						cur = cur.pos;
					}
					cur.prev.pos = cur.pos;
					cur.pos.prev = cur.prev;
				}
				size--;
				return true;
			}
			public void clear()
			{
				first = null;
				last = null;
				size = 0;
			}
		};
	}
