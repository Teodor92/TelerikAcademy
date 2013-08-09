namespace PermutationsWithRepetitions
{
    using System;

    public class Program
    {
        public static void Permute(int[] elemtSet, int permutationStart, int elementsToPermute)
        {
            int oldValue = 0;
            Console.WriteLine(string.Join(" ", elemtSet));

            if (permutationStart < elementsToPermute)
            {
                for (int i = elementsToPermute - 2; i >= permutationStart; i--)
                {
                    for (int j = i + 1; j < elementsToPermute; j++)
                    {
                        if (elemtSet[i] != elemtSet[j])
                        {
                            oldValue = elemtSet[i];
                            elemtSet[i] = elemtSet[j];
                            elemtSet[j] = oldValue;

                            Permute(elemtSet, i + 1, elementsToPermute);
                        }
                    }

                    oldValue = elemtSet[i];
                    for (int k = i; k < elementsToPermute - 1;)
                    {
                        elemtSet[k] = elemtSet[++k];
                    }

                    elemtSet[elementsToPermute - 1] = oldValue;
                }
            }
        }

        public static void Main()
        {
            int[] set = { 1, 3, 5, 5 };
            Permute(set, 0, set.Length);
        }
    }
}
