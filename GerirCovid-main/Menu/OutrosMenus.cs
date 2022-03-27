using System;
using BO;
using BR;

namespace Menus
{
    class OutrosMenus
    {
        /// <summary>
        /// Tema a escolher para uma listagem
        /// </summary>
        /// <param name ="op">opção para o menu tema</param>
        /// <returns>opção</returns>
        public static int MenuTema()
        {
            int op = 0;

            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine(" [0]-Regiao\n [1]-Idade\n [2]-Genero\n [3]-Estado");
            Console.Write("----------------------\nOPCAO ==>");
            op = int.Parse(Console.ReadLine());
            while (!Verificacoes.VerificaOP(op, 0, 3))
            {
                Console.Clear();
                Console.WriteLine("----------------------");
                Console.WriteLine(" [0]-Regiao\n [1]-Idade\n [2]-Genero\n [3]-Estado");
                Console.Write("----------------------\nOPCAO ==>");
                op = int.Parse(Console.ReadLine());
            }

            return op;
        }
        /// <summary>
        /// Operacoes a fazer em relacao ao tipo de listagem escolhido pelo utilizador
        /// </summary>
        /// <param name="op">opção do menu tema</param>
        public static void OpcaoTema(int op)
        {
            try
            {
                switch (op)
                {
                    case 0:
                        PessoasRegras.ContaInfetadosRegiao();
                        break;

                    case 1:
                        Console.Clear();
                        int max, min;
                        Console.WriteLine("Limite minimo:");
                        min = int.Parse(Console.ReadLine());
                        while (!Verificacoes.VerificaCCValido(min))
                        {
                            Console.Clear();
                            Console.WriteLine("Limite minimo:");
                            min = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Limite maximo:");
                        max = int.Parse(Console.ReadLine());
                        while (max <= min)
                        {
                            Console.WriteLine("Limite maximo:");
                            max = int.Parse(Console.ReadLine());
                        }

                        PessoasRegras.ContaInfetadosIdade(min, max);
                        break;

                    case 2:
                        PessoasRegras.ContaInfetadosGenero();
                        break;
                    case 3:
                        PessoasRegras.ContaInfetadosEstados();
                        break;

                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Cadeia de caracteres de entrada com formato incorrecto");
            }
        }
        /// <summary>
        /// Metodo que devolve escolha do utilizador para o tipo de pesquisa
        /// </summary>
        /// <param name="op">opção do menu pesquisa</param>
        /// <returns>opção</returns>
        public static int MenuPesquisa()
        {
            int op = 0;

            Console.Clear();
            Console.WriteLine("Selecione o tipo de pesquisa");
            Console.WriteLine("----------------------");
            Console.WriteLine(" [0]-CC\n [1]-Nome");
            Console.Write("----------------------\nOPCAO ==>");
            op = int.Parse(Console.ReadLine());

            while (!Verificacoes.VerificaOP(op, 0, 1))
            {
                Console.Clear();
                Console.WriteLine("Selecione o tipo de pesquisa");
                Console.WriteLine("----------------------");
                Console.WriteLine(" [0]-CC\n [1]-Nome");
                Console.Write("----------------------\nOPCAO ==>");
                op = int.Parse(Console.ReadLine());
            }

            return op;
        }
        /// <summary>
        /// Procedimento que efetua a pesquisa pretendida
        /// </summary>
        /// <param name="op">opção do menu pesquisa</param>
        public static void OpPesquisa(int op)
        {
            try
            {
                Pessoa p = new Pessoa();
                switch (op)
                {
                    case 0:
                        int cc;
                        Console.WriteLine("CC: ");
                        cc = int.Parse(Console.ReadLine());
                        while (!Verificacoes.VerificaCCValido(cc))
                        {
                            Console.Clear();
                            Console.WriteLine("CC: ");
                            cc = int.Parse(Console.ReadLine());
                        }

                        Console.Clear();
                        p = PessoasRegras.ProcuraPessoaCC(cc);
                        Console.Clear();

                        if (p != null) Pessoa.MostraPessoa(p);
                        else Console.WriteLine("Pessoa nao encontrada");
                        break;

                    case 1:
                        Console.WriteLine("Nome:");
                        string nome;
                        nome = Console.ReadLine();
                        if (nome.Length == 0) throw new FormatException();
                        Console.Clear();
                        PessoasRegras.ListaPessoaNome(nome);
                        break;

                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Cadeia de caracteres de entrada com formato incorrecto");
            }
        }
        /// <summary>
        /// Procedimento que apresenta e devolve categoria de ordenacao
        /// </summary>
        /// <returns>opção</returns>
        public static int OpCategoria()
        {
            int op = 0;

            Console.WriteLine("----------------------");
            Console.WriteLine(" [0]-CC\n [1]-Nome\n [2]-Idade\n [3]-Ordem Original");
            Console.WriteLine("----------------------");
            op = int.Parse(Console.ReadLine());

            return op;
        }
        /// <summary>
        /// Metodo que apresenta e devolve formas de ordenacao
        /// </summary>
        /// <returns>opção</returns>
        public static int OpOrdem(int opcaoCategoria)
        {
            int op = 0;

            if (opcaoCategoria == 3) return 2;

            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine(" [0]-Ascendente\n [1]-Descendente");
            Console.WriteLine("----------------------");
            op = int.Parse(Console.ReadLine());

            return op;
        }
    }
}
