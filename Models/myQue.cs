namespace Barbershop
{
    public class myQue
    {
        public static List<string> current = new List<string>();

        public static void add(string user)
        {
            current.Add(user);
        }

        public static void remove()
        {
            current.RemoveAt(0);
        }

    }
}