using System;
using BO;
using BR;

namespace Menus
{
    class SubMenuPessoa
    {
        /// <summary>
        /// Procedimento que navega dentro do menu secundario que controla os dados de uma certa pessoa da lista
        /// </summary>
        /// <param name="p">pessoa</param>
        public static void MenuPessoa(ref Pessoa p)
        {
            int op;

            TextoMenuPessoa();
            op = int.Parse(Console.ReadLine());
            while (!Verificacoes.VerificaOP(op, 0, 5))
            {
                Console.Clear();
                TextoMenuPessoa();
                op = int.Parse(Console.ReadLine());
            }
            OpcoesMenuPessoa(op, ref p);

            while (op != 0 && op != 5)
            {
                TextoMenuPessoa();
                op = int.Parse(Console.ReadLine());
                while (!Verificacoes.VerificaOP(op, 0, 5))
                {
                    Console.Clear();
                    TextoMenuPessoa();
                    op = int.Parse(Console.ReadLine());
                }
                OpcoesMenuPessoa(op, ref p);
            }

        }
        /// <summary>
        /// Procedimento com texto do submenu Pessoa
        /// </summary>
        static void TextoMenuPessoa()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("SUB-MENU <PESSOA>\n [1]-Mostrar Dados\n [2]-Novo Teste\n [3]-Vacinar\n [4]-Declarar Obito\n [5]-Eliminar\n [0]-Voltar");
            Console.WriteLine("----------------------");
        }
        /// <summary>
        /// Procedimento com opcoes de manipulacao de dados de uma pessoa
        /// </summary>
        /// <param name="op">opção do menu pessoa</param>
        /// <param name="p">pessoa a ser usada nos respetivos metodos</param>
        static void OpcoesMenuPessoa(int op, ref Pessoa p)
        {
            switch (op)
            {
                case 1:
                    Console.Clear();
                    Pessoa.MostraPessoa(p);
                    Warnings.PressionarSair();
                    break;

                case 2:
                    Console.Clear();
                    if (p.Estado == ESTADO.Morto)
                    {
                        Console.WriteLine("O sujeito foi declarado morto");
                        Warnings.PressionarSair();
                    }
                    else if (p.Estado == ESTADO.Vacinado)
                    {
                        Console.WriteLine("O sujeito foi declarado vacinado");
                        Warnings.PressionarSair();
                    }
                    else
                    {
                        Console.WriteLine("Resultado: \n [0]-Negativo\n [1]-Positivo");
                        op = int.Parse(Console.ReadLine());
                        while (!Verificacoes.VerificaOP(op, 0, 1))
                        {
                            Console.Clear();
                            Console.WriteLine("Resultado: \n [0]-Negativo\n [1]-Positivo");
                            op = int.Parse(Console.ReadLine());
                        }

                        if (op == 0)
                        {
                            p.Estado = ESTADO.Recuperado;
                            RegistosRegras.CriarRegisto("Teste (Negativo)", p.Nome);
                        }
                        else if (op == 1)
                        {
                            p.Estado = ESTADO.Infetado;
                            RegistosRegras.CriarRegisto("Teste (Positivo)", p.Nome);
                        }
                        Console.Clear();
                        p.TotTestes++;
                        PessoasRegras.IncrementaTotalTestados();
                    }
                    break;

                case 3:
                    Console.Clear();
                    if (p.Estado == ESTADO.Morto)
                    {
                        Console.WriteLine("O sujeito foi declarado morto");
                        Console.WriteLine("\n\n(Pressione qualquer botao para sair)");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (p.Estado == ESTADO.Vacinado)
                    {
                        Console.WriteLine("O sujeito foi declarado vacinado");
                        Warnings.PressionarSair();
                    }
                    else
                    {
                        p.Estado = ESTADO.Vacinado;
                        RegistosRegras.CriarRegisto("Vacinado", p.Nome);
                    }
                    break;

                case 4:
                    Console.Clear();
                    if (Pessoa.AlterarEstado(p) == true) Console.WriteLine("Alterado com sucesso!!!");
                    else Console.WriteLine("Erro!!!");
                    Warnings.PressionarSair();
                    break;

                case 5:
                    Console.Clear();
                    if (PessoasRegras.RemoverInfetado(p) == true) Console.WriteLine("Removido com sucesso!!!");
                    else Console.WriteLine("Erro!!!");
                    Warnings.PressionarSair();
                    break;


                case 0:
                    break;

                default:
                    break;
            }
        }
    }
}
