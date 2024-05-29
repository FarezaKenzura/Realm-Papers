using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PaperRealm.Type.Fitur
{
    public class Testing : MonoBehaviour
    {
        private void Start() {
            int[] deck = { 1, 2, 3, 4, 5 };
            Shuffle(deck);
            Debug.Log("Shuffled Deck: " + string.Join(", ", deck));

            Shuffler shuffler = new Shuffler();
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            List<int> shuffledWithOrderBy = shuffler.ShuffleListWithOrderBy(numbers);
            Debug.Log("Shuffled with OrderBy: " + string.Join(", ", shuffledWithOrderBy));

            List<int> shuffledWithFisherYates = shuffler.ShuffleListFisherYates(new List<int>(numbers));
            Debug.Log("Shuffled with Fisher-Yates: " + string.Join(", ", shuffledWithFisherYates));
        }

        void Shuffle(int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                int tmp = deck[i];
                int randomIndex = Random.Range(i, deck.Length);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = tmp;
            }
        }
    }
}
