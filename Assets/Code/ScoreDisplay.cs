using UnityEngine;
using TMPro;

namespace Harjoituspeli
{
    public class ScoreDisplay : MonoBehaviour
    {
        public TextMeshProUGUI scoreText; // TextMeshPro-komponentti, johon näytetään pisteet
        public GameManager gameManager; // Viittaus GameManager-luokkaan, joka pitää kirjaa pelaajan pisteistä

        void Update()
        {
            // Päivitä pisteiden näyttö joka ruutupäivityksellä
            if (scoreText != null && gameManager != null)
            {
                // Päivitä teksti nykyisillä pisteillä
                scoreText.text = "Pisteet: " + gameManager.GetPoints().ToString();
            }
            else
            {
                Debug.LogWarning("ScoreText or GameManager reference is missing!");
            }
        }
    }
}
