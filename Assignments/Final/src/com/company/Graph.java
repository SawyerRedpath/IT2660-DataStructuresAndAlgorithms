package com.company;

import java.util.*;

public class Graph {
    private int V;   // No. of vertices
    private LinkedList<Integer> adj[]; //Adjacency Lists

    // Constructor
    Graph(int v)
    {
        V = v;
        adj = new LinkedList[v];
        for (int i=0; i<v; ++i)
            adj[i] = new LinkedList();
    }

    void addAnEdge(int v,int w)
    {
        adj[v].add(w);
    }

    void BreadthFirstSearch(int s)
    {
        // counter to track distance
        int counter = 1;

        boolean visitedVertices[] = new boolean[V];

        LinkedList<Integer> queue = new LinkedList<Integer>();

        visitedVertices[s]=true;
        queue.add(s);

        while (queue.size() != 0)
        {
            s = queue.poll();
            System.out.print(s+" ");


            Iterator<Integer> i = adj[s].listIterator();
            while (i.hasNext())
            {
                int n = i.next();
                if (!visitedVertices[n])
                {
                    visitedVertices[n] = true;
                    queue.add(n);
                    counter ++;
                }
            }
        }
    }


    void DepthFirstUtilityRecursive(int v,boolean visited[])
    {
        // Mark the current node as visited and print it
        visited[v] = true;
        System.out.println(v);

        // Recur for all the vertices adjacent to this vertex
        Iterator<Integer> i = adj[v].listIterator();
        while (i.hasNext())
        {
            int n = i.next();
            if (!visited[n])
                DepthFirstUtilityRecursive(n,visited);
        }
    }


    void DepthFirstSearch()
    {
        boolean visited[] = new boolean[V];

        for (int i=0; i<V; ++i)
            if (visited[i] == false)
                DepthFirstUtilityRecursive(i, visited);
    }


    public static void main(String args[])
    {
        Graph graph = new Graph(100000);

        graph.addAnEdge(0, 1);
        graph.addAnEdge(0, 2);
        graph.addAnEdge(1, 2);
        graph.addAnEdge(2, 0);
        graph.addAnEdge(2, 3);
        graph.addAnEdge(3, 3);

        System.out.println("BreadthFirstSearch starting from vertice1");

        graph.BreadthFirstSearch(1);

        System.out.println("DepthFirstSearch Entire Graph");
        graph.DepthFirstSearch();
    }



}
