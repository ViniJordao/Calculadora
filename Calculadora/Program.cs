using System;

namespace Calculadora.ConsoleApp
{
    class Program
    {
        #region Requisito Funcional 01 [OK]
        //Nossa calculadora deve ter a possibilidade de somar dois números
        #endregion

        #region Requisito Funcional 02 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma
        #endregion

        #region Requisito Funcional 03 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma e de subtração
        #endregion

        #region Requisito Funcional 04 [OK]
        //Nossa calculadora deve ter a possibilidade fazer as quatro operações básicas da matemática
        #endregion

        #region Requisito Funcional 05 [OK]
        //Nossa calculadora deve validar a opções do menu [OK]
        #endregion

        #region BUG 01 [OK]
        //Nossa calculadora deve realizar as operações com "0"
        #endregion

        #region Requisito 06
        /** Nossa calculadora deve permitir visualizar as operações já realizadas
         *  Critérios:
         *      1 - A descrição da operação realizada deve aparecer assim, exemplo:
         *          2 + 2 = 4
         *          10 - 5 = 5
         *          
         *      2 - caso não nenhuma operaçao foi realizada mostrar a msg:
         *          Nenhuma operação foi realizada ainda
         */
        #endregion

        #region requisito não Funcional
        //Todas as funcionalidades implementadas,
        //precisamos melhorar o entendiimento do nosso código
        #endregion


        static void Main(string[] args)
        {
            string[] operacoesRealizadas = new string[100];
            string  opcao = "";
            int contadorOperacoesrealizadas = 0;

            while (true)
            {
                MostarMenu();


                opcao = Console.ReadLine();


                if (EhOpcaoInvalida(opcao)) //AND 
                {
                    string mensagemDeErro = "Opção inválida! Tente novamente";

                    MostrarMensagem("Opção inválida! Tente novamente");

                    continue;
                }
                //mostar opraçoes
                if (EhOpcaoVisualizacao(opcao))
                {
                    Console.WriteLine();
                    if (contadorOperacoesrealizadas == 0)
                    {
                        MostrarMensagem("Nenhuma operação foi realizada ainda. Tente novamente");
                    }
                    else
                    {
                        MostrarOperacoesrealizadas(operacoesRealizadas);
                    }
                    Console.ReadLine();

                    Console.Clear();

                    continue;
                }
                // opçao sair
                if (EhOpcaoSair(opcao))
                {
                    break;
                }

                double primeiroNumero, segundoNumero;

                Console.Write("Digite o primeiro número: ");
                primeiroNumero = Convert.ToDouble(Console.ReadLine());

                do
                {
                    Console.Write("Digite o segundo número: ");
                    segundoNumero = Convert.ToDouble(Console.ReadLine());

                    if (opcao == "4" && segundoNumero == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Segundo número inválido! Tente novamente");

                        Console.ResetColor();

                        Console.ReadLine();
                    }

                } while (opcao == "4" && segundoNumero == 0);

                double resultado = 0;

                string simboloOperacao = "";

                switch (opcao)
                {
                    case "1":
                        resultado = primeiroNumero + segundoNumero;
                        simboloOperacao = "+";
                        break;

                    case "2":
                        resultado = primeiroNumero - segundoNumero;
                        simboloOperacao = "-";
                        break;

                    case "3":
                        resultado = primeiroNumero * segundoNumero;
                        simboloOperacao = "*";
                        break;

                    case "4":
                        resultado = primeiroNumero / segundoNumero;
                        simboloOperacao = "/";
                        break;




                    default:
                        break;
                }



                string operacaoRealizada =
                    primeiroNumero.ToString() + " " + simboloOperacao + " " +
                    segundoNumero.ToString() + " = " + resultado.ToString();

                operacoesRealizadas[contadorOperacoesrealizadas] = operacaoRealizada;

                contadorOperacoesrealizadas++;

                Console.WriteLine(resultado);

                Console.WriteLine();

                Console.WriteLine(operacaoRealizada);

                Console.ReadLine();

                Console.Clear();

            }
        }

        private static bool EhOpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static void MostrarOperacoesrealizadas(string[] operacoesRealizadas)
        {
            for (int i = 0; i < operacoesRealizadas.Length; i++)
            {
                if (operacoesRealizadas[i] != null)
                    Console.WriteLine(operacoesRealizadas[i]);
            }
        }

        private static bool EhOpcaoVisualizacao(string opcao)
        {
            return opcao == "5";
        }

        private static void MostrarMensagem(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();

            Console.Clear();
        }

        private static bool EhOpcaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3"
                                && opcao != "4" && opcao != "5"
                                && opcao != "S" && opcao != "s";
        }

        private static void MostarMenu()
        {
            Console.WriteLine("Calculadora Tabajara 1.7.1");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para somar");

            Console.WriteLine("Digite 2 para subtrair");

            Console.WriteLine("Digite 3 para multiplicação");

            Console.WriteLine("Digite 4 para divisão");

            Console.WriteLine("Digite 5 para visualizar as operações realizadas");

            Console.WriteLine("Digite S para sair");
        }
    }
}
