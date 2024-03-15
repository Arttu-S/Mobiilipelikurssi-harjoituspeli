using UnityEngine;
using TMPro;

namespace Harjoituspeli
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText; // TextMeshPro-komponentti, johon näytetään pisteet
        public GameManager gameManager; // Viittaus GameManager-luokkaan, joka pitää kirjaa pelaajan pisteistä

        void UpdateScore()
        {
            scoreText.text = "Pisteet: " + gameManager.GetPoints(); // Päivitetään pisteet
        }
    }
}
