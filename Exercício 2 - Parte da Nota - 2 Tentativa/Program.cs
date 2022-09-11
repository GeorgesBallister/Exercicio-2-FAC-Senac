//MiniRPG by Georges Ballister de Oliveira
//Tempo total desse codigo (4:02 horas)

//Bibliotecas do Sistema
using System;

//----------------------------------------------------------------
//Ideia do Programa
/*
Criar um miniRPG com:
-Sistema aleatorio de inimigos
-Sistema de itens

(opcional)
-Itens ultilizaveis
-Sistema de progressão primitivo
-Sistema de inventario
*/
//----------------------------------------------------------------
//Regras do Programa
Console.Clear(); //Para o programa iniciar sem as mensagem em amarelo

//----------------------------------------------------------------
//Variaveis do Programa
/* Variavel "opcao" sera para opções*/
int opcao = 0;
int onOffMenu = 0;
int opcaoMenu = 0;
int opcaoLuta = 0;
int chanseDeFugir = 0;
int orcsMortos = 0;

//----------------------------------------------------------------
//Instacia do player
Player player = new Player();
player.classe = new ClassePlayer();

//----------------------------------------------------------------

//Mensagem Inicial
Console.WriteLine("Ola jogador, você esta em Forggoten Realms");
Console.WriteLine("Um MiniRPG simples e divertido para passar o tempo");
Console.WriteLine($"");
Console.WriteLine("Pressione ENTER para continuar...");
Console.ReadLine();

//Dando nome ao Personagem
int nomeDoPlayer = 0;
while (nomeDoPlayer == 0)
{
    //Reiniciara
    /*
    -Caso o jogador não escrever nada como nome.
    -Caso ele deseje mudar o nome.
    */
    Console.Clear();
    Console.Write("Digite seu nome: ");
    player.nome = Console.ReadLine();

    //GoTo "inicio" caso o jogador não escrever nada como nome!
    if (player.nome == "")
    {
        Console.Clear();
        Console.WriteLine("Opcao invalida de nome");
        Console.WriteLine("Tente novemente");
        Console.WriteLine("");
    }
    Console.Clear();

    //GoTo "inicioCriacaoDePersonagemNome" caso o jogador queira mudar o nome do personagem no inicio
    Console.WriteLine($"Seu nome é {player.nome}");
    Console.WriteLine("Esta correto?");
    Console.WriteLine("(1 - para SIM ou 0 - para NÃO)");
    nomeDoPlayer = int.Parse(Console.ReadLine());

}
//Limpar textos
Console.Clear();

//Criando a Classe
int criandoClasse = 0;
while (criandoClasse == 0)
{

    //Perguntar qual a classe do personagem
    Console.WriteLine("Qual sua classe?");
    Console.WriteLine("1 - Mago Implacavel");
    Console.WriteLine("2 - Berserker");
    Console.WriteLine("3 - Arqueiro");
    string opcaoClasse = Console.ReadLine();

    if (opcaoClasse == "1")
    {
        player.classe.nomeDaClasse = "Mago Implacavel";
        player.classe.descricaoDaClasse = "O Mago Implacavel, é um mago, que é implacavel e usa magias!";
        player.vidaMax = 50;
        player.vidaAtual = 50;
        player.armaPlayer = new Arma("Cajado");
        player.armaduraPlayer = new Armadura("Armadura Media");
        criandoClasse++;
    }
    else if (opcaoClasse == "2")
    {
        player.classe.nomeDaClasse = "Berserker";
        player.classe.descricaoDaClasse = "O Berserker, é um guerreiro que não acredita muito nesse negocio ne magia!";
        player.vidaMax = 80;
        player.vidaAtual = 80;
        player.armaPlayer = new Arma("Espada");
        player.armaduraPlayer = new Armadura("Armadura Pesada");
        criandoClasse++;
    }
    else if (opcaoClasse == "3")
    {
        player.classe.nomeDaClasse = "Arqueiro";
        player.classe.descricaoDaClasse = "O Arqueiro, usa um arco e tem uma taxa maior de critico!";
        player.vidaMax = 40;
        player.vidaAtual = 40;
        player.armaPlayer = new Arma("Arco");
        player.armaduraPlayer = new Armadura("Armadura Leve");
        criandoClasse++;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Opcao invalida");
        Console.WriteLine("Tente novamente");
        Console.WriteLine("");
    }


}

