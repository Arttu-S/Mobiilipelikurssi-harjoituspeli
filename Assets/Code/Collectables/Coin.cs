using UnityEngine;

namespace Harjoituspeli {
public class Coin : MonoBehaviour
{


		[SerializeField] private int _score = 1;

		public int Score => _score;

    // Pisteiden arvo kolikolle
    [SerializeField] private int points;

    // Metodi asettaa kolikon pisteet
    public void SetPoints(int value)
    {
        points = value;
    }

    

    // Metodi palauttaa kolikon pisteet
    public int GetPoints()
    {
        return points;
    }

    // Esimerkkimetodi kolikon keräämiselle
    public void Collect()
    {
        // Tässä voit toteuttaa mitä tapahtuu, kun kolikko kerätään
        Debug.Log("Kolikko kerätty! Pisteet: " + points);
        // Voit lisätä tässä esimerkiksi pisteiden lisäämisen pelaajan pisteisiin
    }
}
}