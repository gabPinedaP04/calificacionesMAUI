namespace examen_calificaciones.Pages;

using System.ComponentModel;
using System.Windows.Input;

public partial class materia : ContentPage, INotifyPropertyChanged
{
	string titulo = "Materia";

    string rubro1 = "";
    string rubro2 = "";
    string rubro3 = "";

    string porcentaje1 = "";
    string porcentaje2 = "";
    string porcentaje3 = "";

    string calif1 = "";
    string calif2 = "";
    string calif3 = "";



    public materia()
	{
		InitializeComponent();
        this.BindingContext = this;
    }

	public string Titulo
	{
		get => titulo;
		set 
		{
            if (titulo != value)
            {
                titulo = value;
                // Notifica que la propiedad Titulo ha cambiado
                OnPropertyChanged(nameof(Titulo));
            }
        }
	}

    public string Rubro1
    {
        get => rubro1; 
        set
        {
            if(rubro1!= value)
            {
                rubro1 = value;
                OnPropertyChanged(nameof(Rubro1));

            }
        }
    }

    public string Rubro2
    {
        get => rubro2;
        set
        {
            if (rubro2 != value)
            {
                rubro2 = value;
                OnPropertyChanged(nameof(Rubro2));

            }
        }
    }

    public string Rubro3
    {
        get => rubro3;
        set
        {
            if (rubro3 != value)
            {
                rubro3 = value;
                OnPropertyChanged(nameof(Rubro3));

            }
        }
    }




    private void btnAnadir_Clicked(object sender, EventArgs e)
    {
        notnullverify();
    }

    public void cambiarACalif()
    {
        verticalIngresarRubros.IsVisible= false;
        verticalIngresarCalif.IsVisible= true;
        btnAceptar2.IsVisible= true;
        btnAceptar1.IsVisible = false;
        btnCalcular.IsVisible= true;
    }

    public void notnullverify()
    {
        if (!string.IsNullOrEmpty(entrtMateria.Text) &&
        !string.IsNullOrEmpty(entryRubro1.Text) &&
        !string.IsNullOrEmpty(entryRubro2.Text) &&
        !string.IsNullOrEmpty(entryRubro3.Text))
        {
            Titulo = entrtMateria.Text;
            Rubro1= entryRubro1.Text;
            Rubro2= entryRubro2.Text; 
            Rubro3 = entryRubro3.Text;
            cambiarACalif();
        }
        else
        {
            return;
        }
    }

    private void btnAceptar2_Clicked(object sender, EventArgs e)
    {

    }

    private void btnAceptar3_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        CalcularCalificacionFinal();
    }

    public void verificarYTomarPorcentajesYCalif()
    {
        bool porcentaje1Valido = !string.IsNullOrEmpty(entryPorcentaje.Text);
        bool calif1Valido = !string.IsNullOrEmpty(entryCalif1.Text);

        bool porcentaje2Valido = !string.IsNullOrEmpty(entryExamen.Text);
        bool calif2Valido = !string.IsNullOrEmpty(entryCalif2.Text);

        bool porcentaje3Valido = !string.IsNullOrEmpty(entryTareas.Text);
        bool calif3Valido = !string.IsNullOrEmpty(entryCalif3.Text);


        if (porcentaje1Valido && calif1Valido && porcentaje2Valido && calif2Valido && porcentaje3Valido && calif3Valido)
        {
            string calif1 = entryCalif1.Text;
            string calif2 = entryCalif2.Text;
            string calif3 = entryCalif3.Text;
        }
        else
        {
            
        }
    }

    public void CalcularCalificacionFinal()
    {
        // Intenta convertir las entradas de texto a decimales
        if (decimal.TryParse(entryPorcentaje.Text, out decimal porcentaje1) &&
            decimal.TryParse(entryCalif1.Text, out decimal calificacion1) &&
            decimal.TryParse(entryExamen.Text, out decimal porcentaje2) &&
            decimal.TryParse(entryCalif2.Text, out decimal calificacion2) &&
            decimal.TryParse(entryTareas.Text, out decimal porcentaje3) &&
            decimal.TryParse(entryCalif3.Text, out decimal calificacion3))
        {
            // Convertir los porcentajes a formato decimal
            porcentaje1 /= 100;
            porcentaje2 /= 100;
            porcentaje3 /= 100;

            // Calcular la calificación final
            decimal calificacionFinal = (calificacion1 * porcentaje1) + (calificacion2 * porcentaje2) + (calificacion3 * porcentaje3);

            // Establecer el texto del Label con la calificación final
            calificacionFinalLabel.Text = $"Calificación final {titulo}  : {calificacionFinal}";
        }
        else
        {
            // Mostrar mensaje de error si no se pudieron convertir las entradas a números decimales
            calificacionFinalLabel.Text = "Por favor, ingrese calificaciones y porcentajes válidos.";
        }
    }





}