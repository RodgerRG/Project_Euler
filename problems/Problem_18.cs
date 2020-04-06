using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;
namespace Project_Euler.problems
{
    public class Problem_18
    {
        private Node root;
        private List<Node> currents;

        private int idCounter = 2;

        public void addConnection(Node parent, Node child) {
            if(!parent.containsChild(child)) {
                parent.addChild(child);
            }
        }

        public Problem_18() {
            currents = new List<Node>();

            readGraph(currents);
        }

        public void solveProblem() {
            //implement A* here.
            List<Node> paths = new List<Node>();
            Dictionary<Node, Int32> vals = new Dictionary<Node, int>();
            bool isOver = false;
            int currentMax = root.getVal();
            Node currentNode = root;

            vals.Add(root, root.getVal());
            int currentVal = root.getVal();

            Console.WriteLine("Current Max: " + currentMax);
            Console.WriteLine("Current Node: " + currentNode);

            paths.Add(root);

            while(!isOver) {
                Node at = paths.Find(node => node.id == currentNode.id);
                Console.WriteLine(at.id);
                vals.TryGetValue(at, out currentVal);

                paths.Remove(at);

                Console.WriteLine("Current Value: " + currentVal);

                foreach(Node n in at.getChildren()) {
                    //sort paths after this.
                    paths.Add(n);
                    vals.Add(n, currentVal + n.getVal());

                    Console.WriteLine("Current Node Value: " + n.getVal());

                    if(currentVal + n.getVal() > currentMax) {
                        currentMax = currentVal + n.getVal();
                        currentNode = n;
                    }
                }

                if(currentNode.getChildren().Count == 0) {
                    isOver = true;
                }
            }

        }

        private void readGraph(List<Node> currents) {
            StreamReader reader = new StreamReader(new FileStream(System.IO.Directory.GetCurrentDirectory() + "/inputs/Problem_18", FileMode.Open));
            string raw = reader.ReadLine();

            root = new Node(Int32.Parse(raw));
            currents.Add(root);

            while(reader.Peek() != -1) {
                raw = reader.ReadLine();
                string[] inputs = raw.Split(" ");
                int[] vals = new int[inputs.Length];

                for(int i = 0; i < inputs.Length; i++) {
                    vals[i] = Int32.Parse(inputs[i]);
                }

                parseInts(vals, currents);
            }
        }

        private void parseInts(int[] vals, List<Node> currents) {
            List<Node> newNodes = new List<Node>();
            for(int i = 0; i < currents.Count; i++) {
                for(int j = i; j < i + 2; j++) {
                    Node parent = currents[i];
                    Node newNode = new Node(parent, vals[j], idCounter);
                    idCounter++;
                    newNodes.Add(newNode);
                    addConnection(parent, newNode);
                }
            }

            currents = newNodes;
        }


        public class Node {
            private Node parent;
            private List<Node> children;
            private int value;
            public int id;

            public Node(Node parent, int value, int id) {
                this.parent = parent;
                children = new List<Node>();
                this.value = value;
                this.id = id;
            }

            public Node(int value) {
                this.parent = this;
                children = new List<Node>();
                this.value = value;
                this.id = 1;
            }

            public void addChild(Node child) {
                if(!children.Contains(child)) {
                    children.Add(child);
                }
            }

            public bool containsChild(Node child) {
                return children.Contains(child);
            }

            public List<Node> getChildren() {
                return children;
            }

            public int getVal() {
                return value;
            }

            public Node getParent() {
                return parent;
            }

            public override string ToString() {
                return "" + value;
            }

        }
    }  
}