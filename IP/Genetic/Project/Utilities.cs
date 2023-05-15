namespace Project;

static class Utilities
{
    static Random random = new Random();

    public static List<T> ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }    
}