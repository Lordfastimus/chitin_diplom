using Chitin.ViewModels;
using System.Windows.Controls;

namespace Chitin.Views
{
    public partial class ComparationView : UserControl
    {
        public ComparationView()
        {
            InitializeComponent();
            DataContext = new ComparationViewModel();
        }
    }
}
