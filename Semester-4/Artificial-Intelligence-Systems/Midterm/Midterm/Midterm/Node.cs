namespace Midterm
{
    using System;
    class Node
    {
        public bool isClosed { get; private set; }
        public bool isLeaf { get; private set;}
        public List<Item> items { get; private set; }
        public Question Question { get; private set; }
        public Node parent { get; private set; }
        public Node trueChild { get; private set; }
        public Node falseChild { get; private set; }
        public double giniImpurity { get; private set; }
        

        public Node(List<Item> _items, Node _parent)
        {
            this.items = _items;
            this.parent = _parent;
            this.trueChild = null;
            this.falseChild = null;
            this.Question = null;
            this.isLeaf = false;
            this.isClosed = false;
            this.giniImpurity = Gini.GiniImpurity(_items);
        }

        public void SetTestCondition(double testCondition, int testColumn)
        {
            this.Question = new Question(testCondition, testColumn);
        }

        public void CreateTrueChild(List<Item> trueItems)
        {
            this.trueChild = new Node(trueItems, this);
        }

        public void CreateFalseChild(List<Item> falseItems)
        {
            this.falseChild = new Node(falseItems, this);
        }

        public void SetLeaf()
        {
            this.isLeaf = true;
        }

        public void Close()
        {
            this.isClosed = true;
        }
    }
}
