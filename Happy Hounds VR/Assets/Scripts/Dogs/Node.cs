﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>  {

    public bool traversable;
    public Vector3 nodePos;

    public int gCost;
    public int hCost;
    public int gridX;
    public int gridY;
    public Node parent;
    int heapIndex;

    public Node(bool _traversable, Vector3 _nodePos, int _gridX, int _gridY)
    {
        traversable = _traversable;
        nodePos = _nodePos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int HeapIndex
    {
        get { return heapIndex; }
        set { heapIndex = value; }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }

        return -compare;

    }
    public int fCost
    { 
      get{
            return gCost + hCost;

      }
    }
}
