using RegistroEstudiantesMVVM.ViewModels;

namespace RegistroEstudiantesMVVM.Views;

public partial class RegistroPage : ContentPage
{
    public RegistroPage(RegistroViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
