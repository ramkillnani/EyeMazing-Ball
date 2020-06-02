using UnityEngine;
using UnityEngine.SceneManagement; //for switches scenes

public class LevelControl : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) //if an object with the tag 'player' collides 
		{
            if(SceneManager.GetActiveScene().name == "Level0")
            {
                Coin.coinslvl1 = Coin.coins;
                SceneManager.LoadScene("Level1");
            }


			if (SceneManager.GetActiveScene().name == "Level1")
			{
				// Load the said scene
				Coin.coinslvl2 = Coin.coins;
				SceneManager.LoadScene("Level2"); 
			}
			if (SceneManager.GetActiveScene().name == "Level2")
			{
				// Load the said scene
				SceneManager.LoadScene("Win"); 
			}
		}
	}
}
