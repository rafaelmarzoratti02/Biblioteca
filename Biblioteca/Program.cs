
using Biblioteca.Entidades;
using System;

List<Livro> listLivros = new List<Livro>()
{
    new Livro { Id = 1,Titulo="As Brasas",Autor="Sandor", ISBN="8585943963", AnoDePublicacao = 1999}
};

List<Usuario> listUsuarios = new List<Usuario>()
{
    new Usuario{Id = 1, Nome="Rafael", Email="rafa@email.com" }
};
List<Emprestimo> listEmprestimos = new List<Emprestimo>()
{
   new Emprestimo{Id = Guid.NewGuid(),IdUsuario = 1, IdLivro = 1, DataEmprestimo = new DateTime(2025,01,05), DataDevolucao = new DateTime(2025,01,15) }
};

#region OperacoesComLivro
void CadastrarLivro()
{
    Console.WriteLine("--------- Cadastro de livro ---------");
    Console.Write("Informe o Id do livro: ");
    int id = Convert.ToInt32(Console.ReadLine()!);

    if (listLivros.Exists(x => x.Id == id))
    {
        Console.Write("Um livro com este Id já está cadastrado. Digite novamente: ");
         id = Convert.ToInt32(Console.ReadLine()!);

        while (listLivros.Exists(x => x.Id == id))
        {
            Console.Write("Id existente, digite novamente: ");
            id = Convert.ToInt32(Console.ReadLine()!);
        }
    }
    
    Console.Write("Informe o título do livro: ");
    string titulo = Console.ReadLine()!;

    Console.Write("Informe o autor do livro: ");
    string autor = Console.ReadLine()!;

    Console.Write("Informe o ISBN do livro: ");
    string isbn = Console.ReadLine()!;

    Console.Write("Informe o ano de publicação do livro: ");
    int ano = Convert.ToInt32(Console.ReadLine()!);


    listLivros.Add(new Livro
    {
        Id = id,
        Titulo = titulo,
        Autor = autor,
        ISBN = isbn,
        AnoDePublicacao = ano
    });

    Console.WriteLine($"{titulo} cadastrado! Retornando ao menu...");
    Thread.Sleep(2000);
}

void ConsultarLivros()
{
    Console.WriteLine("Consultar todos livros");
    foreach (var livro in listLivros)
    {
        livro.MostrarDados();
    }
    Console.WriteLine("Digite qualquer tecla para retornar ao menu...");
    Console.ReadKey();
}

void ConsultarLivro()
{
    Console.WriteLine("--------- Consultar livro ---------");
    Console.Write("Digite o Id do livro: ");
    int id = Convert.ToInt32(Console.ReadLine()!);

    var livro = listLivros.FirstOrDefault(x => x.Id == id);
    if(livro is not null)
        livro.MostrarDados();
    else
        Console.WriteLine("Nenhum livro com este id foi encontrado! ");

    Console.WriteLine("Digite qualquer tecla para retornar ao menu!");
    Console.ReadKey();


}

void DeletarLivro()
{
    Console.WriteLine("--------- Deletar livro ---------");
    Console.WriteLine("Informe o Id do livro a deletar: ");
    int id = Convert.ToInt32(Console.ReadLine()!);

    if (listLivros.Exists(x=> x.Id == id))
    {
        var livroADeletar = listLivros.FirstOrDefault(x=> x.Id == id);
        listLivros.Remove(livroADeletar);

        Console.WriteLine("Livro deletado!Digite qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Nenhum livro com este Id foi encontrado! Digite qualquer tecla para retornar ao menu...");
        Console.ReadKey();
    }
}
#endregion

#region OperacoesComUsuario

void CadastrarUsuario()
{
    Console.WriteLine("--------- Cadastro de usuário ---------");
    Console.Write("Informe o id do usuário: ");
    int id = Convert.ToInt32(Console.ReadLine());

    if(listUsuarios.Exists(x=> x.Id == id))
    {
        Console.WriteLine("Já existe um usuário com este Id. Digite o Id novamente: ");
        id = Convert.ToInt32(Console.ReadLine());

        while (listUsuarios.Exists(x => x.Id == id))
        {
            Console.WriteLine("Já existe um usuário com este Id. Digite o Id novamente");
            id = Convert.ToInt32(Console.ReadLine());
        }
    }

    Console.Write("Informe o nome do usuário: ");
    string nome = Console.ReadLine()!;
    Console.Write("Informe o email do usuário: ");
    string email = Console.ReadLine()!;

    listUsuarios.Add(new Usuario
    {
        Id = id,
        Nome = nome,
        Email = email
    });

    Console.WriteLine("Usuário Cadastrado!");
    Thread.Sleep(2000);
}

void ConsultarUsuarios()
{
    Console.WriteLine("--------- Consultar usuários ---------");
    
    if(listUsuarios.Count == 0)
    {
        Console.WriteLine("Nenhum usuário cadastrado!");
    }else
    {
        foreach (var usuario in listUsuarios)
        {
            usuario.MostrarDados();
        }
    }

    Console.WriteLine("Digite qualquer tecla para retornar ao menu...");
    Console.ReadKey();

}

void ConsultarUsuario()
{
    Console.WriteLine("--------- Consultar Usuário ---------");
    Console.Write("Informe o Id do usuário: ");
    int id = Convert.ToInt32(Console.ReadLine());

    var usuario = listUsuarios.FirstOrDefault(x => x.Id == id);

    if (usuario != null) 
        usuario.MostrarDados();
    else
        Console.WriteLine("Nenhum usuário com este Id foi encontrado.");


    Console.WriteLine("Digite qualquer tecla para retornar ao menu...");
    Console.ReadKey();
}
#endregion

