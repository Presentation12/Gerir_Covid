using System;

namespace Menus
{
    public class Warnings
    {
        /// <summary>
        /// Apresentacao de mensagem de que nao ha ninguem na lista
        /// </summary>
        public static void Vazio()
        {
            Console.Clear();
            Console.WriteLine("----------------------\nNao existem pessoas");
            PressionarSair();
        }
        /// <summary>
        /// Apresentacao de mensagem para dar o aviso de saida
        /// </summary>
        public static void PressionarSair()
        {
            Console.WriteLine("\n\n(Pressione qualquer botao para sair)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
