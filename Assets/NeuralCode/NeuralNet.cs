using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
	public class NeuralNet
	{
		public double LearnRate { get; set; } // set; and get; are shorthand for set => this.LearnRate=value; get=> return this.LearnRate; used to change the overall learning speed of the system by Training parameter that controls the size of weight and bias changes in learning of the training algorithm
		public double Momentum { get; set; } //Momentum is a technique used to improve training speed and accuracy and Used to prevent the system from converging to a local minimum "REACHING ZERO"
		public List<Neuron> InputLayer { get; set; } //Create the list that holds input values
		public List<List<Neuron>> HiddenLayers { get; set; } //Create multi dimension list that holds hidden layer with its neurons
		public List<Neuron> OutputLayer { get; set; } //Create the list that holds output values

		private static readonly System.Random Random = new System.Random(); //Define the vaiable that holds random value

		public NeuralNet(int inputSize, int hiddenSize, int outputSize, int numHiddenLayers = 1, double? learnRate = null, double? momentum = null)
		{
			LearnRate = learnRate ?? .4; // ?? refers to if the variable is == null then its value equal to 0.4
			Momentum = momentum ?? .9; // the best value for my network and considerd as default number
			InputLayer = new List<Neuron>();
			HiddenLayers = new List<List<Neuron>>();
			OutputLayer = new List<Neuron>();

			for (var i = 0; i < inputSize; i++) //Add input layers neurons and loop until it matches the inputSize value
				InputLayer.Add(new Neuron());

		for (int i = 0; i < numHiddenLayers; i++) //Add hidden layers neurons and loop until it matches the numHiddenLayers value
		{
			HiddenLayers.Add(new List<Neuron>());
			for (var j = 0; j < hiddenSize; j++) //Add hidden layers neurons and loop until it matches the hiddenSize value
				HiddenLayers[i].Add(new Neuron(i==0?InputLayer:HiddenLayers[i-1]));
		}

			for (var i = 0; i < outputSize; i++) //Add output layers neurons and loop until it matches the outputSize value
				OutputLayer.Add(new Neuron(HiddenLayers[numHiddenLayers-1]));
		}

		public void Train(List<DataSet> dataSets, int numEpochs)  
		{
			for (var i = 0; i < numEpochs; i++)
			{
				foreach (var dataSet in dataSets)
				{
					ForwardPropagate(dataSet.Values);
					BackPropagate(dataSet.Targets);
				}
			}
		}

		public void Train(List<DataSet> dataSets, double minimumError) //create a list that holds all the datasets such as input, output and hiddenlayers
		{
			var error = 1.0; //define the error
			var numEpochs = 0; //define the number of ephocs
			
			while (error >= minimumError && numEpochs < int.MaxValue) //Combare the error with the minimumError that would be defiend later
			{
				var errors = new List<double>(); // Hold the error percentage in a new list
				foreach (var dataSet in dataSets) //Loop for each item in the dataset
				{
					ForwardPropagate(dataSet.Values); //Abbly Forward Propagate function for each value in the dataset
					BackPropagate(dataSet.Targets); //Abbly Back Propagate function for each value in the dataset
					errors.Add(CalculateError(dataSet.Targets));  //use the calculateError function to calculate the error
				}
				error = errors.Average(); //calculate the error by using average() functiom
				numEpochs++; //increment the ephocs value by every iteration
			}
			
			Debug.Log("Error : " + error); //Debug the final error percentage
		}

		private void ForwardPropagate(params double[] inputs)
		{
			var i = 0;
			InputLayer.ForEach(a => a.Value = inputs[i++]); //ably this to all input values
			foreach (var layer in HiddenLayers) 
				layer.ForEach(a => a.CalculateValue()); //Ably CalculateValue() function to hiddenLayers list which ably activation function to (weight*input)+bias 
			OutputLayer.ForEach(a => a.CalculateValue()); //Ably CalculateValue() function to output list which ably activation function to (weight*input)+bias 
		}

		private void BackPropagate(params double[] targets)
		{
			var i = 0; 
			OutputLayer.ForEach(a => a.CalculateGradient(targets[i++])); //Ably CalculateGradient() function to all output values which adjust the actual error to meet the desired error(MinimumError)
			foreach(var layer in HiddenLayers.AsEnumerable<List<Neuron>>().Reverse() ) //go to the opposite direction from output to the hidden layer
			{
				layer.ForEach(a => a.CalculateGradient()); //Ably the CalculateGradient() to hiddenLayers list which adjust the actual error to meet the desired error(MinimumError)
				layer.ForEach(a => a.UpdateWeights(LearnRate, Momentum)); //Ably the UpdateWeights() to hiddenLayers list which update the weight and bias for every node
			}
			OutputLayer.ForEach(a => a.UpdateWeights(LearnRate, Momentum)); //Ably the UpdateWeights() to output list which update the weight and bias for every output
		}

		public double[] Compute(params double[] inputs)//These function hold an array which contains inputs and applies the ForwardPropagate() function to it, Copies the elements of the List<> to a new array
		{
			ForwardPropagate(inputs);
			return OutputLayer.Select(a => a.Value).ToArray();
		}

		private double CalculateError(params double[] targets)//This function is to claculate the error by summing all the errors in each iteration
		{
			var i = 0;
			return OutputLayer.Sum(a => Mathf.Abs((float)a.CalculateError(targets[i++])));
		}

		public static double GetRandom() //this function is to get the random numbers that would be used for weight and bias
		{
			return 2 * Random.NextDouble() - 1; //NextDouble returns a random number that is greater than or equal to 0.0, and less than 1.0
		}
	}

	public enum TrainingType
	{
		Epoch,
		MinimumError
	}

}
