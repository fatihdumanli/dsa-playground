﻿namespace AddAndSearchWordLib;

public class TrieNode
{
    public char val { get; set; }
    public TrieNode[] children { get; set; }

    public TrieNode()
    {
        children = new TrieNode[27];
    }

    public TrieNode(char val)
    {
        children = new TrieNode[27];
        this.val = val;
    }
}

public class WordDictionary
{

    private TrieNode root = new TrieNode();

    public WordDictionary()
    {
    }

    public void AddWord(string word)
    {
        var ptr = root;

        for (int i = 0; i < word.Length; i++)
        {
            var ascii = word[i];

            var idx = ascii - 97;

            var child = ptr.children[idx];

            if (child == null)
                ptr.children[idx] = new TrieNode(word[i]);

            ptr = ptr.children[idx];
        }

        //the end of the word
        ptr.children[26] = new TrieNode(' ');
    }

    public bool Search(string word)
    {
        var res = Helper(word, 0, root);
        return res;
    }

    public bool Helper(string word, int i, TrieNode node)
    {
        if (node == null)
            return false;

        if (i >= word.Length)
        {
            if (node.children[26] != null)
                return true;

            return false;
        }

        if (word[i] == '.')
        {
            foreach (var item in node.children)
            {
                if (item != null)
                {
                    var res = Helper(word, ++i, item);

                    if (res)
                    {
                        return true;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        else
        {
            var ascii = word[i];
            var idx = ascii - 97;

            var child = node.children[idx];

            var res = Helper(word, ++i, child);

            if (res)
                return true;
        }


        return false;
    }

}
