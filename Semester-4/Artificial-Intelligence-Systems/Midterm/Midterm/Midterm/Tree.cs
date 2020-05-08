using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Midterm
{
    class Tree
    {
        public Node Root { get; private set; }

        public Tree(List<Item> items)
        {
            this.Root = new Node(items, null);
        }

        public void ConstructTree()
        {
            Node currentNode = this.Root;
            while(true)
            {
                double bestCondition = -1;
                double bestGiniGain = -1;
                int bestConditionColumn = -1;
                List<Item> TrueList = new List<Item>();
                List<Item> FalseList = new List<Item>();
                for (int j = 0; j < currentNode.items.Size; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        double tempCondition = currentNode.items[j].Data[i];
                        double tempGiniGain;
                        List<Item> tempTrue = new List<Item>();
                        List<Item> tempFalse = new List<Item>();
                        for (int k = 0; k < currentNode.items.Size; k++)
                        {
                            if (currentNode.items[k].Data[i] >= tempCondition)
                            {
                                tempTrue.Push(currentNode.items[k]);
                                continue;
                            }
                            tempFalse.Push(currentNode.items[k]);
                        }
                        tempGiniGain = Gini.GiniGain(currentNode.items, tempTrue, tempFalse);
                        if (tempGiniGain > bestGiniGain)
                        {
                            bestGiniGain = tempGiniGain;
                            bestCondition = tempCondition;
                            TrueList = tempTrue;
                            FalseList = tempFalse;
                            bestConditionColumn = i;
                        }
                    }
                }
                if (bestGiniGain > 0)
                {
                    currentNode.SetTestCondition(bestCondition, bestConditionColumn);
                    currentNode.CreateTrueChild(TrueList);
                    currentNode.CreateFalseChild(FalseList);
                }
                else
                {
                    currentNode.Close();
                    currentNode.SetLeaf();
                    currentNode = currentNode.parent;
                }
                while((currentNode.trueChild.isLeaf || currentNode.trueChild.isClosed) && (currentNode.falseChild.isLeaf || currentNode.falseChild.isClosed))
                {
                    currentNode.Close();
                    if (currentNode == Root)
                        return;
                    currentNode = currentNode.parent;
                }
                if (!(currentNode.trueChild.isLeaf || currentNode.trueChild.isClosed))
                {
                    currentNode = currentNode.trueChild;
                    continue;
                }
                if (!(currentNode.falseChild.isLeaf || currentNode.falseChild.isClosed))
                {
                    currentNode = currentNode.falseChild;
                    continue;
                }
            }
        }
        public double Test(List<Item> items)
        {
            int counter = 0;

            Node currentNode = null;
            for (int i = 0; i < items.Size; i++)
            {
                System.Console.WriteLine($"Gueessing iris nb. [{i}] Type: {items[i].Type}");
                currentNode = Root;
                while (!currentNode.isLeaf)
                {
                    if (items[i].Data[currentNode.Question.TestColumn] >= currentNode.Question.TestCondition)
                    {
                        currentNode = currentNode.trueChild;
                        continue;
                    }
                    currentNode = currentNode.falseChild;
                }
                if (items[i].Type == currentNode.items[0].Type)
                {
                    ++counter;
                    System.Console.WriteLine($"My guess: {currentNode.items[0].Type} [Success]");
                    continue;
                }
                System.Console.WriteLine($"My guess: {currentNode.items[0].Type} [Fail]");
            }
            return (double)counter / items.Size;
        }  

    }
}
