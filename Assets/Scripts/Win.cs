using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	[SerializeField] // Shows private in inspector
	private Text coinText;

	void Start()
	{
		// Sets text to the static float coin
		coinText.text = "Coins collected: " + Coin.coins.ToString();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("Level1");
	}
}
