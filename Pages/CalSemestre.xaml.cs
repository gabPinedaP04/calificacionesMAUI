namespace examen_calificaciones.Pages;

using System;
using System.ComponentModel;
using Microsoft.Maui.Controls;


public partial class CalSemestre : ContentPage, INotifyPropertyChanged
{
    string titulo = "Materia";
    string calif1 = "";
    string calif2 = "";
    string valor1 = "";
    string valor2 = "";

    string califMostrar = "Pruebaaa";


    public CalSemestre()
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
                OnPropertyChanged(nameof(Titulo));
            }
        }
    }

    public string Calif1
    {
        get => calif1;
        set
        {
            if (calif1 != value)
            {
                calif1 = value;
                OnPropertyChanged(nameof(Calif1));
            }
        }
    }

    public string Calif2
    {
        get => calif2;
        set
        {
            if (calif2 != value)
            {
                calif2 = value;
                OnPropertyChanged(nameof(Calif2));
            }
        }
    }

    public string Calificacion
    {
        get => califMostrar;
        set
        {
            califMostrar = value;
            OnPropertyChanged();
        }
    }

        

        private void BtnAnadir_Clicked(object sender, EventArgs e)
        {
            NotNullVerify();
        }

        

        public void NotNullVerify()
        {
            if (!string.IsNullOrEmpty(entrySemestre.Text))
            {
                Titulo = entrySemestre.Text;
            }
            else
            {
                return;
            }
        }

        private void BtnAceptar2_Clicked(object sender, EventArgs e)
        {
            // Implementar la lógica cuando el botón "Aceptar2" es clickeado
        }

        public void VerificarYTomarValores()
        {
        bool valor1Valido = !string.IsNullOrEmpty(entryValor1.Text);
        bool valor2Valido = !string.IsNullOrEmpty(entryValor2.Text);
        bool calif1Valido = !string.IsNullOrEmpty(entryCalif1.Text);
        bool calif2Valido = !string.IsNullOrEmpty(entryCalif2.Text);

        if (valor1Valido && valor2Valido && calif1Valido && calif2Valido)
        {
            valor1 = entryValor1.Text;
            valor2 = entryValor2.Text;
            calif1 = entryCalif1.Text;
            calif2 = entryCalif2.Text;
        }
        else
        {
        }
    }


    

    private void btnAceptar1_Clicked(object sender, EventArgs e)
    {
        VerificarYTomarValores();
        promediar();

    }

    private void btnAceptar2_Clicked_1(object sender, EventArgs e)
    {

    }

    public void promediar()
    {
        try
        {
            int valorInt1 = int.Parse(valor1);
            int valorInt2 = int.Parse(valor2);
            int califInt1 = int.Parse(calif1);
            int califInt2 = int.Parse(calif2);

            int totalValorParciales = valorInt1 + valorInt2;

            if (totalValorParciales >= 100)
            {
                Calificacion = "La suma de los valores de los dos parciales no puede ser igual o mayor a 100.";
                return;
            }

            double calificacionActual = ((califInt1 * valorInt1) + (califInt2 * valorInt2)) / 100.0;

            int valorTercerParcial = 100 - totalValorParciales;
            double calificacionNecesariaTercerParcial = (10.0 * 100 - califInt1 * valorInt1 - califInt2 * valorInt2) / valorTercerParcial;

            double calificacionNecesariaTercerParcialParaSeis = (6.0 * 100 - califInt1 * valorInt1 - califInt2 * valorInt2) / valorTercerParcial;

            calificacionNecesariaTercerParcial = Math.Round(calificacionNecesariaTercerParcial, 2);
            calificacionNecesariaTercerParcialParaSeis = Math.Round(calificacionNecesariaTercerParcialParaSeis, 2);

            string mensaje = $"Calificación actual: {calificacionActual}.\n";

            if (calificacionNecesariaTercerParcial > 10)
            {
                mensaje += "No es posible alcanzar una calificación final de 10.\n";
            }
            else
            {
                mensaje += $"Necesitas {calificacionNecesariaTercerParcial} en el tercer parcial para alcanzar una calificación final de 10.\n";
            }

            if (calificacionNecesariaTercerParcialParaSeis > 10)
            {
                mensaje += "No es posible alcanzar una calificación final de 6.";
            }
            else
            {
                mensaje += $"Necesitas {calificacionNecesariaTercerParcialParaSeis} en el tercer parcial para alcanzar una calificación final de 6.";
            }

            Calificacion = mensaje;
        }
        catch (FormatException)
        {
            Calificacion = "Por favor ingrese números válidos.";
        }
    }
}


