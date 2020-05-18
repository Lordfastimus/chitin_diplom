using Chitin.ViewModels;
using System.Windows.Controls;

namespace Chitin.Views
{
    /// <summary>
    /// Interaction logic for AnalizeStep.xaml
    /// </summary>
    public partial class AnalizeStep : UserControl
    {
        public AnalizeStep()
        {            
            InitializeComponent();
            DataContext = new AnalizeStepViewModel();
        }
    }
}