//Menu do jogo
while (onOffMenu == 0)
{
    //Mensagem sobre o jogo!
    Console.Clear();
    Console.WriteLine("-----Menu do jogo-----");
    Console.WriteLine("1 - Lutar");
    Console.WriteLine("2 - Status");
    Console.WriteLine("3 - Historia");
    Console.WriteLine("4 - Dormir");
    Console.WriteLine("5 - Sair");
    Console.WriteLine("");
    Console.Write($"Escolha sua opção: ");
    opcaoMenu = int.Parse(Console.ReadLine());

    switch (opcaoMenu)
    {
        //1 - Lutar
        case 1:
            Console.Clear();

            //Instancia de inimigo
            Inimigo inimigo = new Inimigo();
            inimigo.nome = "Orc";
            inimigo.vida = new Random().Next(7, 40);
            inimigo.protecao = new Random().Next(8, 20);

            //Mensaguem inicial assim que entrar em uma luta
            Console.WriteLine($"Você avista um {inimigo.nome} a sua frente");

        //GoTo "inicioLuta"
        /*
        -Caso o jogador não selecionar opções existentes
        -Caso a tentativa de fugir seja em vão
        */
        inicioLuta:
            Console.WriteLine($"Sua vida: {player.vidaAtual}");
            Console.WriteLine($"Proteção: {player.armaduraPlayer.protecao}");
            Console.WriteLine($"");
            Console.WriteLine($"Vida do Inimigo: {inimigo.vida}");
            Console.WriteLine($"Proteção do Inimigo: {inimigo.protecao}");

            //Menu da Batalha
            Console.WriteLine($"1 - Atacar");
            Console.WriteLine($"2 - Fugir");
            Console.Write($"Sua opção: ");
            opcaoLuta = int.Parse(Console.ReadLine());

            //Atacar
            if (opcaoLuta == 1)
            {
                player.armaPlayer.Atacar(player, inimigo);
                inimigo.Atacar(player);
            }
            //Fugir
            /*
            -Executara um teste randomico para determinar se
            o jogador conseguiu fugir
            */
            else if (opcaoLuta == 2)
            {
                chanseDeFugir = new Random().Next(0, 10);

                //NÃO Conseguiu fugir
                if (chanseDeFugir < 4)
                {
                    Console.WriteLine("Sua tentativa de Fuga foi em vão!");
                    Console.WriteLine($"");
                    goto inicioLuta;
                }
                //Conseguiu fugir
                else
                {
                    Console.WriteLine($"Voce conseguiu Fugir!");
                    Console.WriteLine($"");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();

                }
            }
            //Caso o Jogador digite uma opção invalida
            else
            {
                Console.WriteLine($"Opcao invalida Tente novamente!");
                Console.WriteLine($"");
                goto inicioLuta;
            }

            //Caso a vida do inimigo chegue a Zero
            if (inimigo.vida < 1)
            {
                Console.WriteLine($"Você Matou: {inimigo.nome}");
                orcsMortos++;
                Console.WriteLine($"");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

            }
            //Caso o inimigo ainda não tenha Morrido
            else
            {
                Console.Clear();
                goto inicioLuta;
            }



            break;

        //2 - Status
        /*
        O Status sequencia em cadeia tudo que o jogador
        prescisa saber sobre o player.
        */
        case 2:
            Console.Clear();
            Console.WriteLine($"-----{player.nome} Status-----");
            Console.WriteLine($"Vida: {player.vidaAtual}");
            Console.WriteLine($"Classe: {player.classe.nomeDaClasse}");
            Console.WriteLine($"Descrição da Classe: {player.classe.descricaoDaClasse}");
            Console.WriteLine($"-----Equipamentos-----");
            Console.WriteLine($"Armadura: {player.armaduraPlayer.nomeDaArmadura}");
            Console.WriteLine($"Proteção: {player.armaduraPlayer.protecao}");
            Console.WriteLine($"Descrição da armadura: {player.armaduraPlayer.descricaoDaArmadura}");
            Console.WriteLine($"---------Arma---------");
            Console.WriteLine($"Arma principal: {player.armaPlayer.nomeDaArma}");
            Console.WriteLine($"Dano da arma: {player.armaPlayer.dano}");
            Console.WriteLine($"Descrição da Arma principal: {player.armaPlayer.descricaoDaArma}");
            Console.WriteLine($"");
            Console.WriteLine($"-----Estatisticas-----");
            Console.WriteLine($"Você matou: {orcsMortos} orcs");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();


            break;

        //3 - Historia
        case 3:
        Console.Clear();
            Console.WriteLine($"ALA KK O CARA ACHA QUE TEM HISTONHA KVNSKDJLKL VAI JOGAR MAN!");
            Console.WriteLine($"");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        //4 - Dormir
        case 4:
            Console.Clear();
            Console.WriteLine("Em pastos verdejantes, obscurecidos pelo abraço da escurodão da noite");
            Console.WriteLine($"O beijo da Lua adentra seu ser...");
            Console.WriteLine($"Você dormiu!");
            Console.WriteLine($"Sua vida Encheu!");
            player.vidaAtual = player.vidaMax;
            Console.WriteLine($"");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        //5 - Sair
        case 5:
            onOffMenu = 1;
            break;

        //Caso coloque qualquer outra função que não esteja no menu
        default:
            Console.WriteLine("Comando invalido");
            Console.WriteLine("Tente novamente");
            Console.WriteLine("");
            break;

    }

}
//Mensagem de final
Console.WriteLine($"Você matou: {orcsMortos} orcs");
Console.WriteLine($"");
Console.WriteLine($"Obrigado Por jogar esse mini Projetinho da minha Faculdade");
Console.WriteLine($"Codigo escrito por Georges Ballister \"Wojak\" de Oliveira");