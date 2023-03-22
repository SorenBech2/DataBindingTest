namespace DataBindingTest;

public partial class View : ContentPage
{
	public View(ViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

