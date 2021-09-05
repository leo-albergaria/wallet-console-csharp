using System;

namespace wallet_revisao_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[25];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        var aluno = new Aluno();

                        Console.WriteLine("Informe o nome do Aluno:");
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do Aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota )) {   
                            aluno.Nota = nota;
                        }
                        else {
                            throw new ArgumentException("Valor da nota dever decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach (var item in alunos) {
                            if (!string.IsNullOrEmpty(item.Nome))
                                Console.WriteLine($"Aluno: {item.Nome} - Nota: {item.Nota}");                            
                        };
                        break;
                    case "3":
                        var qtAluno = 0;
                        decimal somaNota = 0;
                        decimal mediaGeral = 0;
                        Classificacao classificar;
                        
                        foreach (var item in alunos) {
                            if (!string.IsNullOrEmpty(item.Nome)) {
                                qtAluno++;
                                somaNota += item.Nota;                    
                            }
                        };
                        mediaGeral = somaNota/qtAluno;
                        if (mediaGeral < 2) {
                            classificar = Classificacao.E;
                        } else if (mediaGeral < 4) {
                            classificar = Classificacao.D;
                        } else if (mediaGeral < 6) {
                            classificar = Classificacao.C;
                        } else if (mediaGeral < 8) {
                            classificar = Classificacao.B;
                        } else {
                            classificar = Classificacao.A;
                        }        

                        Console.WriteLine($"Médias da Nota da turma: {mediaGeral}");        
                        Console.WriteLine($"Conceito geral: {classificar}");        

                        break;
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }

}
