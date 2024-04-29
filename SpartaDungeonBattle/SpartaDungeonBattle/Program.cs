using System.Security.Cryptography.X509Certificates;

namespace SpartaDungeonBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreationCharater creation = new CreationCharater();
            PlayerStatus status = new PlayerStatus();
            


            creation.Creation();
            status.Player(creation.name, creation.job, creation.jobNumber);
        }
    }
}
