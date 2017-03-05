using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomEffect : MonoBehaviour {
	public Sprite boomEffect1Sprite;
	public Sprite boomEffect2Sprite;
	public List<AudioClip> soundEffects;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		StartCoroutine(ShowBoomEffect());
		var clip = soundEffects[Random.Range(0, soundEffects.Count)];
		GetComponent<AudioSource>().clip = clip;
		GetComponent<AudioSource>().Play();
	}

	IEnumerator ShowBoomEffect() {
		GetComponent<Image>().sprite = boomEffect1Sprite;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Image>().sprite = boomEffect2Sprite;
		yield return new WaitForSeconds(0.1f);
		Destroy(gameObject);
	}
}
