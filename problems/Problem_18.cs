using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;
namespace Project_Euler.problems
{
    public class Problem_18_and_67
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

            readGraph();
        }

        public void solveProblem() {
            List<Node> currentVals = getParents(currents);
            bool isOver = false;

            while(!isOver) {
                int currentMax;
                foreach(Node parent in currentVals) {
                    currentMax = parent.getVal();
                    foreach(Node child in parent.getChildren()) {
                        if(currentMax < parent.getVal() + child.getVal()) {
                            currentMax = parent.getVal() + child.getVal();
                        }
                    }

                    parent.setVal(currentMax);
                }

                if(currentVals.Count == 1) {
                    Console.WriteLine("The Maximum Value Is: " + currentVals[0].getVal());
                    isOver = true;
                }

                currentVals = getParents(currentVals);
            }
        }

        private List<Node> getParents(List<Node> children) {
            List<Node> parents = new List<Node>();
            foreach(Node child in children) {
                foreach(Node parent in child.getParents()) {
                    if(!parents.Contains(parent)) {
                        parents.Add(parent);
                    }
                }
            }

            Console.WriteLine("The number of parents is: " + parents.Count);

            return parents;
        }

        private void readGraph() {
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

                parseInts(vals);
            }
        }

        private void parseInts(int[] vals) {
            List<Node> newNodes = new List<Node>();

            Node parent = currents[0];
            List<Node> parents = new List<Node>();
            parents.Add(parent);
            Node newNode = new Node(parents, vals[0], idCounter);
            idCounter++;

            parent.addChild(newNode);

            newNodes.Add(newNode);

            for(int i = 1; i < vals.Length; i++) {
                try {
                    Node leftParent = currents[i - 1];
                    Node rightParent = currents[i];
                    parents = new List<Node>();

                    parents.Add(leftParent);
                    parents.Add(rightParent);

                    newNode = new Node(parents, vals[i], idCounter);
                    idCounter++;

                    leftParent.addChild(newNode);
                    rightParent.addChild(newNode);

                    newNodes.Add(newNode);
                } catch(ArgumentOutOfRangeException e) {
                    parent = currents[i - 1];
                    parents = new List<Node>();
                    parents.Add(parent);
                    newNode = new Node(parents, vals[i], idCounter);
                    idCounter++;

                    parent.addChild(newNode);

                    newNodes.Add(newNode);
                }
            }
            currents = newNodes;
        }


        public class Node {
            private List<Node> parent;
            private List<Node> children;
            private int value;
            public int id;

            public Node(List<Node> parent, int value, int id) {
                this.parent = parent;
                children = new List<Node>();
                this.value = value;
                this.id = id;
            }

            public Node(int value) {
                this.parent = new List<Node>();
                this.parent.Add(this);
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

            public void setVal(int val) {
                value = val;
            }

            public List<Node> getParents() {
                return parent;
            }

            public Node getParent(int index) {
                return parent[index];
            }

            public override string ToString() {
                return "" + value;
            }

        }
    }  
}