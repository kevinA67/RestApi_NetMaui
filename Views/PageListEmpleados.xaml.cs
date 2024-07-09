namespace PM022024RestApi.Views;

public partial class PageListEmpleados : ContentPage
{
	public PageListEmpleados()
	{
		InitializeComponent();
	}
	private async void btntest_Clicked(object sender, EventArgs e)
	{
		List<Models.Empleados> EmpleadosList =new List<Models.Empleados> ();
		EmpleadosList =await Controllers.EmpleadosController.GetEmpleados();
	}

    private void ListEmpleado_SelectionChanged(object sender, EventArgs e)
    {
        
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Models.Empleados> EmpleadosList = new List<Models.Empleados>();
        EmpleadosList = await Controllers.EmpleadosController.GetEmpleados();
		ListEmpleados.ItemsSource= EmpleadosList;
    }
}