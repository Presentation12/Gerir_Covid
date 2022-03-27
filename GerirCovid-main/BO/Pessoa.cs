using System;
using Dados;
using Inputs;


namespace BO
{
    #region Enumerations
    //enumeração do genero de uma Pessoa
    public enum GENERO { Masculino, Feminino };
    //enumeração do estado de uma Pessoa
    public enum ESTADO { Infetado, Morto, Recuperado, Vacinado };
    //enumeração da regiao de uma Pessoa
    public enum REGIAO { Norte, Centro, Sul, Ilhas };
    //enumeração do tema que a pessoa deseja ordenar no metodo ordenarLista
    public enum ORD { Nome, Idade, Cc, Id };
    //enumeração do sentido que a pessoa deseja ordenar no metodo ordenarLista
    public enum SENTIDO { Asc, Desc }
    #endregion
    /// <summary>
    /// Class Pessoa
    /// Contém os atributos:
    ///     -> Nome
    ///     -> Idade
    ///     -> Numero de CC
    ///     -> Regiao
    ///     -> Genero
    ///     -> Estado Vital
    ///     -> ID (Para lista)
    /// Contém seu construtor e propriedades
    /// </summary>
    [Serializable]
    public class Pessoa
    {
        /// <summary>
        /// Atributos que representam a class
        /// </summary>
        #region Attributes

        static int id;
        int totTestes = 0;

        string nome;
        int idade, cc;
        DateTime dataNascimento;
        REGIAO regiao;
        GENERO genero;
        ESTADO estado;

        #endregion

        /// <summary>
        /// Metodo Construtor
        /// Inicializador do objeto Pessoa
        /// </summary>
        #region Constructors
        public Pessoa() { }

        public Pessoa(string nome, int idade, int cc, DateTime dataNascimento, REGIAO regiao, GENERO genero)
        {
            this.nome = nome;
            this.idade = idade;
            this.cc = cc;
            this.dataNascimento = dataNascimento;
            this.regiao = regiao;
            this.genero = genero;
        }

        #endregion

        /// <summary>
        /// Utilizado para poder acessar os atributos que estão privados
        /// </summary>
        #region Properties
        public int TotTestes
        {
            get => totTestes;
            set => totTestes = value;
        }
        public string Nome
        {
            get => nome;
            set => nome = value;
        }
        public int Idade
        {
            get => idade;
            set => idade = value;
        }
        public DateTime DataNascimento
        {
            get => dataNascimento;
            set => dataNascimento = value;
        }
        public int Cc
        {
            get => cc;
            set => cc = value;
        }
        public int Id
        {
            get => id;
            set => id = value;
        }
        public GENERO Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public REGIAO Regiao
        {
            get { return regiao; }
            set { regiao = value; }
        }
        public ESTADO Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region Overrides



        #endregion

        #region Operators



        #endregion

        /// <summary>
        /// Metodos utilizados para o objeto Pessoa
        /// </summary>
        #region Methods

        /// <summary>
        /// Mostra os dados de uma unica pessoa
        /// </summary>
        /// <param name="p">pessoa</param>
        public static void MostraPessoa(Pessoa p)
        {
            Console.WriteLine("----------------------------------------------------------\n CC                 : " + p.Cc + "\n Nome               : " + p.Nome);
            Console.WriteLine(" Idade              : " + p.Idade);
            Console.WriteLine(" Data de Nascimento : " + p.DataNascimento.ToShortDateString()); //para nao mostrar horas
            Console.WriteLine(" Genero             : " + p.Genero);
            Console.WriteLine(" Regiao             : " + p.Regiao);
            Console.WriteLine(" Estado             : " + p.Estado);
            Console.WriteLine(" Qt.Testes          : " + p.TotTestes);
            Console.WriteLine("----------------------------------------------------------");
        }
        /// <summary>
        /// Metodo que calcula a idade de uma pessoa atraves data de nascimento e da data atual
        /// </summary>
        /// <param name="nascimento"></param>
        /// <returns></returns>
        public static int CalculaIdade(DateTime nascimento)
        {
            int idade = DateTime.Now.Year - nascimento.Year;
            if (DateTime.Now.DayOfYear < nascimento.DayOfYear)
            {
                idade -= 1;
            }
            return idade;
        }
        /// <summary>
        /// Envia uma pessoa por referencia, preenche os seus atributos e retorna ela
        /// </summary>
        /// <param name="p">pessoa</param>
        /// <returns>pessoa</returns>
        public static Pessoa RegistarPessoa()
        {
            #region Nome
            string nome = PessoaInput.ObterNome();
            #endregion

            #region Data de Nascimento
                DateTime date = PessoaInput.ObterDataNascimento();

            #endregion

            #region Idade
            int idade = CalculaIdade(date);
            #endregion

            #region CC
            int cc = PessoaInput.ObterCC();

            Console.Clear();
            #endregion

            #region Regiao
            REGIAO regiao = PessoaInput.ObterRegiao();
            #endregion

            #region Genero
            GENERO genero = PessoaInput.ObterGenero();
            #endregion

            #region Resultado de teste
            int op = PessoaInput.ObterOP();
            #endregion

            Pessoa p = new Pessoa(nome, idade, cc, date, regiao, genero);

            if (op == 1)
            {
                Pessoas.IncrementaTots(ref p);
                Registos.InsereRegisto(new Registo("Teste (Positivo)", p.Nome));
            }
            else
            {
                Registos.InsereRegisto(new Registo("Teste (Negativo)", p.Nome));
            }

            return p;
        }
        /// <summary>
        /// Alterar o estado de uma pessoa da lista para morto
        /// </summary>
        /// <param name="p">pessoa</param>
        /// <returns>pessoa</returns>
        public static bool AlterarEstado(Pessoa p)
        {
            p.Estado = ESTADO.Morto;
            Registos.InsereRegisto(new Registo("Declaracao de obito", p.Nome));
            return true;
        }

        #endregion

        #region OtherMethods

        #region Destructor



        #endregion

        #endregion
    }
}