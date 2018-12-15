using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Test_Click(object sender, RoutedEventArgs e)
        {
            MSBuildLocator.RegisterDefaults();
            var workspace = MSBuildWorkspace.Create();

            // TODO: Point to location of project here.
            string projectPath = @".......\TryingAnalyzerReferences\ConsoleApp\ConsoleApp.csproj";

            var project = await workspace.OpenProjectAsync(projectPath);
            var allLanguageAnalyzers = project.AnalyzerReferences.SelectMany(r => r.GetAnalyzersForAllLanguages());
            var languageSpecificAnalyzers = project.AnalyzerReferences.SelectMany(r => r.GetAnalyzers(project.Language));
        }
    }
}
