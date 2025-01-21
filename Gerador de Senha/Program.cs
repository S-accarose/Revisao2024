using System.Runtime.InteropServices;
using System.IO;

using (StreamWriter escrever = new StreamWriter("MinhaNova-Senha.txt"))
{
    char[] abc = new char[52] 
    {
        'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 
        'g', 'G', 'h', 'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 
        'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P', 'q', 'Q', 'r', 'R', 
        's', 'S', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 
        'y', 'Y', 'z', 'Z'
    };

    char[] cesp = new char[6]{'!', '@', '$', '%', '&', '*'};

    Random random = new Random();

    var senha = new System.Text.StringBuilder();

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write("Bem vindo ao gerador de senhas!");
    Thread.Sleep(2000);
    Console.Clear();
    quest1:
    Console.Write("Em quantos dígitos deseja gerar a sua nova senha? ");
    if(!int.TryParse(Console.ReadLine(), out int numcarac) && numcarac >= 6)
    {
        Console.Clear();
        Thread.Sleep(2000);
        Console.Write("O valor precisa ser um número, de valor mínimo 6.");
        goto quest1;
    }

    quest2:
    Console.Write("Deseja letras em sua nova senha? (s) ou (n) > ");
    if(!char.TryParse(Console.ReadLine()?? "n", out char SouN))
    {
        Console.Clear();
        Thread.Sleep(2000);
        Console.Write("Insira o que foi pedido.");
        goto quest2;
    }

    quest3:
    Console.Write("Deseja caracteres especiais em sua nova senha? (s) ou (n) > ");
    if(!char.TryParse(Console.ReadLine()?? "n", out char SouN2))
    {
        Console.Clear();
        Thread.Sleep(2000);
        Console.Write("Insira o que foi pedido.");
        goto quest3;
    }

    Console.Write("Sua senha está sendo gerada!/n");

    if (SouN == 's')
    {
        senha.Append(abc[random.Next(0, abc.Length)]);
        numcarac--;
    }

    if (SouN2 == 's')
    {
        senha.Append(cesp[random.Next(0, cesp.Length)]);
        numcarac--;
    }

    for (int i = 0; i < numcarac; i++)
    {
        int escolha = random.Next(0, 3);

        if (escolha == 0)
        {
            senha.Append(random.Next(0, 10));
        }
        else if (escolha == 1 && SouN == 's')
        {
            senha.Append(abc[random.Next(0, abc.Length)]);
        }
        else if (escolha == 2 && SouN2 == 's')
        {
            senha.Append(cesp[random.Next(0, cesp.Length)]);
        }
        else
        {
            i--;
        }
    }

    char[] senhaArray = senha.ToString().ToCharArray();
    for (int i = senhaArray.Length - 1; i > 0; i--)
    {
        int j = random.Next(0, i + 1);
        char temp = senhaArray[i];
        senhaArray[i] = senhaArray[j];
        senhaArray[j] = temp;
    }

    string senhaFinal = new string(senhaArray);

    Console.Clear();
    Console.ResetColor();

    for(int index = 1; index < 5; index ++)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("Gerando.");
        Thread.Sleep(500);
        Console.Clear();
        Console.Write("Gerando..");
        Thread.Sleep(500);
        Console.Clear();
        Console.Write("Gerando...");
        Thread.Sleep(500);
        Console.Clear();
    }

    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Sua nova senha é : {senhaFinal}");
    escrever.WriteLine($"Sua nova senha é : {senhaFinal}");
    Console.ResetColor();
}