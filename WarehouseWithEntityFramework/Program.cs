using WarehouseWithEntityFramework.Menu;

namespace WarehouseWithEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositoryOption = MainMenu.ShowMenu();
            MainMenu.MainMenuOptions(repositoryOption);
        }
    }
}
