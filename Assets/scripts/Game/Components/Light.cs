using UnityEngine;
using UnityEngine.UI;

public class Light : MonoBehaviour {

	[SerializeField]
	public int positionIndex;
	private PlayerColor? _cColor = null;
	public PlayerColor? cColor {
		get { return _cColor; }
		set {
			if (value == PlayerColor.Red) {
				GetComponent<Image>().sprite = redSprite;
			} else if (value == PlayerColor.Blue) {
				GetComponent<Image>().sprite = blueSprite;
			} else {
				GetComponent<Image>().sprite = defaultSprite;
			}
		}
	}
	[SerializeField]
	private Sprite defaultSprite;
	[SerializeField]
	private Sprite blueSprite;
	[SerializeField]
	private Sprite redSprite;
}
