using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PaperRealm.Type.Fitur
{
    public class Shuffler
    {
        // System.Random instance to ensure better randomness and flexibility
        private System.Random random = new System.Random();

        // Constructor
        public Shuffler()
        {
        }

        // Shuffles the list using OrderBy and a random key
        public List<int> ShuffleListWithOrderBy(List<int> list)
        {
            // OrderBy each element with a random key generated by System.Random
            return list.OrderBy(x => random.Next()).ToList();
        }

        // Shuffles the list using the Fisher-Yates algorithm
        public List<int> ShuffleListFisherYates(List<int> list)
        {
            int n = list.Count;
            // Iterate over the list from the end to the beginning
            for (int i = n - 1; i > 0; i--)
            {
                // Select a random index j such that 0 <= j <= i
                int j = random.Next(i + 1);
                // Swap the elements at indices i and j
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
            return list;
        }
    }
}