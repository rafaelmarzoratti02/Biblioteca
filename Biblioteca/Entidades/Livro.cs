using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades;

public class Livro
{

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }

    public void MostrarDados()
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Titulo: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Ano de publicação: {AnoDePublicacao}");
        Console.WriteLine();
    }
}
