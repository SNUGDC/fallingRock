using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger {
	public static void ChangeToScene(string sceneName)
	{
		var audioSource = GameObject.FindObjectOfType(typeof(AudioSource)) as AudioSource;
		if (audioSource == null) {
			SceneManager.LoadScene(sceneName);
		} else {
			GameObject go = new GameObject();
			go.AddComponent<EmptyMonobehaviour>();
			go.GetComponent<EmptyMonobehaviour>().StartCoroutine(AudioFadeOut.FadeOut(audioSource, 1.0f, () => {
				SceneManager.LoadScene(sceneName);
			}));
		}
	}

}
