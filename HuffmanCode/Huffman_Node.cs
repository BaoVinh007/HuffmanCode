using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace HuffmanCode
{
    class Huffman_Node
    {
        public string data { get; set; }
        public string symbol { get; set; }
        public double probability { get; set; }
        public Huffman_Node Right { get; set; }
        public Huffman_Node Left { get; set; }

        public Huffman_Node()
        {
            data = "";
            symbol = "*";
            probability = 0.0;
            Right = null;
            Left = null;
        }

        public Huffman_Node(string s, double prob)
        {            
            symbol = s;
            probability = prob;
            Right = null;
            Left = null;
        }        

        public Huffman_Node(string d, string s, double prob)
        {
            data = d;
            symbol = s;
            probability = prob;
            Right = null;
            Left = null;
        }        
        
        public void pathToNode(Huffman_Node p, string target, string res)
        {
            if (p == null)
            {
                res = "";
                return;
            }
            else
            {
                if (p.symbol == target)
                {
                    res += p.data;
                    MessageBox.Show("Encoding "+target +" = " + res);
                    //System.out.println(res);
                    return;
                }
                else
                {                    
                    res += p.data;
                    pathToNode(p.Left, target, res);
                    pathToNode(p.Right, target, res);
                }
            }
        }

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            // Leaf
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.symbol))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.Traverse(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }

    }
}
