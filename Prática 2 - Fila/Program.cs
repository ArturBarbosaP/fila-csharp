using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prática_2___Fila
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fila pedido = new Fila(100);
            Fila pagamento = new Fila(100);
            Fila encomenda = new Fila(100);
            int cod = 1, val = 0;

            while (val != 5)
            {
                Console.WriteLine("Menu");
                Console.Write("1 - Inserção de cliente na fila de pedidos\n" +
                    "2 - Remoção de cliente da fila de pedidos\n" +
                    "3 - Remoção de cliente da fila de pagamentos\n" +
                    "4 - Remoção de cliente da fila de encomendas\n" +
                    "5 - Sair: ");
                try
                {
                    val = Convert.ToInt32(Console.ReadLine());

                    switch (val)
                    {
                        case 1:
                            if (!pedido.Cheia())
                            {
                                pedido.Enfileirar(cod);
                                Console.WriteLine("\nCliente " + cod + " entrou na fila de pedidos.\n");
                                cod++;
                            }
                            else
                                Console.WriteLine("\nA fila está cheia!\n");

                            break;

                        case 2:
                            if (!pedido.Vazia())
                            {
                                int clienteP = pedido.Desenfileirar();

                                if (!pagamento.Cheia())
                                {
                                    pagamento.Enfileirar(clienteP);
                                    Console.WriteLine("\nCliente " + clienteP + " saiu da fila de pedidos e entrou na fila de pagamentos.\n");
                                }
                                else
                                    Console.WriteLine("\nA fila está cheia!\n");
                            }
                            else
                                Console.WriteLine("\nA fila está vazia!\n");

                            break;

                        case 3:
                            if (!pagamento.Vazia())
                            {
                                int clienteA = pagamento.Desenfileirar();

                                if (!encomenda.Cheia())
                                {
                                    encomenda.Enfileirar(clienteA);
                                    Console.WriteLine("\nCliente " + clienteA + " saiu da fila de pagamentos e entrou na fila de encomendas.\n");
                                }
                                else
                                    Console.WriteLine("\nA fila está cheia!\n");
                            }
                            else
                                Console.WriteLine("\nA fila está vazia!\n");

                            break;

                        case 4:
                            if (!encomenda.Vazia())
                            {
                                int clienteE = encomenda.Desenfileirar();
                                Console.WriteLine("\nCliente " + clienteE + " saiu da loja.\n");
                            }
                            else
                                Console.WriteLine("\nA fila está vazia!\n");

                            break;

                        default:
                            Console.WriteLine("\n");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nDigite apenas números!\n");
                }
            }
        }
    }
}