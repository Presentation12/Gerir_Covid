using System;
using BO;
using BR;

namespace Menus
{
    /// <summary>
    /// Class que contem todos os menus e alguns avisos
    /// </summary>
    public class MenuPrincipal
    {
        /// <summary>
        /// Procedimento que mostra texto em relação ao menu principal
        /// </summary>
        public static void Menu()
        {
            try
            {
                int op = -1;

                while (op != 0)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("    Gestao Covid");
                    Console.WriteLine("----------------------");
                    Console.WriteLine(" [1]-Registar\n [2]-Listar\n [3]-Analisar Dados" +
                    "\n [4]-Pesquisar\n [5]-Ficha Pessoal\n [6]-Ordenar\n [7]-Historico\n [8]-Salvar Dados\n [0]-Sair");
                    Console.WriteLine("----------------------");

                    op = int.Parse(Console.ReadLine());
                    while (!Verificacoes.VerificaOP(op, 0, 8))
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("    Gestao Covid");
                        Console.WriteLine("----------------------");
                        Console.WriteLine(" [1]-Registar\n [2]-Listar\n [3]-Analisar Dados" +
                        "\n [4]-Pesquisar\n [5]-Ficha Pessoal\n [6]-Ordenar\n [7]-Historico\n [8]-Salvar Dados\n [0]-Sair");
                        Console.WriteLine("----------------------");

                        op = int.Parse(Console.ReadLine());
                    }

                    MenuOP(op);
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Erro: Cadeia de caracteres de entrada com formato incorrecto");
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Erro: Valor demasiado grande ou demasiado pequeno");
            }
        }
        /// <summary>
        /// Recebe opcao do menu e ocorre um metodo dependendo da op escolhida
        /// </summary>
        /// <param name="op"></param>
        public static void MenuOP(int op)
        {
            int op2 = 0;
            try
            {
                switch (op)
                {
                    case 1:
                        Pessoa p = Pessoa.RegistarPessoa();
                        if (p != null)
                        {
                            if (PessoasRegras.AdicionarPessoa(p) == true) Console.WriteLine("Inserido com sucesso!!!");
                        }
                        Warnings.PressionarSair();
                        break;

                    case 2:
                        if (PessoasRegras.ObterTotalConfirmados() > 0)
                        {
                            Console.Clear();
                            PessoasRegras.ListarInfetados();
                            Warnings.PressionarSair();
                        }
                        else
                        {
                            Warnings.Vazio();
                        }
                        break;

                    case 3:
                        if (PessoasRegras.ObterTotalConfirmados() > 0)
                        {
                            op2 = OutrosMenus.MenuTema();
                            OutrosMenus.OpcaoTema(op2);
                            Warnings.PressionarSair();
                        }
                        else
                        {
                            Warnings.Vazio();
                        }
                        break;

                    case 4:
                        if (PessoasRegras.ObterTotalConfirmados() > 0)
                        {
                            op2 = OutrosMenus.MenuPesquisa();
                            OutrosMenus.OpPesquisa(op2);
                            Warnings.PressionarSair();
                        }
                        else
                        {
                            Warnings.Vazio();
                        }
                        break;

                    case 5:
                        if (PessoasRegras.ObterTotalConfirmados() > 0)
                        {
                            Console.Clear();
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
                            if (p != null) SubMenuPessoa.MenuPessoa(ref p);
                            else Console.WriteLine("Pessoa nao encontrada");
                            Console.Clear();
                        }
                        else
                        {
                            Warnings.Vazio();
                        }
                        break;

                    case 6:
                        if (PessoasRegras.ObterTotalConfirmados() > 0)
                        {
                            Console.Clear();

                            int opcaoCategoria = OutrosMenus.OpCategoria();
                            while (!Verificacoes.VerificaOP(opcaoCategoria, 0, 3))
                            {
                                Console.Clear();
                                opcaoCategoria = OutrosMenus.OpCategoria();
                            }

                            int opcaoOrdem = OutrosMenus.OpOrdem(opcaoCategoria);
                            while (!Verificacoes.VerificaOP(opcaoOrdem, 0, 2))
                            {
                                Console.Clear();
                                opcaoOrdem = OutrosMenus.OpOrdem(opcaoCategoria);
                            }

                            PessoasRegras.OrdenarListaPessoas(opcaoCategoria, opcaoOrdem);

                            Warnings.PressionarSair();
                        }
                        else
                        {
                            Warnings.Vazio();
                        }
                        break;

                    case 7:
                        if (RegistosRegras.ObterTotalRegistos() > 0)
                        {
                            Console.Clear();
                            RegistosRegras.ListarRegistos();
                            Warnings.PressionarSair();
                        }
                        else
                        {
                            Warnings.Vazio();
                        }
                        break;
                    case 8:
                        Console.Clear();
                        Data.SaveData();
                        Console.WriteLine("Dados guardados com sucesso!");
                        Warnings.PressionarSair();
                        break;
                    case 0:
                        Console.WriteLine("A sair...");
                        break;

                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Erro: Cadeia de caracteres de entrada com formato incorrecto");
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Erro: Valor demasiado grande ou demasiado pequeno");
            }
        }
    }
}

