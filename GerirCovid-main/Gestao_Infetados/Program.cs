/**
 * @file Program.cs
 * @author Pedro Simões / João Apresentaçao
 * @email: a21140@alunos.ipca.pt / a21152@alunos.ipca.pt
 * @brief Programa para fazer a orientação, organização e gestão de casos de covid-19
 * @version 0.1
 * @date 2021-03-29
 * 
 * @copyright Copyright (c) 2021
 * 
 */
using Menus;
using BR;
using System.IO;
using System;

namespace Gestao_Infetados
{
    /// <summary>
    /// Class principal do programa
    /// </summary>
    class Program
    {
        /// <summary>
        /// Metodo Main
        /// </summary>
        static void Main()
        {
            try
            {
                Data.LoadData();
                MenuPrincipal.Menu();
                Data.SaveData();
            }
            catch (FileLoadException e)
            {
                Console.WriteLine("Erro: " + e.Message);
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
