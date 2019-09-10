using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTriger : MonoBehaviour
{
	public dialog dialogg;
	
	
	public void TriggerDialog()
	{
		FindObjectOfType<dialogManager>().StartDialog(dialogg);
	}
	

}
