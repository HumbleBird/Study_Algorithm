using System;
using System.Collections.Generic;

namespace StackQueue_Exercise
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 5, 10, -1, -1 },
            { -1, 5, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 5, -1 },
            { -1, -1, -1, 5, -1, 5 },
            { -1, -1, -1, -1, 5, -1 }
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];

            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    if (visited[i])
                        continue;

                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;

                    closest = distance[i];
                    now = i;
                }

                if (now == -1)
                    break;
                visited[now] = true;

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == -1)
                        continue;

                    if (visited[next])
                        continue;

                    int nextDist = distance[now] + adj[now, next] ;

                    if(nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                         parent[next] = now;
                    }
                }
            }
        }

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0)
                        continue;
                    if (found[next])
                        continue;
                    q.Enqueue(next);
                    found[next] = true;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.Dijikstra(0);
        }
    }
}
