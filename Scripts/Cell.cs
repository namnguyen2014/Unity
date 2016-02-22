using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour {

	private AudioSource audio;
	private Button btnOnCell;
	private Sprite sprX;
	private Sprite sprO;
	private Image image;

	// Use this for initialization
	public void Init (Sprite x, Sprite o) {
		Button eventTrigger = gameObject.AddComponent<Button>();
		eventTrigger.onClick.AddListener(OnClick);
		image = GetComponent<Image>();

		sprX = x;
		sprO = o;
	}
	// OnClick function
	public void OnClick()
	{
		if(audio == null)
		{
			audio = GameObject.Find("soundClick").GetComponent<AudioSource>();
			audio.Play();

			image.sprite = sprX;
		}
	}
}
