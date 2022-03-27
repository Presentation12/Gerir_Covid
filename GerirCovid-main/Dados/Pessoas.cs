using System;
using System.Collections.Generic;
using BO;
using BR;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Dados
{
    /// <summary>
    /// Class de lista de Pessoas 
    /// Contém todos os métodos para trabalhar com a lista de pessoas e para obter dados
    /// </summary>
    [Serializable]
    public class Pessoas
    {
        /// <summary>
        /// Atributos que representam a class
        /// </summary>
        #region Attributes
        static List<Pessoa> pessoas;
        static int totTestados = 0;
        static int totConfirmados = 0; //todas as pessoas que têm ou tiveram infetadas
        #endregion

        #region Constructors

        static Pessoas()
        {
            pessoas = new List<Pessoa>();
        }

        #endregion

        /// <summary>
        /// Utilizado para poder acessar os atributos que estão privados
        /// </summary>
        #region Properties
        public static int TotTestados
        {
            get => totTestados;
            set => totTestados = value;
        }
        public static int TotConfirmados
        {
            get => totConfirmados;
            set => totConfirmados = value;
        }
        #endregion

        #region Methods
        #region INSERT

        /// <summary>
        /// Recebe o cc de uma Pessoa e retorna true caso esse cc ja exista
        /// </summary>
        /// <param name="cc">cartao de cidadao</param>
        /// <returns>booleano</returns>
        public static bool VerificarRepeticaoByCC(int cc)
        {
            foreach (Pessoa p in pessoas)
            {
                if (p.Cc == cc) return false;
            }
            return true;
        }
        /// <summary>
        /// Insere uma pessoa na lista e retorna true caso insira com sucesso
        /// </summary>
        /// <param name="p">pessoa</param>
        /// <returns>booleano</returns>
        public static bool InserePessoa(Pessoa p)
        {
            if (pessoas.Contains(p)) return false;

            TotTestados++;
            pessoas.Add(p);
            return true;
        }
       
        #endregion

        #region SHOW

        /// <summary>
        /// Percorre a lista mostrando cada pessoa dela
        /// </summary>
        public static void MostraPessoas()
        {
            foreach (Pessoa p in pessoas)
            {
                Pessoa.MostraPessoa(p);
            }
        }
        /// <summary>
        /// Mostra a quantidade de pessoas em um limite estabelecido pelo utilizador
        /// </summary>
        /// <param name="count">contador</param>
        /// <param name="max">limite maximo</param>
        /// <param name="min">limite minimo</param>
        public static void MostraQtIdade(int count, int max, int min)
        {
            Console.WriteLine("Existem " + count + " infentados entre os " + min + " e os " + max + " anos");
        }
        #endregion

        #region COUNTERS
        /// <summary>
        /// Apos caso dar positivo na criacao da pessoa, incrementar contadores
        /// </summary>
        /// <param name="p"></param>
        public static void IncrementaTots(ref Pessoa p)
        {
            p.Id = TotConfirmados;
            p.Estado = ESTADO.Infetado;
            p.TotTestes++;
            TotConfirmados++;
        }
        /// <summary>
        /// Mostra os contadores de cada um dos seguintes campos relativamente a Estados
        /// </summary>
        /// <param name="totInf">total de infetados</param>
        /// <param name="totOb">total de obitos</param>
        /// <param name="totRec">total de recuperados</param>
        /// <param name="totVac">total de vacinados</param>
        public static void MostraQtEstados(int totInf, int totOb, int totRec, int totVac)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Ativos                : " + totInf);
            Console.WriteLine("Recuperados           : " + totRec);
            Console.WriteLine("Obitos                : " + totOb);
            Console.WriteLine("Confirmados           : " + TotConfirmados);
            Console.WriteLine("Total de Testes       : " + TotTestados);
            Console.WriteLine("Vacinas administradas : " + totVac);
            Console.WriteLine("-------------------------------");
        }
        /// <summary>
        /// conta cada um dos estados da pessoa:
        /// infetado, morto, recuperado, vacinado
        /// </summary>
        public static void ContadorEstados()
        {
            int totInf = 0, totOb = 0, totRec = 0, totVac = 0;

            foreach (Pessoa p in pessoas)
            {
                switch (p.Estado)
                {
                    case ESTADO.Infetado:
                        totInf++;
                        break;
                    case ESTADO.Morto:
                        totOb++;
                        break;
                    case ESTADO.Recuperado:
                        totRec++;
                        break;
                    case ESTADO.Vacinado:
                        totVac++;
                        break;
                }
            }
            MostraQtEstados(totInf, totOb, totRec, totVac);
        }
        /// <summary>
        /// Mostra os contadores de cada um dos seguintes campos relativamente a Regioes
        /// </summary>
        /// <param name="totN">total de infetados do norte</param>
        /// <param name="totS">total de infetados do sul</param>
        /// <param name="totC">total de infetados do centro</param>
        /// <param name="totI">total de infetados das ilhas</param>
        public static void MostraQtRegiao(int totN, int totS, int totC, int totI)
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("      Infetados");
            Console.WriteLine("----------------------");
            Console.WriteLine("Norte  : " + totN);
            Console.WriteLine("Sul    : " + totS);
            Console.WriteLine("Centro : " + totC);
            Console.WriteLine("Ilhas  : " + totI);
            Console.WriteLine("----------------------");
        }
        /// <summary>
        /// conta total de infetados por regiao
        /// norte, sul, centro, ilhas
        /// </summary>
        public static void ContadorRegiao()
        {
            int totN = 0, totC = 0, totS = 0, totI = 0;
            foreach (Pessoa p in pessoas)
            {
                if (p.Estado == ESTADO.Infetado)
                {
                    switch (p.Regiao)
                    {
                        case REGIAO.Norte:

                            totN++;
                            break;
                        case REGIAO.Centro:
                            totC++;
                            break;
                        case REGIAO.Sul:
                            totS++;
                            break;
                        case REGIAO.Ilhas:
                            totI++;
                            break;
                    }
                }
            }
            MostraQtRegiao(totN, totS, totC, totI);

        }
        /// <summary>
        /// Mostra os contadores de cada um dos seguintes campos relativamente a Genero
        /// </summary>
        /// <param name="totM">total de masculinos</param>
        /// <param name="totF">total de femininos</param>
        public static void MostraQtGenero(int totM, int totF)
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("      Infetados");
            Console.WriteLine("----------------------");
            Console.WriteLine("Masculino : " + totM);
            Console.WriteLine("Feminino  : " + totF);
            Console.WriteLine("----------------------");
        }
        /// <summary>
        /// conta o total de infetados por genero
        /// </summary>
        public static void ContadorGenero()
        {
            int totM = 0, totF = 0;
            //Talvez colocar condiçoes do foreach em rules (???)
            foreach (Pessoa p in pessoas)
            {
                if (p.Estado == ESTADO.Infetado)
                {
                    switch (p.Genero)
                    {
                        case GENERO.Masculino:
                            totM++;
                            break;
                        case GENERO.Feminino:
                            totF++;
                            break;
                    }
                }
            }
            MostraQtGenero(totM, totF);
        }
        /// <summary>
        /// Conta o total de pessoas num intervalo estabelecido pelo utilizador
        /// </summary>
        /// <param name="min">limite minimo</param>
        /// <param name="max">limite maximo</param>
        public static void ContadorIdade(int min, int max)
        {
            int count = 0;
            foreach (Pessoa p in pessoas)
            {
                //Talvez passar por parametro estes dados e fazer condiçao em rules????
                if (p.Idade >= min && p.Idade <= max && p.Estado == ESTADO.Infetado)
                {
                    count++;
                }
            }
            MostraQtIdade(count, max, min); ;
        }
        #endregion

        #region SEARCHES
        /// <summary>
        /// Pesquisa uma pessoa lista usando o cc como parametro
        /// </summary>
        /// <param name="cc">cartao de cidadao</param>
        /// <returns>pessoa</returns>
        public static Pessoa PesquisaCC(int cc)
        {
            foreach (Pessoa p in pessoas)
            {
                if (p.Cc == cc)
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Pesquisa uma pessoa lista usando o nome como parametro
        /// </summary>
        /// <param name="nome">nome</param>
        public static void PesquisaNome(string nome)
        {
            foreach (Pessoa p in pessoas)
            {
                if (p.Nome.ToLower().Contains(nome.ToLower()))
                {
                    Pessoa.MostraPessoa(p);
                }
            }
        }
        #endregion

        #region DATA_SAVE_LOAD

        #region SAVE_DATA
        /// <summary>
        /// Metodo que serializa informacao da lista de pessoas num ficheiro binario
        /// </summary>
        public static void SalvarDadosLista()
        {
            Stream fileWrite = File.Open("DataList.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(fileWrite, pessoas);

            fileWrite.Close();
        }

        /// <summary>
        /// Metodo que serializa o numero total de pessoas que têm ou
        /// tiveram infetadas num ficheiro binario
        /// </summary>
        public static void SalvarDadosTotConfirmados()
        {
            Stream fileWrite = File.Open("DataTotConfirmados.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(fileWrite, TotConfirmados);

            fileWrite.Close();
        }

        /// <summary>
        /// Metodo que serializa o numero total de pessoas que fizeram testes num ficheiro binario
        /// </summary>
        public static void SalvarDadosTotTestados()
        {
            Stream fileWrite = File.Open("DataTotTestados.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(fileWrite, TotTestados);

            fileWrite.Close();
        }
        #endregion

        #region LOAD_DATA
        /// <summary>
        /// Metodo que deserializa informacao de um ficheiro binario e guarda na lista de pessoas 
        /// </summary>
        public static void CarregarDadosLista()
        {
            Stream fileWrite = File.Open("DataList.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (fileWrite.Length != 0)
                pessoas = (List<Pessoa>)b.Deserialize(fileWrite);

            fileWrite.Close();
        }

        /// <summary>
        /// Metodo que deserializa de um ficheiro binario o numero total de pessoas que têm ou
        /// tiveram infetadas e guarda na variavel totConfirmados
        /// </summary>
        public static void CarregarDadosTotConfirmados()
        {
            Stream fileWrite = File.Open("DataTotConfirmados.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (fileWrite.Length != 0)
                TotConfirmados = (int)b.Deserialize(fileWrite);

            fileWrite.Close();
        }

        /// <summary>
        /// Metodo que deserializa de um ficheiro binario o numero total de pessoas 
        /// que fizeram testes e armazena na variavel totTestados
        /// </summary>
        public static void CarregarDadosTotTestados()
        {
            Stream fileWrite = File.Open("DataTotTestados.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (fileWrite.Length != 0)
                TotTestados = (int)b.Deserialize(fileWrite);

            fileWrite.Close();
        }
        #endregion

        #endregion

        #region OTHERMETHODS

        /// <summary>
        /// Remove uma pessoa permanentemente da lista e dos dados
        /// </summary>
        /// <param name="p">pessoa</param>
        /// <returns>booleano</returns>
        public static bool RemoverPessoa(Pessoa p)
        {
            Registos.InsereRegisto(new Registo("Removida", p.Nome));
            pessoas.Remove(p);
            if (pessoas.Contains(p))
            {
                return false;
            }
            TotTestados = TotTestados - p.TotTestes;
            TotConfirmados--;
            return true;
        }
        /// <summary>
        /// Ordena uma lista perante a categoria inserida e a ordem
        /// </summary>
        /// <param name="opcaoCategoria">Categoria</param>
        /// <param name="opcaoOrdem">Ordem</param>
        public static void OrdenarLista(int opcaoCategoria, int opcaoOrdem)
        {
            switch (opcaoCategoria)
            {
                case 0:
                    if (opcaoOrdem == 0)
                        pessoas.Sort(new MyComparer(ORD.Cc, SENTIDO.Asc));
                    else
                        pessoas.Sort(new MyComparer(ORD.Cc, SENTIDO.Desc));
                    break;
                case 1:
                    if (opcaoOrdem == 0)
                        pessoas.Sort(new MyComparer(ORD.Nome, SENTIDO.Asc));
                    else
                        pessoas.Sort(new MyComparer(ORD.Nome, SENTIDO.Desc));
                    break;
                case 2:
                    if (opcaoOrdem == 0)
                        pessoas.Sort(new MyComparer(ORD.Idade, SENTIDO.Asc));
                    else
                        pessoas.Sort(new MyComparer(ORD.Idade, SENTIDO.Desc));
                    break;
                case 3:
                    pessoas.Sort(new MyComparer(ORD.Id, SENTIDO.Asc));
                    break;
                default:
                    break;
            }
        }

        #endregion
        #endregion
    }
}
