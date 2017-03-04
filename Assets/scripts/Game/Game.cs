using UnityEngine;

public class Game : MonoBehaviour {

	private GameConfigurator cConfigurator = new GameConfigurator();

	[SerializeField]
	public ComponentContainer cContainer;
	[SerializeField]
	public PrefabContainer pPrefabContainer;

	public RockSpawner roRockSpawner;

	// Use this for initialization
	void Start () {
		cConfigurator.Setup(this);

		StartCoroutine(roRockSpawner.SpawnCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
