using System;

namespace Dados
{
    /// <summary>
    /// Registo de quando uma pessoa é submetida a teste, declarada morta, vacinada e removida
    /// </summary>
    [Serializable]
    public class Registo
    {
        #region Attributes
        string t;
        DateTime data;
        string nome;
        #endregion

        #region Constructor
        public Registo(string t, string nome)
        {
            this.t = t;
            this.nome = nome;
            data = DateTime.Now;
        }
        #endregion

        #region Properties
        public string T
        {
            get => t;
            set => t = value;
        }
        public DateTime Data
        {
            get => data;
            set => data = value;
        }
        public string Nome
        {
            get => nome;
            set => nome = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Mostra os dados de um registo
        /// </summary>
        /// <param name="r"></param>
        public static void MostraRegisto(Registo r)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(" Tipo : " + r.T);
            Console.WriteLine(" Nome : " + r.Nome);
            Console.WriteLine(" Data : " + r.Data);
            Console.WriteLine("-------------------------");
        }
        #endregion
    }
}