#region OperacoesComEmprestimo
void CadastrarEmprestimo()
{
    Console.WriteLine("--------- Cadastro de emprestimo ---------");
    if(listUsuarios.Count == 0 || listLivros.Count == 0)
    {
        Console.WriteLine("É necessário cadastrar pelo menos um livro e um usuário para cadastrar um empréstimo.");
        Console.WriteLine("Digite qualquer tecla para retornar ao menu");
        Console.ReadKey();
        return;
    }
    Console.Write("Informe o Id de seu usuário: ");
    int id = Convert.ToInt32(Console.ReadLine());

    var usuario = listUsuarios.FirstOrDefault(x => x.Id == id);
    if (usuario is null)
    {
        Console.Write("Não existe um usuário com este Id, digite novamente: ");
        id = Convert.ToInt32(Console.ReadLine());
        usuario = listUsuarios.FirstOrDefault(x => x.Id == id);
        while (usuario is null)
        {
            Console.Write("Id inexistente, digite novamente: ");
            id = Convert.ToInt32(Console.ReadLine());
            usuario = listUsuarios.FirstOrDefault(x => x.Id == id);
        }
    }

    Console.Write("Informe o Id do livro: ");
    id = Convert.ToInt32(Console.ReadLine());

    var livro = listLivros.FirstOrDefault(x => x.Id == id);
    if (livro is null)
    {
        Console.Write("Não existe um livro com este Id, digite novamente: ");
        id = Convert.ToInt32(Console.ReadLine());
        livro = listLivros.FirstOrDefault(x => x.Id == id);
        while (livro is null)
        {
            Console.Write("Id inexistente, digite novamente: ");
            id = Convert.ToInt32(Console.ReadLine());
            livro = listLivros.FirstOrDefault(x => x.Id == id);
        }
    }

    Emprestimo emprestimoACadastrar = new Emprestimo(usuario.Id, livro.Id);
    listEmprestimos.Add(emprestimoACadastrar);

    Console.WriteLine("Empréstimo cadastrado!Devolução daqui a 10 dias!");
    Thread.Sleep(2000);
}

void ConsultarEmprestimos()
{
    Console.WriteLine("--------- Consultar Emprestimos ---------");
    foreach(var emprestimo in listEmprestimos)
    {
        emprestimo.MostrarDados();
    }

    Console.WriteLine("Digite qualquer tecla para retornar ao menu...");
    Console.ReadKey();
}

void DevolverLivroDeEmprestimo()
{
    Console.WriteLine("--------- Devolver livro  ---------");
    Console.WriteLine("Informe o id do livro a devolver: ");
    int id = Convert.ToInt32(Console.ReadLine());

    var emprestimo = listEmprestimos.FirstOrDefault(x => x.IdLivro == id);
    if (emprestimo is null)
    {
        Console.Write("Não existe um livro a devolver com este Id, ");
        Console.WriteLine("Retornando ao menu...");
        Thread.Sleep(2000);
        return;
    }
    else
    {
        if(emprestimo.DataDevolucao >= DateTime.Now)
        {
            Console.WriteLine("Livro entregue! Digite qualquer tecla para retornar ao menu...");
            listEmprestimos.Remove(emprestimo);
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine("Livro entregue com atraso, multa aplicada. Digite qualquer tecla para retornar ao menu...");
            listEmprestimos.Remove(emprestimo);
            Console.ReadKey();
        }
    }

}

#endregion

        while (true)
{
    int option;
    Console.Clear(); 
    Console.WriteLine("--------- BIBLIOTECA ---------");
    Console.WriteLine();
    Console.WriteLine("--------- Livros ---------");
    Console.WriteLine("1 - Para cadastrar um livro");
    Console.WriteLine("2 - Para consultar todos os livros");
    Console.WriteLine("3 - Consultar um Livro");
    Console.WriteLine("4 - Para excluir um livro");
    Console.WriteLine("5 - Para Sair");
    Console.WriteLine();
    Console.WriteLine("--------- Usuários ---------");
    Console.WriteLine("6 - Cadastrar usuário");
    Console.WriteLine("7 - Consultar usuários");
    Console.WriteLine("8 - Consultar um usuário");
    Console.WriteLine();
    Console.WriteLine("--------- Empréstimos ---------");
    Console.WriteLine("9 - Novo empréstimo");
    Console.WriteLine("10 - Consultar empréstimo");
    Console.WriteLine("11 - Devolver livro");



    Console.WriteLine("------------------------------");
    Console.Write("Digite sua opcão: ");

    option = Convert.ToInt32(Console.ReadLine());
    Console.Clear(); 


    switch (option)
    {
        case 1:
            CadastrarLivro();
        break;

        case 2:
            ConsultarLivros();
        break;

        case 3:
            ConsultarLivro();
            break;

        case 4:
            DeletarLivro();
        break;

        case 5:
            return;

        case 6:
            CadastrarUsuario();
            break;

        case 7:
            ConsultarUsuarios();
            break;
        case 8:
            ConsultarUsuario();
            break;
        case 9:
            CadastrarEmprestimo();
            break;
        case 10:
            ConsultarEmprestimos();
            break;
        case 11:
            DevolverLivroDeEmprestimo();
            break;
        default: 
            Console.WriteLine("Opcao Invalida!");
            Thread.Sleep(1500);
             break;
    }

}

