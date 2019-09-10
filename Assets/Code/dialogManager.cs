using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogManager : MonoBehaviour
{
	private Queue<string> sentences;
	public Text nameText;
	public Text dailogText;
	public Animator animator;
	public Animator animator2;
	GameObject button;
    void Start()
    {
        sentences = new Queue<string>();		
    }
	public void StartDialog(dialog dialogg)
	{
		animator.SetBool("isOpen",true);
		animator2.SetBool("isOpen2",false);
		nameText.text=dialogg.name;
		sentences.Clear();
		foreach(string sentence in dialogg.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	
	public void DisplayNextSentence() 
	{
		if(sentences.Count==0)
		{
			EndDialog();
			return;
		}
		string sentence=sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}
	
	IEnumerator TypeSentence (string sentence)
	{
		dailogText.text= "";
		foreach( char letter in sentence.ToCharArray())
		{
			dailogText.text +=letter;
			yield return null;
		}
	}
	
	void EndDialog()
	{
		animator.SetBool("isOpen",false);
		animator2.SetBool("isOpen2",true);
		button = GameObject.Find ("Button");
		button.SetActive(false); 
	}
	

}
