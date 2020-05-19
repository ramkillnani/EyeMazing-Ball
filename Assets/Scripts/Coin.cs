using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
	private float speed = 50.0f; //speed of the rotation
	[SerializeField]
	private GameObject selectedCoin;

	public static float coins = 0f;
	public static float coinslvl2 = 0f;
	public GameObject[] coinParent;
	public Text coinText;
	public PlayerController playerController;

	private void Start()
	{
		// Checks if the game is on the first level, and sets the coin count back to 0 if the player died. (coin float is static)
		if (SceneManager.GetActiveScene().name == "Level1")
		{
			coins = 0f;
		}

		if (SceneManager.GetActiveScene().name == "Level2")
		{
			coins = coinslvl2;
		}
		// Sets the text to show the count count
		coinText.text = "Coins: " + coins.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		foreach (GameObject coinGO in coinParent)
		{
			coinGO.transform.Rotate(Vector3.left * speed * Time.deltaTime); //rotates the object towards the left by speed and real time
		}
	}

	public void CoinCollision()
	{
		selectedCoin = GameObject.Find("/PickUps/" + playerController.coinName);
		// Makes coin disappear
		selectedCoin.gameObject.SetActive(false);
		// Adds to the coin float
		coins++;
		// Sets text
		coinText.text = "Coins: " + coins.ToString();
	}
}
