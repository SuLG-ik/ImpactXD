namespace Utils
{
    public interface INavigator
    {
        public void NavigateToMainMenu();

        public void NavigateToGame();

        public void Navigate(string scene);

        public void NavigateWin(int primogems, int mora);

        public void NavigateLose();
    }
}