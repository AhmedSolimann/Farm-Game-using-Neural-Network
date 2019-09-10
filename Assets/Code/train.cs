using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeuralNetwork;
using System.IO;

public class train : MonoBehaviour
{
	private const double MinimumError = 0.1;
	private const TrainingType TrType = TrainingType.MinimumError;
	private static NeuralNet net;
	private static List<DataSet> dataSets; 
	double x;
    double y;
    double a;
    double b;
    double d;
	bool trained;
	public GameObject pointer1;
	public GameObject pointer2;
	public GameObject logo;
	
    // Start is called before the first frame update
    void Start()
    {
		net = new NeuralNet(4, 5, 1);
		dataSets = new List<DataSet>();
		Next();
	}
	
	void Next()
    {

        string path = Application.dataPath + "/trainingData.txt";
        string line;
        if(File.Exists(path))
        {
            int lineCount = File.ReadAllLines(path).Length;
            StreamReader tdf = File.OpenText(path);

            for(int i = 0; i < 301; i++)
            { 
                //set file pointer to beginning of file             
                tdf.BaseStream.Position = 0;
                while((line = tdf.ReadLine()) != null)  
                {  
                    string[] data = line.Split(',');
                    
                        x=System.Convert.ToDouble(data[0]);
                        y=System.Convert.ToDouble(data[1]);
                        a=System.Convert.ToDouble(data[2]);
                        b=System.Convert.ToDouble(data[3]);
                        d=System.Convert.ToDouble(data[4]);
						
                }
                 
            } 
            double[] C = {(double)x, (double)y,(double)a, (double)b, (double)d};
			double[] v = {(double)d};     
			if(trained)
			{
				double d = tryValues(C);
				if(d > 0.5)
				{
					pointer1.SetActive(false);
					pointer2.SetActive(true);

				}
				else
				{
					pointer1.SetActive(true);
					pointer2.SetActive(false);

				}
			}
        }      
    }
        

    public void Train(float val)
	{ 
		double[] C = {(double)x, (double)y,(double)a, (double)b, (double)d}; //Array that holds inputs and output
		double[] v = {(double)d}; 
		dataSets.Add(new DataSet(C,v)); //Add the array elements to the dataset list

		if(!trained ) //After 10 itteration of training, the prediction would initiate
		{
			Train();
		}
		 Next();
	}
	
	
	private void Train()
	{
		net.Train(dataSets, MinimumError);
		trained = true;
	}
	
	double tryValues(double[] vals)
	{
	 	double[] result = net.Compute(vals);
	 	return result[0];
	}

}
