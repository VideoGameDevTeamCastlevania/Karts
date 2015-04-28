using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour {
	Sprite targetSprite;
	Image mapImage;

	// Use this for initialization
	void Start () {
		mapImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//  Functions to update map Sprites, fairly simple. 
	public void onClickMap1() {
		targetSprite = Resources.Load ("DesertTrack", typeof(Sprite)) as Sprite;
		mapImage.sprite = targetSprite;
	}

	public void onClickMap2() {
		targetSprite = Resources.Load ("MountainTrack", typeof(Sprite)) as Sprite;
		mapImage.sprite = targetSprite;
	}

	public void onClickMap3()  {
		targetSprite = Resources.Load ("Rolling Hills 1", typeof(Sprite)) as Sprite;
		mapImage.sprite = targetSprite;
	}

	public void onClickMap4() {
		targetSprite = Resources.Load ("Rolling Hills 2", typeof(Sprite)) as Sprite;
		mapImage.sprite = targetSprite;
	}

}
