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
                Node<T> p = new Node<T>(v);
                p.prev = last;

                if (last != null)
                    last.pos = p;
                if (first == null)
                    first = p;
                last = p;
                size++;
            }

            public void PushFront(T v)
            {
                Node<T> p = new Node<T>(v);
                p.pos = first;
                if (first != null)
                {
                    first.prev = p;
                    first = p;
                }
                else
                {
                    first = p;
                    last = first;
                }
                size++;
            }

            public void insert(T v, int plase)
            {
                if (plase <= 0)
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
                T pop = first.val;
                first = first.pos;
                first.prev = null;
                return pop;

            }
            public T pop_back()
            {
                T pop = this.last.val;
                last = last.prev;
                last.pos = null;
                return pop;
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
                        pop_front();
                    }
                }
                else if (f == size - 1)
                {
                    pop_back();
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
    public Iterator<T> CreateIterator()
    {
        return new Standart_Iterator<T>(this);
    }
        };



public abstract class Iterator<T>
	{
        public MyList<T> list;
        public Node<T> cur_item;
        public int cur_index;
        public abstract void first();
		public abstract T getCurrentItem();
		public abstract void setCurrentItem(T item);
		public abstract void next();
		public abstract void previos();
		public abstract bool isEOL();
		public abstract void remove();
		public abstract Iterator<T> clone();
	}

	public class Standart_Iterator<T>: Iterator<T>
	{
		//public MyList<T> list;
		//public Node<T> cur_item;
		//public int cur_index;
		public Standart_Iterator(MyList<T> l)
		{
			list = l;
			cur_index = 0;
			cur_item = list.first;
	
		}
		public Standart_Iterator(Iterator<T> i)
		{
			list = i.list;
			cur_index = i.cur_index;
			cur_item = i.cur_item;
		}

        public override Iterator<T> clone()
		{
			return new Standart_Iterator<T>(this);
		}

		public override void first()
		{
			cur_item = list.first;
			cur_index = 0;
		}
		public override T getCurrentItem()
		{
			return cur_item.val;
		}
		public override void setCurrentItem(T item)
		{
			list.insert(item, cur_index);
		}
		public override void next()
		{
				cur_item = cur_item.pos;
				cur_index++;
		}
        public override void previos()
        {

				cur_item = cur_item.prev;
				cur_index--;
        }
        public override bool isEOL()
		{
			return cur_item == null;
		}
        public override void remove()
        {
			list.remove(cur_item.val);
        }
    }

