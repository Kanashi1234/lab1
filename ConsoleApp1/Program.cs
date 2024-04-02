using System;
using System.Collections.Generic;

public class Node<TKey, TValue> where TKey : IComparable<TKey>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
    public Node<TKey, TValue> Left { get; set; }
    public Node<TKey, TValue> Right { get; set; }

    public Node(TKey key, TValue value)
    {
        Key = key;
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree<TKey, TValue> where TKey : IComparable<TKey>
{
    private Node<TKey, TValue> root;

    public void Put(TKey key, TValue value)
    {
        root = Put(root, key, value);
    }

    private Node<TKey, TValue> Put(Node<TKey, TValue> node, TKey key, TValue value)
    {
        if (node == null)
            return new Node<TKey, TValue>(key, value);

        int cmp = key.CompareTo(node.Key);
        if (cmp < 0)
            node.Left = Put(node.Left, key, value);
        else if (cmp > 0)
            node.Right = Put(node.Right, key, value);
        else
            node.Value = value;

        return node;
    }

    public TValue Get(TKey key)
    {
        return Get(root, key);
    }

    private TValue Get(Node<TKey, TValue> node, TKey key)
    {
        if (node == null)
            throw new KeyNotFoundException("Key not found");

        int cmp = key.CompareTo(node.Key);
        if (cmp < 0)
            return Get(node.Left, key);
        else if (cmp > 0)
            return Get(node.Right, key);
        else
            return node.Value;
    }

    public int Size()
    {
        return Size(root);
    }

    private int Size(Node<TKey, TValue> node)
    {
        if (node == null)
            return 0;
        return 1 + Size(node.Left) + Size(node.Right);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int, string> binaryTree = new BinaryTree<int, string>();

        binaryTree.Put(5, "Five");
        binaryTree.Put(3, "Three");
        binaryTree.Put(7, "Seven");
        binaryTree.Put(2, "Two");
        binaryTree.Put(4, "Four");

        Console.WriteLine("Size of binary tree: " + binaryTree.Size());
        Console.WriteLine("Value for key 3: " + binaryTree.Get(3));
    }
}
