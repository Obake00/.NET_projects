using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> loto = Enumerable.Range(0, 61).ToList();
        Random random = new Random();

        Console.WriteLine(new string('~', 10));
        Console.WriteLine("MEGA SENA");
        Console.WriteLine(new string('~', 10));

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção abaixo:");
            Console.WriteLine("[1] -> JOGO SIMPLES");
            Console.WriteLine("[2] -> VARIOS JOGOS");
            Console.WriteLine("[3] -> SAIR");
            Console.Write(": ");

            if (!int.TryParse(Console.ReadLine(), out int resp))
            {
                Console.WriteLine("Entrada inválida!");
                continue;
            }

            if (resp == 1)
            {
                Embaralhar(loto, random);
                var jogo = loto.Take(6).OrderBy(x => x).ToList();
                Console.WriteLine($"\n\nJOGO >>> {string.Join(", ", jogo)}");
            }

            else if (resp == 2)
            {
                Console.Write("Quantos jogos deseja sortear?: \n\n");
                if (int.TryParse(Console.ReadLine(), out int totJogos))
                {
                    for (int n = 0; n < totJogos; n++)
                    {
                        Embaralhar(loto, random);
                        var jogo = loto.Take(6).OrderBy(x => x).ToList();
                        Console.WriteLine("JOGO >>> " + string.Join(", ", jogo));
                    }
                }
            }

            else if (resp == 3)
            {
                break;
            }

            else
            {
                Console.WriteLine($"{resp} NÃO É UMA ENTRADA VÁLIDA!");
            }
        }

        Console.WriteLine("\nOBRIGADO!!!");
    }

    static void Embaralhar(List<int> lista, Random random)
    {
        int n = lista.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            int value = lista[k];
            lista[k] = lista[n];
            lista[n] = value;
        }
    }
}