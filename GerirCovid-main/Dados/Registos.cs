using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Dados
{
    /// <summary>
    /// Contem a lista de registos e funcoes que mostram e inserem registos
    /// </summary>
    [Serializable]
    public class Registos
    {
        #region Attributes
        static List<Registo> historico;
        #endregion

        #region Constructor
        static Registos()
        {
            historico = new List<Registo>();
        }
        #endregion


        #region Methods
        /// <summary>
        /// insere um registo na lista de registos
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool InsereRegisto(Registo r)
        {
            historico.Add(r);
            return true;
        }
        /// <summary>
        /// mostra todos os registos da lista de registos
        /// </summary>
        public static void MostrarRegistos()
        {
            foreach (Registo r in historico)
            {
                Registo.MostraRegisto(r);
            }
        }

        /// <summary>
        /// Metodo que retorna numero de registos totais
        /// </summary>
        /// <returns></returns>
        public static int RetornaTotRegistos()
        {
            return historico.Count;
        }

        #region DATA_LOAD_SAVE

        /// <summary>
        /// Serializa dados de uma lista de registo para um ficheiro binario
        /// </summary>
        public static void SalvarDadosRegistos()
        {
            Stream fileWrite = File.Open("DataRegistry.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(fileWrite, historico);

            fileWrite.Close();
        }

        /// <summary>
        /// Metodo que deserializa informacao de um ficheiro binario e armazena numa lista de registos
        /// </summary>
        public static void CarregarDadosRegistos()
        {
            Stream fileWrite = File.Open("DataRegistry.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (fileWrite.Length != 0)
                historico = (List<Registo>)b.Deserialize(fileWrite);

            fileWrite.Close();
        }

        #endregion

        #endregion
    }
}
