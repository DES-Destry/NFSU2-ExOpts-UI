using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NFSU2_ExOpts.Pages
{
    public partial class SplashScreenPage : Page
    {
        private readonly string text;
        private readonly string imagePath;

        private Page nextPage;
        private Action<Page> splashScreenClosed;

        private bool isAtScreen;

        public SplashScreenPage()
        {
            InitializeComponent();
        }

        public SplashScreenPage(string text, string imagePath)
        {
            InitializeComponent();

            this.text = text;
            this.imagePath = imagePath;
        }

        public void SetNextPageSettings(Page nextPage, Action<Page> splashScreenClosed)
        {
            this.nextPage = nextPage;
            this.splashScreenClosed = splashScreenClosed;
        }

        private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SplashScreenText.Text = text;
            SplashScreenImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            isAtScreen = true;
        }

        private void Grid_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            isAtScreen = false;
        }

        private void DoubleAnimationUsingKeyFrames_Completed(object sender, EventArgs e)
        {
            if (isAtScreen) splashScreenClosed?.Invoke(nextPage);
        }
    }
}
