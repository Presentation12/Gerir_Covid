using BR;
using BO;
using System;

namespace Inputs
{
    public class PessoaInput
    {
        /// <summary>
        /// Metodo que devolve um nome inserido pelo user
        /// </summary>
        /// <returns></returns>
        public static string ObterNome()
        {
            string nome;

            Console.Clear();
            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();
            if (nome.Length == 0) throw new FormatException();
            Console.Clear();

            return nome;
        }
        /// <summary>
        /// Metodo que devolve uma data inserida pelo user
        /// </summary>
        /// <returns></returns>
        public static DateTime ObterDataNascimento()
        {
            Console.WriteLine("Data de Nascimento (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            while (!Verificacoes.VerificaDataNascimento(data))
            {
                Console.Clear();
                Console.WriteLine("Data de Nascimento (dd/mm/aaaa): ");
                data = DateTime.Parse(Console.ReadLine());
            }

            Console.Clear();
            return data;
        }
        /// <summary>
        /// Metodo que devolve o cc inserida pelo user
        /// </summary>
        /// <returns></returns>
        public static int ObterCC()
        {
            Console.WriteLine("Cartao de cidadao: ");
            int cc = int.Parse(Console.ReadLine());
            while (!PessoasRegras.VerificarCCDisponivel(cc) || !Verificacoes.VerificaCCValido(cc))
            {
                Console.WriteLine("CC Invalido! Pressione qualquer butao para introduzir novamente");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Cartao de cidadao: ");
                cc = int.Parse(Console.ReadLine());
            }

            return cc;
        }
        /// <summary>
        /// Metodo que devolve uma regiao inserida pelo user
        /// </summary>
        /// <returns></returns>
        public static REGIAO ObterRegiao()
        {
            REGIAO r;
            Console.WriteLine("Regiao: \n[0]-Norte\n[1]-Centro\n[2]-Sul\n[3]-Ilhas");
            int op = int.Parse(Console.ReadLine());
            while (!Verificacoes.VerificaOP(op, 0, 3))
            {
                Console.Clear();
                Console.WriteLine("Regiao: \n[0]-Norte\n[1]-Centro\n[2]-Sul\n[3]-Ilhas");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    r = REGIAO.Norte;
                    break;

                case 1:
                    r = REGIAO.Centro;
                    break;

                case 2:
                    r = REGIAO.Sul;
                    break;

                case 3:
                    r = REGIAO.Ilhas;
                    break;
                default:
                    r = REGIAO.Norte;
                    break;
            }
            Console.Clear();

            return r;
        }
        /// <summary>
        /// Metodo que devolve um genero inserida pelo user
        /// </summary>
        /// <returns></returns>
        public static GENERO ObterGenero()
        {
            GENERO g;
            Console.WriteLine("Genero: \n[0]-Masculino\n[1]-Feminino");
            int op = int.Parse(Console.ReadLine());
            while (!Verificacoes.VerificaOP(op, 0, 1))
            {
                Console.Clear();
                Console.WriteLine("Genero: \n[0]-Masculino\n[1]-Feminino");
                op = int.Parse(Console.ReadLine());
            }
            if (op == 0) g = GENERO.Masculino;
            else g = GENERO.Feminino;

            Console.Clear();

            return g;
        }
        /// <summary>
        /// Metodo que devolve uma opcao inserida pelo user
        /// </summary>
        /// <returns></returns>
        public static int ObterOP()
        {
            Console.WriteLine("Resultado: \n[]-Negativo\n[1]-Positivo");
            int op = int.Parse(Console.ReadLine());
            Console.Clear();

            return op;
        }
    }
}
