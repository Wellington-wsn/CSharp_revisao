using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        //TODO: adicionar aluno
                        
                        if(alunos[4].Nome == null)
                        {
                            Console.WriteLine("Informr o nome do aluno:");
                            Aluno aluno = new Aluno();
                            aluno.Nome = Console.ReadLine();

                             Console.WriteLine("Informr a note:");

                            //O TryParse testa se ele consegue converter o valor para decimal
                            if (decimal.TryParse(Console.ReadLine() , out decimal nota)) //vai receber um parametro do tipo decimal  
                            {
                                while(nota > 10)
                                {
                                    Console.WriteLine("Digite um nota entre 0 e 10!");
                                    decimal.TryParse(Console.ReadLine() , out nota );
                                }
                                aluno.Nota = nota;
                            }
                            else
                            {
                                throw new ArgumentException("Valor da note deve ser decimal!");
                            }

                            alunos[indiceAluno] = aluno; // passa o o aluno pra o array Alunos indica a posição;
                            indiceAluno++; // incrementa valores no indice
                        }

                        Console.WriteLine();
                        Console.WriteLine("Quantidade maximo de alunos permitido!");

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome)) // variável sem nome(vazia) não é impressa para o usuario  
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }

                        }
                        //TODO: listar alunos
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        //TODO: calcular média geral
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("... Programa encerrado com sucesso!");
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunmos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
        
            string? OpcaoUsuario = Console.ReadLine(); // O caractere ? para declarar a variável como um tipo de referência anulável

            if(OpcaoUsuario == "1" || OpcaoUsuario == "2" || OpcaoUsuario == "3" || OpcaoUsuario == "x")
            {
                Console.WriteLine();
                return OpcaoUsuario;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma das opções do menu!");
                Console.WriteLine("-----");
                Console.WriteLine();
                return OpcaoUsuario = ObterOpcaoUsuario();
            }
        }
    }
}
