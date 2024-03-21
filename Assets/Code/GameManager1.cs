using UnityEngine;

namespace Harjoituspeli
{
	public static class GameManager
	{

		
		public static event System.Action<int> ScoreChanged;
		private static int _score = 0;

		public static int Score
		{
			get => _score;
			set
			{
				_score = Mathf.Clamp(value, 0, int.MaxValue);
				PlayerPrefs.SetInt("Score", _score); // Save the score when it's changed
                PlayerPrefs.Save(); // Save PlayerPrefs to disk

				if (ScoreChanged != null)
				{
					ScoreChanged(_score);
				}
			}
		}

		// Staattinen rakentaja. Kutsutaan automaattisesti ennen,
		// kun luokkaa (tai staattista tyyppiä) käytetään ensimmäistä kertaa.
		// Staattinen rakentaja suoritetaan maksimissaan kerran pelin suorituksen aikana.
		static GameManager()
		{
			LoadScore(); // Load the score when the GameManager is initialized
		}
		private static void LoadScore()
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                _score = PlayerPrefs.GetInt("Score"); // Load the score from PlayerPrefs
            }
            else
            {
                Reset(); // If the score is not found in PlayerPrefs, reset it
            }
        }

		public static void Reset()
		{
			Score = 0;
		}
	}
}
