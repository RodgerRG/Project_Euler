using System;
using System.Collections.Generic;
using System.IO;
namespace Project_Euler.problems
{
    public class Problem_24
    {
        private static Dictionary<int, int> values = new Dictionary<int, int>();

        private static Node root;

        private static Stack<Node> currents;
        public static void SolveProblem() {
            createGraph();
        }

        private static void traverseGraph() {
            int counter = 0;

            Stack<Node> paths = new Stack<Node>();
            List<Node> toAdd = root.getChildren();

            for(int i = toAdd.Count - 1; i >= 0; i--) {
                paths.Push(toAdd[i]);
            }

            while(counter < 1000000) {
                Node current = paths.Pop();
                toAdd = root.getChildren();

                if(toAdd.Count == 0) {
                    counter++;

                    Console.WriteLine(printValue(current));

                    continue;
                }
                
                for(int i = toAdd.Count - 1; i >= 0; i--) {
                    paths.Push(toAdd[i]);
                }
            }
        }

        private static string printValue(Node node) {
            string output = "";
            Node current = node;

            while(current.getVal() != -1) {
                output = current.getVal() + output;
                current = current.getParent();
            }

            return output;
        }

        private static void createGraph() {
            int counter = 0;

            root = new Node();
            currents = new Stack<Node>();

            for(int i = 9; i >= 0; i--) {
                Node n = new Node(root, i);
                root.addChild(n);
                currents.Push(n);
            }

            bool isOver = false;

            while(!isOver) {
                Node current = currents.Pop();

                for(int i = 9; i >= 0; i--) {
                    Node n = new Node(current, i);

                    if(checkAncestry(current, n)) {
                        current.addChild(n);
                        currents.Push(n);
                    }
                }

                if(current.getChildren().Count == 0) {
                    Console.WriteLine(printValue(current));
                    counter++;
                }

                if(counter == 1000000) {
                    Console.WriteLine(printValue(current));
                    return;
                }

                if(currents.Count == 0) {
                    isOver = true;
                }
            }
        }

        private static bool checkAncestry(Node current, Node n) {
            List<int> takens = new List<int>();
            Node temp = current;
            while(temp.getVal() != -1) {
                takens.Add(temp.getVal());

                temp = temp.getParent();
            }

            if(takens.Contains(n.getVal())) {
                return false;
            }

            return true;
        }

        private class Node {
            private int val;
            private Node parent;
            private List<Node> children;

            public Node() {
                this.parent = this;
                this.val = -1;
                this.children = new List<Node>();
            }

            public Node(Node parent, int val) {
                this.parent = parent;
                this.val = val;
                this.children = new List<Node>();
            }

            public void addChild(Node child) {
                children.Add(child);
            }

            public int getVal() {
                return val;
            }

            public Node getParent() {
                return parent;
            }

            public List<Node> getChildren() {
                return children;
            }
        }
    }
}