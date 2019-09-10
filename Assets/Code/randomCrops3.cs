using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeuralNetwork;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class randomCrops3 : MonoBehaviour
{
    
	public Sprite[] randomCrop;
	private float width = 2.5f;
	private float height=2.5f;
	public static string currentTool="none";
	public Transform curserObj;

	public Transform crop1;
	public Transform crop2;
	public Transform crop3;

	public GameObject result1;
	public GameObject result2;
	
	public GameObject NextLevel;
	
	public AudioClip clickEffect1;
	public AudioClip clickEffect2;

	
	//Neural Network Variables
	private const double MinimumError = 0.1;
	private const TrainingType TrType = TrainingType.MinimumError;
	private static NeuralNet net;
	private static List<DataSet> dataSets; 
	bool trained;
	int i = 0;
	int x;
	int y;
	int z;
	int a;
	
	// Use this for initialization
	void Start ()
	{
		//Input - 4  -5(neurons)- Output - 1 (0/1, left/right)
		net = new NeuralNet(4, 5, 1);
		dataSets = new List<DataSet>();
		randoCrop();
	}
	
	public void randoCrop()
	{
		x = Random.Range (0, 3);
		y = Random.Range (3, 6);
		z = Random.Range (6, 9);
		crop1.GetComponent<SpriteRenderer> ().sprite = randomCrop [x];
		crop2.GetComponent<SpriteRenderer> ().sprite = randomCrop [y];
		crop3.GetComponent<SpriteRenderer> ().sprite = randomCrop [z];
		Vector3 scale = new Vector3 (width, height, 0f);
		crop1.transform.localScale = scale;
		crop2.transform.localScale = scale;
		crop3.transform.localScale = scale;

		
	}
	

	
	public void selectAction()
	{
		if (EventSystem.current.currentSelectedGameObject.name=="water")
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			a=1;
			Train(0);			
		}

		if (EventSystem.current.currentSelectedGameObject.name == "moreWater")
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			//GameObject.Find("curser1").GetComponent<RectTransform>().position=GameObject.Find("moreWater").GetComponent<RectTransform>().position;
			a=2;
			Train(0);
		}

		if (EventSystem.current.currentSelectedGameObject.name=="scythe")
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			a=3;
			Train(1);
		}

		if (EventSystem.current.currentSelectedGameObject.name=="wait")
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			a=4;
			Train(0);
		}
		GameObject.Find("curser1").GetComponent<RectTransform>().position=EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>().position;
	}

	public void triggerButton()
	{
		Debug.Log ("X value is: "+x);
		Debug.Log ("a value is: "+a);
		double[] C = {(double)x, (double)y, (double)z, (double)a};
		if(trained)
		{
			double d = tryValues(C);
			if(d > 0.5)
			{
				result1.SetActive(false);
				result2.SetActive(true);
				NextLevel.SetActive(true);
			}
			else
			{
				result1.SetActive(true);
				result2.SetActive(false);
				NextLevel.SetActive(true);
			}

		}	
	}
	
	public void triggerButton2()
	{
		AudioManager.instance.RandomizeSfx (clickEffect2);
		randoCrop();
	}
	
	public void Train(float val)
	{ 
		double[] C = {(double)x, (double)y, (double)z, (double)a};
		double[] v = {(double)val};
		dataSets.Add(new DataSet(C, v));

		i++;
		if(!trained && i==10)
			Train();

		triggerButton();

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
	
	// Update is called once per frame
	void Update () 
	{
	

	}
	

}
