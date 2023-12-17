using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Tree
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();


        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그랭밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }


            }

            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            Console.WriteLine(root.Data);

            foreach (TreeNode<string> c in root.Children)
            {
                PrintTree(c);
            }
        }

        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach (TreeNode<string> c in root.Children)
            {
                int newHeight = GetHeight(c) + 1;
                if (height < newHeight)
                    height = newHeight;
            }

            return height;
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }


        public T Pop()
        {
            T ret = _heap[0];

            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                if (next == now)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;

        }

    }

    class Knight : IComparable<Knight>
    {
        public int ID { get; set; }

        public int CompareTo(Knight other)
        {
            if (ID == other.ID)
                return 0;
            return ID > other.ID ? 1 : -1;

        }
    }

    class Program
    {


        static void Main(string[] args)
        {

            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() { ID = 20});
            q.Push(new Knight() { ID = 10});
            q.Push(new Knight() { ID = 50});
            q.Push(new Knight() { ID = 70});
            q.Push(new Knight() { ID = 4});

            while (q.Count () > 0)
            {
                Console.WriteLine(q.Pop().ID);
            }
        }
    }
}
