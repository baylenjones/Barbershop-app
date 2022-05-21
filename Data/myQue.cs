namespace Barbershop.Data
{
    public class myQue
    {
        public static List<string> current = new List<string>();

        public static void addUser(string user)
        {
            myQue.current.Add(user);
        }

        public static void rmUser()
        {
            if (current.Count == 0)
            {
                return;
            }
            myQue.current.RemoveAt(0);
        }
    }
}