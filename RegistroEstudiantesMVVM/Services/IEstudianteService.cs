using RegistroEstudiantesMVVM.Models;

namespace RegistroEstudiantesMVVM.Services;

public interface IEstudianteService
{
    IEnumerable<Estudiante> ObtenerEstudiantes();
    void AgregarEstudiante(Estudiante estudiante);
}
