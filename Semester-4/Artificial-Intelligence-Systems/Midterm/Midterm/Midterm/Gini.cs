namespace Midterm
{
    class Gini
    {
        private static readonly int classCount = 3;
        public static double GiniImpurity(List<Item> items)
        {
            double[] typeCounts = new double[classCount];
            for(int i = 0; i < items.Size; i++)
                typeCounts[(int)items[i].Type]++;

            double[] probabilities = new double[classCount];
            double impurity = 0;
            for(int i = 0; i < classCount; i++)
            {
                probabilities[i] = (typeCounts[i] / items.Size) * (1 - (typeCounts[i] / items.Size));
                impurity += probabilities[i];
            }

            return impurity;
        }

        public static double GiniGain(List<Item> original, List<Item> trueList, List<Item> falseList)
        {
            double originalImpurity = GiniImpurity(original);
            double trueListImpurity = GiniImpurity(trueList);
            double falseListImpurity = GiniImpurity(falseList);
            double trueListWeight = (trueList.Size / (double)original.Size);
            double falseListWeight = (falseList.Size / (double)original.Size);
            double giniGain = originalImpurity - (trueListImpurity * trueListWeight) - (falseListImpurity * falseListWeight);
            return giniGain;
        }

    }
}
