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

	private int _hp = 1;
	private int hp {
		get {
			return _hp;
		}
		set {
			_hp = value;
			var rectTransform = GetComponent<RectTransform>();
			var size = 140;
			if (value == 3) {
				size = 250;
			} else if (value == 2) {
				size = 200;
			} else {
				size = 140;
			}
			var prevRect = rectTransform.rect;
			rectTransform.sizeDelta = new Vector2(size, size);
		}
	}

	void Start() {
		if (Random.Range(0f, 1.0f) < 0.1666f) {
			hp = 3;
		} else {
			hp = 1;
		}
	}

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
		if (hp > 1) {
			hp -= 1;
			return;
		}

		output.OnBoom(this);
		boomEffect = Instantiate(boomEffect) as BoomEffect;
		boomEffect.transform.SetParent(sSpawnPoint.transform, false);
		boomEffect.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

		Destroy(gameObject);
    }
}
