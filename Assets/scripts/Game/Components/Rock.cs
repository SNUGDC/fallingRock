using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public interface RockOutput {
    void OnBoom(Rock target);
	void OnCollideToGround(Rock collisionRock);
}

public class Rock : MonoBehaviour {
	[SerializeField]
	public PlayerColor color;
	public SpawnPoint sSpawnPoint;
	public RockOutput output;
	[SerializeField]
	public BoomEffect boomEffect;

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		var rectTransform = GetComponent<RectTransform>();
		if (rectTransform.anchoredPosition.y < -930) {
			output.OnCollideToGround(this);	
		}
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		var speed = Configurations.Instance.rockDownSpeed;
		var rectTransform = GetComponent<RectTransform>();
		rectTransform.anchoredPosition -= new Vector2(0, Time.fixedDeltaTime * speed);
	}

    internal void Boom()
    {
		output.OnBoom(this);

		boomEffect = Instantiate(boomEffect) as BoomEffect;
		boomEffect.transform.SetParent(sSpawnPoint.transform, false);
		boomEffect.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

		Destroy(gameObject);
    }
}
