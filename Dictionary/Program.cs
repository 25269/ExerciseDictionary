namespace DictionaryExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string, int> election = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);

                        //Voter voter = new Voter { Name = name, NumberOfVotes = votes };

                        if (!election.ContainsKey(name))
                        {
                            election.Add(name, votes);
                        }
                        else
                        {
                            election[name] += votes;
                        }
                    }
                }

                Console.WriteLine();
                foreach (KeyValuePair<string, int> pair in election)
                {
                    Console.WriteLine(pair.Key + " - " + pair.Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
