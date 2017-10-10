using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DFS
{
    class Program
    {
        public static int n;
        public static int xp;
        public static int t;
        public static LinkedList<int>[] ds;
        public static Stack<int> stk;
        public static List<int> list;
        public static bool[] visited;
        public static int[] front;

        public static void Input()
        {
            StreamReader sr = new StreamReader("graph.inp");
            string[] so = sr.ReadLine().Split(' ');
            n = int.Parse(so[0]);
            xp = int.Parse(so[1]);
            t = int.Parse(so[2]);
            stk = new Stack<int>();
            list = new List<int>();
            ds = new LinkedList<int>[n];
            visited = new bool[n];
            front = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split(' ');
                ds[i] = new LinkedList<int>();
                for (int j = 0; j < s.Length; j++)
                {
                    ds[i].AddLast(int.Parse(s[j]));
                }
            }
            sr.Close();
        }
        public static void Output()
        {
            for (int i = 0; i < n; i++)
            {
                foreach (var x in ds[i])
                    Console.Write(x + " ");
                Console.WriteLine();
            }
        }
        #region DFS 2
        public static void DFS_2() // mo phong BFS
        {
            visited[xp - 1] = true;
            list.Add(xp);
            stk.Push(xp);
            front[xp - 1] = -1;
            while (stk.Count != 0)
            {
                int d = stk.Pop();
                foreach (int x in ds[d - 1])
                {
                    if (visited[x - 1]) continue;
                    stk.Push(x);
                    visited[x - 1] = true;
                    front[x - 1] = d - 1;
                    list.Add(x);
                }
            }

        }
        public static bool CheckInArray(int x)
        {
            foreach (int items in list)
            {
                if (items == x)
                    return true;
            }
            return false;

        }
        #endregion

        #region DFS
        public static Queue<int> q = new Queue<int>();
        public static void DFS(int x)
        {
            if (visited[x]) return;
            visited[x] = true;
            q.Enqueue(x);
            foreach (int i in ds[x])
            {
                if (front[i - 1] == 0)
                    front[i - 1] = x + 1;
                DFS(i - 1);
            }
        }
        public static void PrintList()
        {
            Console.WriteLine("Danh Sach DFS: ");
            while (q.Count != 0)
                Console.Write(q.Dequeue() + 1 + " ");
            Console.WriteLine();
        }
        #endregion

        public static void Find(int a, int b)
        {
            Stack<int> way = new Stack<int>();
            way.Push(b);
            while (front[b-1] != -1)
            {
                b = front[b - 1];
                way.Push(b);
            }
            //debug
            while(way.Count!=0)
                Console.Write(way.Pop()+ " ");
            Console.WriteLine();
        }
        static void check()
        {
            foreach(int i in front)
                Console.Write(i+" ");
        }
        static void Main(string[] args)
        {
            Input();
            Output();
            front[xp - 1] = -1;
            DFS(xp - 1);
            PrintList();
            //DFS_2();
            Find(xp, t);
            check();
        }
    }
}
