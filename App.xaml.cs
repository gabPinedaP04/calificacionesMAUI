using examen_calificaciones.Pages;

namespace examen_calificaciones;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new Inicio();
	}
}
