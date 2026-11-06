using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistroEstudiantesMVVM.Models;

#pragma warning disable MVVMTK0045 // Suppress WinRT partial property warning to preserve requested field declarations

namespace RegistroEstudiantesMVVM.ViewModels;

public partial class RegistroViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GuardarCommand))]
    private string? nombre;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GuardarCommand))]
    private string? correo;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GuardarCommand))]
    private string? telefono;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GuardarCommand))]
    private string? carrera;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GuardarCommand))]
    private DateTime fecha = DateTime.Today;

    public ObservableCollection<Estudiante> ListaEstudiantes { get; } = new();

    public List<string> CarrerasDisponibles { get; } = new()
    {
        "Ingeniería de Software",
        "Ingeniería de Sistemas",
        "Ingeniería Industrial",
        "Administración de Empresas",
        "Contaduría Pública",
        "Medicina",
        "Derecho",
        "Psicología",
        "Diseño Gráfico"
    };

    private bool PuedeGuardar()
    {
        if (string.IsNullOrWhiteSpace(Nombre) ||
            string.IsNullOrWhiteSpace(Correo) ||
            string.IsNullOrWhiteSpace(Telefono) ||
            string.IsNullOrWhiteSpace(Carrera))
        {
            return false;
        }

        // Validación básica de formato de correo electrónico
        if (!Regex.IsMatch(Correo.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            return false;
        }

        // Validación básica de teléfono (mínimo 7 caracteres)
        if (Telefono.Trim().Length < 7)
        {
            return false;
        }

        return true;
    }

    [RelayCommand(CanExecute = nameof(PuedeGuardar))]
    private void Guardar()
    {
        var estudiante = new Estudiante
        {
            Nombre = Nombre?.Trim() ?? string.Empty,
            Correo = Correo?.Trim() ?? string.Empty,
            Telefono = Telefono?.Trim() ?? string.Empty,
            Carrera = Carrera?.Trim() ?? string.Empty,
            FechaRegistro = Fecha
        };

        ListaEstudiantes.Add(estudiante);

        // Limpiar los campos del formulario
        Nombre = string.Empty;
        Correo = string.Empty;
        Telefono = string.Empty;
        Carrera = null;
        Fecha = DateTime.Today;
    }
}
