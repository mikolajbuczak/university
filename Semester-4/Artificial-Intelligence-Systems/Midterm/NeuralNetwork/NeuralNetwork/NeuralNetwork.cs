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

        public double[] Guess(double[] inputsArray)
        {
            //Change inputs into a Matrix object
            var inputs = new Matrix(inputsArray, Matrix.Orientation.Vertical);

            //Calculate hidden Layer values
            var hiddenInputs = Matrix.Dot(this.weightsInputHidden, inputs);
            hiddenInputs.Add(this.biasHidden);
            var hiddenOutputs = Matrix.Map(hiddenInputs, this.Sigmoid);

            //Calculate output Layer values
            var outputInputs = Matrix.Dot(this.weightsHiddenOutput, hiddenOutputs);
            outputInputs.Add(this.biasOutput);
            var outputs = Matrix.Map(outputInputs, this.Sigmoid);

            return outputs.ToArray();
        }

        public void Train(double[] inputsArray, double[] answers)
        {
            //Change inputs into a Matrix object
            var inputs = new Matrix(inputsArray, Matrix.Orientation.Vertical);

            //Change desiered outputs into a Matrix object
            var targets = new Matrix(answers, Matrix.Orientation.Vertical);

            //Calculate hidden Layer values
            var hiddenInputs = Matrix.Dot(this.weightsInputHidden, inputs);
            hiddenInputs.Add(this.biasHidden);
            var hiddenOutputs = Matrix.Map(hiddenInputs, this.Sigmoid);

            //Calculate output Layer values
            var outputInputs = Matrix.Dot(this.weightsHiddenOutput, hiddenOutputs);
            outputInputs.Add(this.biasOutput);
            var outputs = Matrix.Map(outputInputs, this.Sigmoid);

            //Calculate errors of the output layer
            var outputErrors = Matrix.Subtract(targets, outputs);

            //Transpose weightsbetween a hidden layer an an output layer
            var weightsHiddenOutputTransposed = this.weightsHiddenOutput.Transpose();

            //Calculate errors of the hidden layer
            var hiddenErrors = Matrix.Dot(weightsHiddenOutputTransposed, outputErrors);

            //Calculate gradients of the output layer
            var outputsGradients = Matrix.Map(outputs, this.DerivativeSigmoid);
            outputsGradients.Multiply(outputErrors);
            outputsGradients.Multiply(this.learningRate);

            //Calculate gradients of the hidden layer
            var hiddenGradients = Matrix.Map(hiddenOutputs, this.DerivativeSigmoid);
            hiddenGradients.Multiply(hiddenErrors);
            hiddenGradients.Multiply(this.learningRate);

            //Calculate deltas of weights between hidden layer and output layer
            var hiddenOutputsTransposed = hiddenOutputs.Transpose();
            var weightsHiddenOutputDeltas = Matrix.Dot(outputsGradients, hiddenOutputsTransposed);

            //Change weights between hidden layer and output layer
            this.weightsHiddenOutput.Add(weightsHiddenOutputDeltas);
            this.biasOutput.Add(outputsGradients);

            //Calculate deltas of weights between input layer and hidden layer
            var inputsTransposed = inputs.Transpose();
            var weightsInputHiddenDeltas = Matrix.Dot(hiddenGradients, inputsTransposed);

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
