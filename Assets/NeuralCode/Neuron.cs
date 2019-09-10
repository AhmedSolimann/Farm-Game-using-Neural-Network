using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
	public class Neuron 
	{
		public List<Synapse> InputSynapses { get; set; } //List that holds inputs value such as weight and value
		public List<Synapse> OutputSynapses { get; set; } //List that holds output value such as weight and value
		public double Bias { get; set; }
		public double BiasDelta { get; set; }
		public double Gradient { get; set; }
		public double Value { get; set; }

		public Neuron()
			{
				InputSynapses = new List<Synapse>(); //create an object from the input list
				OutputSynapses = new List<Synapse>(); //create an object from the output list
				Bias = NeuralNet.GetRandom(); //This value is randomized for every neuorn
			}

			public Neuron(IEnumerable<Neuron> inputNeurons) : this()
			{
				foreach (var inputNeuron in inputNeurons)
				{
					var synapse = new Synapse(inputNeuron, this);
					inputNeuron.OutputSynapses.Add(synapse);
					InputSynapses.Add(synapse);
				}
			}

			public virtual double CalculateValue() //This function is used in forward propogation process.
			{
				return Value = Sigmoid.Output(InputSynapses.Sum(a => a.Weight * a.InputNeuron.Value) + Bias); //Calculate by ably activation function to (weight*input)+bias 
			}

			public double CalculateError(double target)
			{
				return target - Value; //Calculate accuracy for every iteration
			}

			public double CalculateGradient(double? target = null) //This function is used in back propagation and uses many techniques such as direvative of sigmoid function
			{
				if(target == null)
					return Gradient = OutputSynapses.Sum(a => a.OutputNeuron.Gradient * a.Weight) * Sigmoid.Derivative(Value);//Calculate the error for each neuron in hidden layer

				return Gradient = CalculateError(target.Value) * Sigmoid.Derivative(Value); //Calculate the error in the output layer
			}

			public void UpdateWeights(double learnRate, double momentum)//Update the weights and bias
			{
				var prevDelta = BiasDelta; //update bias for all neuorns
				BiasDelta = learnRate * Gradient;
				Bias += BiasDelta + momentum * prevDelta;//update the bias by multiply it with the predefiend learnRate until it reaches to the perfect value

				foreach (var synapse in InputSynapses) //update weight for each neuorns
				{
					prevDelta = synapse.WeightDelta;//update the weight by multiply it with the predefiend learnRate and gradient until it reaches to the perfect value
					synapse.WeightDelta = learnRate * Gradient * synapse.InputNeuron.Value;
					synapse.Weight += synapse.WeightDelta + momentum * prevDelta;
				}
			}

	}



	public static class Sigmoid //This is an activation function to calculate the predicted output
	{
		public static double Output(double x)
		{
			//return x < -45.0 ? 0.0 : x > 45.0 ? 1.0 : 1.0 / (1.0 + Mathf.Exp((float)-x));
			return 1.0f / (1.0f +  Mathf.Exp((float)-x));
		}

		public static double Derivative(double x) //Calculate the direvative to the equation
		{
			return x * (1 - x);
		}
	}

	public class Synapse
	{
		public Neuron InputNeuron { get; set; }
		public Neuron OutputNeuron { get; set; }
		public double Weight { get; set; }
		public double WeightDelta { get; set; }

		public Synapse(Neuron inputNeuron, Neuron outputNeuron)
		{
			InputNeuron = inputNeuron;
			OutputNeuron = outputNeuron;
			Weight = NeuralNet.GetRandom();
		}
	}
	
	public class DataSet //this class hold two array that holds inputs:values and output:targets
	{
		public double[] Values { get; set; }
		public double[] Targets { get; set; }

		public DataSet(double[] values, double[] targets)
		{
			Values = values;
			Targets = targets;
		}
	}

}
