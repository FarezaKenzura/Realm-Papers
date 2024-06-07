using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PaperRealm.Type.Fitur
{
    public class Testing : MonoBehaviour
    {
        private void Start() {
            Shuffler shuffler = new Shuffler();
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            List<int> shuffledWithOrderBy = shuffler.ShuffleListWithOrderBy(numbers);
            Debug.Log("Shuffled with OrderBy: " + string.Join(", ", shuffledWithOrderBy));
        }
    }
}
