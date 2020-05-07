namespace NeuralNetwork
{
    using System;
    class NeuralNetwork
    {
        private int numberOfInputNodes;
        private int numberOfHiddenNodes;
        private int numberOfOutputNodes;

        private Matrix weightsInputHidden;
        private Matrix weightsHiddenOutput;

        private Matrix biasHidden;
        private Matrix biasOutput;

        private double learningRate;

        public NeuralNetwork(int _numberOfInputNodes, int _numberOfHiddenNodes, int _numberOfOutputNodes)
        {
            this.numberOfInputNodes = _numberOfInputNodes;
            this.numberOfHiddenNodes = _numberOfHiddenNodes;
            this.numberOfOutputNodes = _numberOfOutputNodes;

            this.weightsInputHidden = new Matrix(this.numberOfHiddenNodes, this.numberOfInputNodes);
            this.weightsHiddenOutput = new Matrix(this.numberOfOutputNodes, this.numberOfHiddenNodes);

            Random random = new Random();

            this.weightsInputHidden.Randomize(random);
            this.weightsHiddenOutput.Randomize(random);

            this.biasHidden = new Matrix(this.numberOfHiddenNodes, 1, 1);
            this.biasOutput = new Matrix(this.numberOfOutputNodes, 1, 1);

            this.learningRate = 0.1;
        }

        public void SetInitialWieghts(double[,] inputHiddenWeights, double[,] hiddenOutputWeights)
        {
            this.weightsInputHidden.SetValues(inputHiddenWeights);
            this.weightsHiddenOutput.SetValues(hiddenOutputWeights);
        }

        public double[] Guess(double[] input)
        {
            //Change inputs into a Matrix object
            Matrix inputMatrix = new Matrix(input, Matrix.Orientation.Vertical);

            //Calculate hidden Layer values
            var hiddenMatrix = Matrix.Multiply(this.weightsInputHidden, inputMatrix);
            hiddenMatrix.Add(this.biasHidden);
            hiddenMatrix.Map(this.Sigmoid);

            //Calculate output Layer values
            var outputMatrix = Matrix.Multiply(this.weightsHiddenOutput, hiddenMatrix);
            outputMatrix.Add(this.biasOutput);
            outputMatrix.Map(this.Sigmoid);

            return outputMatrix.ToArray();
        }

        public void Train(double[] inputs, double[] answers)
        {
            //Change inputs into a Matrix object
            var inputMatrix = new Matrix(inputs, Matrix.Orientation.Vertical);

            //Change desiered outputs into a Matrix object
            var targets = new Matrix(answers, Matrix.Orientation.Vertical);

            //Calculate hidden Layer values
            var hiddenMatrix = Matrix.Multiply(this.weightsInputHidden, inputMatrix);
            hiddenMatrix.Add(this.biasHidden);
            hiddenMatrix.Map(this.Sigmoid);

            //Calculate output Layer values
            var outputMatrix = Matrix.Multiply(this.weightsHiddenOutput, hiddenMatrix);
            outputMatrix.Add(this.biasOutput);
            outputMatrix.Map(this.Sigmoid);

            //Calculate errors of the output layer
            var outputErrors = Matrix.Subtract(targets, outputMatrix);

            //Calculate gradients of the output layer
            var outputsGradients = Matrix.Map(outputMatrix, DerivativeSigmoid);
            outputsGradients.Multiply(outputErrors);
            outputsGradients.Multiply(this.learningRate);

            //Calculate deltas of weights between hidden layer and output layer
            var transposedHiddens = Matrix.Transpose(hiddenMatrix);
            var weightsHiddenOutputDeltas = Matrix.Multiply(outputsGradients, transposedHiddens);

            //Change weights between hidden layer and output layer
            this.weightsHiddenOutput.Add(weightsHiddenOutputDeltas);
            this.biasOutput.Add(outputsGradients);

            //Calculate errors of the hidden layer
            var weightsHiddenOutputTrapsosed = Matrix.Transpose(this.weightsHiddenOutput);
            var hiddenErrors = Matrix.Multiply(weightsHiddenOutputTrapsosed, outputErrors);

            //Calculate gradients of the hidden layer
            var hiddenGradients = Matrix.Map(hiddenMatrix, DerivativeSigmoid);
            hiddenGradients.Multiply(hiddenErrors);
            hiddenGradients.Multiply(this.learningRate);

            //Calculate deltas of weights between input layer and hidden layer
            var transposedInputs = Matrix.Transpose(inputMatrix);
            var weightsInputHiddenDeltas = Matrix.Multiply(hiddenGradients, transposedInputs);

            //Change weights between input layer and hidden layer
            this.weightsInputHidden.Add(weightsInputHiddenDeltas);
            this.biasHidden.Add(hiddenGradients);
        }

        public double Sigmoid(double x)
        {
            return (1 / (1 + Math.Pow(Math.E, -x)));
        }

        public double DerivativeSigmoid(double x)
        {
            return (x * (1 - x));
        }
    }
}
