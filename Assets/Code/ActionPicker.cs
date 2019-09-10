using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NeuralNetwork;
using UnityEngine.UI;
using System.IO;

public class ActionPicker : MonoBehaviour {
	
	
	
	public Transform Soil1;
	public Transform Soil2;
	
	public Transform Seed1;
	public Transform Seed2;

	public GameObject pointer1;
	public GameObject pointer2;
	public GameObject logo;
	
	public GameObject NextLevel;
	
	public Sprite[] randomCrop;
	public Sprite[] randomSoil;
	
	private float width = 1.5f;
	private float height= 1.5f;

	public AudioClip clickEffect1;
	public AudioClip clickEffect2;
	public AudioClip Reset;
	public AudioClip WellDone;
	
	
	//Neural Network Variables
	private const double MinimumError = 0.1;
	private const TrainingType TrType = TrainingType.MinimumError;
	private static NeuralNet net;
	private static List<DataSet> dataSets; 
	bool trained;
	int i = 0;
	int x;
	int y;
	int a;
	int b;
	//List<string> collectedTrainingData = new List<string>();
	//StreamWriter tdf;
	
	void Start () 
	{
		//4 Input (type of crop 1, type of crop 2,type of soil 1,type of soil 2), 5(neurons), 1 Output  (0/1, left/right)
		net = new NeuralNet(4, 5, 1);
		dataSets = new List<DataSet>();
		Next();
		/* string path = Application.dataPath + "/trainingData.txt";
    	tdf = File.CreateText(path); */
	}
	
	/* void OnApplicationQuit()
    {
    	foreach(string td in collectedTrainingData)
        {
        	tdf.WriteLine(td);
        }
        tdf.Close();
    } */

	
	void Next()
	{
		x = Random.Range (0, randomCrop.Length); //Input 1 (crop 1 value)
		y = Random.Range (0, randomCrop.Length); //Input 2 (crop 2 value)
		if(x==y)
		{
			x = Random.Range (0, 3); //Input 1 (crop 1 value)
			y = Random.Range (3, 5);
			Seed1.GetComponent<SpriteRenderer> ().sprite =randomCrop [x]; //Ablly the random value to the sprite image
			Seed2.GetComponent<SpriteRenderer> ().sprite = randomCrop [y]; //Ablly the random value to the sprite image
			Vector3 scale = new Vector3 (width, height, 0f);
			Seed1.transform.localScale = scale;
			Seed2.transform.localScale = scale;
			a = Random.Range (0, randomSoil.Length); //Input 3 (soil 1 value)
			b = Random.Range (0, randomSoil.Length); //Input 4 (soil 2 value)
			Soil1.GetComponent<SpriteRenderer> ().sprite =randomSoil [a]; //Ablly the random value to the sprite image
			Soil2.GetComponent<SpriteRenderer> ().sprite = randomSoil [b]; //Ablly the random value to the sprite image
			
		}
		else{
			Seed1.GetComponent<SpriteRenderer> ().sprite =randomCrop [x]; //Ablly the random value to the sprite image
			Seed2.GetComponent<SpriteRenderer> ().sprite = randomCrop [y]; //Ablly the random value to the sprite image
			Vector3 scale = new Vector3 (width, height, 0f);
			Seed1.transform.localScale = scale;
			Seed2.transform.localScale = scale;
			a = Random.Range (0, randomSoil.Length); //Input 3 (soil 1 value)
			b = Random.Range (0, randomSoil.Length); //Input 4 (soil 2 value)
			Soil1.GetComponent<SpriteRenderer> ().sprite =randomSoil [a]; //Ablly the random value to the sprite image
			Soil2.GetComponent<SpriteRenderer> ().sprite = randomSoil [b]; //Ablly the random value to the sprite image
			
		}
		double[] C = {(double)x, (double)y,(double)a, (double)b}; //array that holds 4 inputs
		if(trained)
		{
			double d = tryValues(C);
			if(d > 0.5)
			{
				pointer1.SetActive(false);
				pointer2.SetActive(true);
				NextLevel.SetActive(true);
			}
			else
			{
				pointer1.SetActive(true);
				pointer2.SetActive(false);
				NextLevel.SetActive(true);
			}
			logo.SetActive(true);
		}
		
	}

	public void Train(float val)
	{ 
		double[] C = {(double)x, (double)y, (double)a, (double)b}; //Array that holds inputs and output
		double[] v = {(double)val}; //Array that holds the outputs
		dataSets.Add(new DataSet(C, v)); //Add the array elements to the dataset list

		i++;
		if(!trained && i==10) //After 10 itteration of training, the prediction would initiate
		{
			AudioManager.instance.RandomizeSfx (WellDone);
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
	
	void Update () {
		if (Input.GetKeyDown ("right")) //When hitting the right arrow, it would train the 0 output
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			Train(0);
			
			/* string td = x + "," + y + "," + a + "," + b + "," + 0;   
				if(!collectedTrainingData.Contains(td))
				{
					collectedTrainingData.Add(td);
				} */
				
		}
		if (Input.GetKeyDown ("left")) //When hitting the left arrow, it would train the 1 output
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			Train(1);
			
			/* string td = x + "," + y + "," + a + "," + b + "," + 1;   
				if(!collectedTrainingData.Contains(td))
				{
					collectedTrainingData.Add(td);
				} */
		}
		
		if (Input.GetKeyDown ("space")) //When hitting space bar, it would randomize the values and sprites for crops and soils
		{
			AudioManager.instance.RandomizeSfx (Reset);
			Next();
		}
		
	}
	


}
