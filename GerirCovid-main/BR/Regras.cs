using System;
using System.Collections.Generic;
using BO;
using Dados;
using System.IO;

namespace BR
{
    public class PessoasRegras
    {
        public static bool AdicionarPessoa(Pessoa p)
        {
            return Pessoas.InserePessoa(p);
        }
        public static int ObterTotalConfirmados()
        {
            return Pessoas.TotConfirmados;
        }
        public static void IncrementaTotalTestados()
        {
            Pessoas.TotTestados++;
        }
        public static void ListarInfetados()
        {
            Pessoas.MostraPessoas();
        }
        public static Pessoa ProcuraPessoaCC(int cc)
        {
            return Pessoas.PesquisaCC(cc);
        }
        public static void OrdenarListaPessoas(int n1, int n2)
        {
            Pessoas.OrdenarLista(n1, n2);
        }
        public static bool VerificarCCDisponivel(int cc)
        {
            return Pessoas.VerificarRepeticaoByCC(cc);
        }
        public static void ContaInfetadosRegiao()
        {
            Pessoas.ContadorRegiao();
        }
        public static void ContaInfetadosIdade(int min, int max)
        {
            Pessoas.ContadorIdade(min, max);
        }
        public static void ContaInfetadosGenero()
        {
            Pessoas.ContadorGenero();
        }
        public static void ContaInfetadosEstados()
        {
            Pessoas.ContadorEstados();
        }
        public static void ListaPessoaNome(string nome)
        {
            Pessoas.PesquisaNome(nome);
        }
        public static bool RemoverInfetado(Pessoa p)
        {
            return Pessoas.RemoverPessoa(p);
        }
    }
    public class RegistosRegras
    {
        public static int ObterTotalRegistos()
        {
            return Registos.RetornaTotRegistos();
        }
        public static void ListarRegistos()
        {
            Registos.MostrarRegistos();
        }
        public static void CriarRegisto(string s, string nome)
        {
            Registos.InsereRegisto(new Registo(s, nome));
        }
    }

    /// <summary>
    /// Class com metodos que verificam certos dados...
    /// </summary>
    public class Verificacoes
    {
        /// <summary>
        /// Verifica se a opcao selecionada é valida para os intervalos selecionados
        /// </summary>
        /// <param name="op"></param>
        /// <param name="limInf"></param>
        /// <param name="limSup"></param>
        /// <returns></returns>
        public static bool VerificaOP(int op, int limInf, int limSup)
        {
            if (limInf > limSup)
            {
                int aux = limInf;
                limInf = limSup;
                limSup = aux;
            }

            if (op <= limSup && op >= limInf) return true;
            return false;
        }

        /// <summary>
        /// Verifica se a data de nascimento é valida
        /// </summary>
        /// <param name="idade"></param>
        /// <returns></returns>
        public static bool VerificaDataNascimento(DateTime dn)
        {
            if (dn.CompareTo(DateTime.Now) > 0) return false;
            return true;
        }

        /// <summary>
        /// Verifica se o CC é valido
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static bool VerificaCCValido(int cc)
        {
            if (cc <= 0) return false;
            return true;
        }
    }

    /// <summary>
    /// Class MyComparer para fazer comparacao 
    /// de objetos (para utilizar em <List>.Sort(new MyComparer()))
    /// </summary>
    public class MyComparer : IComparer<Pessoa>
    {
        /// <summary>
        /// POR DECOMENTAR METODOS
        /// </summary>
        private ORD ord;
        private SENTIDO sentido;

        //Construtor que recebe um sentido de ordem e categoria de ordem
        public MyComparer(ORD ord, SENTIDO sentido)
        {
            this.ord = ord;
            this.sentido = sentido;
        }

        //Metodo comparativo entre quaisquer 2 objetos (apto para comparar Pessoa)
        public int Compare(Pessoa x, Pessoa y)
        {
            //Ordena por idade
            if (ord == ORD.Idade)
            {
                if (sentido == SENTIDO.Asc)
                    return (x.Idade > y.Idade ? 1 : (x.Idade == y.Idade ? 0 : -1));
                else
                    return (x.Idade > y.Idade ? -1 : (x.Idade == y.Idade ? 0 : 1));
            }
            //Ordena por CC
            else if (ord == ORD.Cc)
            {
                if (sentido == SENTIDO.Asc)
                    return (x.Cc > y.Cc ? 1 : (x.Cc == y.Cc ? 0 : -1));
                else
                    return (x.Cc > y.Cc ? -1 : (x.Cc == y.Cc ? 0 : 1));
            }
            //Ordena por ID
            else if (ord == ORD.Id)
            {
                if (sentido == SENTIDO.Asc)
                    return (x.Id > y.Id ? 1 : (x.Id == y.Id ? 0 : -1));
            }
            //Ordena por nome
            else
            {
                if (sentido == SENTIDO.Asc)
                    return (String.Compare(x.Nome.ToLower(), y.Nome.ToLower()));
                else
                    return (String.Compare(y.Nome.ToLower(), x.Nome.ToLower()));
            }

            return -1;
        }
    }

    /// <summary>
    /// Class com as funcionalidades de serialização e deserialização de dados
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Metoto que carrega informaçao
        /// </summary>
        public static void LoadData()
        {
            try
            {
                Pessoas.CarregarDadosLista();
                Pessoas.CarregarDadosTotConfirmados();
                Pessoas.CarregarDadosTotTestados();
                Registos.CarregarDadosRegistos();
            }
            catch (FileLoadException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
        /// <summary>
        /// Metodo que guarda informacao
        /// </summary>
        public static void SaveData()
        {
            try
            {
                Pessoas.SalvarDadosLista();
                Pessoas.SalvarDadosTotConfirmados();
                Pessoas.SalvarDadosTotTestados();
                Registos.SalvarDadosRegistos();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
