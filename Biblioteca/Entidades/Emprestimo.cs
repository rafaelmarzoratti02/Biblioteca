using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades;

internal class Emprestimo
{
    
    public Guid Id { get; set; }
    public int IdUsuario { get; set; }
    public int IdLivro { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }

    public Emprestimo() { }

    public Emprestimo(int idUsuario, int idLivro)
    {
        Id = Guid.NewGuid();
        IdUsuario = idUsuario;
        IdLivro = idLivro;
        DataEmprestimo = DateTime.Now;
        DataDevolucao = DataEmprestimo.AddDays(10);
    }

    public void MostrarDados()
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Usuário: {IdUsuario}");
        Console.WriteLine($"Livro: {IdLivro}");
        Console.WriteLine($"Data Emprestimo: {DataEmprestimo}");
        Console.WriteLine($"Data Devolução: {DataDevolucao}");
        Console.WriteLine();
    }
}
