namespace Midterm
{
    class Question
    {
        public double TestCondition { get; private set; }
        public int TestColumn { get; private set; }

        public Question(double testCondition, int testColumn)
        {
            this.TestCondition = testCondition;
            this.TestColumn = testColumn;
        }
    }
}
