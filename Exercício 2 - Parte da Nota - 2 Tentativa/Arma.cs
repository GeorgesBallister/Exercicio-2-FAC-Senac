

public class Arma : Player
{
    //Nome da arma
    public string nomeDaArma = "";
    public int dano;

//Onde sera armazenado as descrição de cada arma
    public string descricaoDaArma = "";


    //Constructor para definir os atributos das armas com base no nome
    /*Conscedera cada nome, dano e descrição com base no nome que sera dado
    pela criação da classe!
    */
    public Arma(string nome)
    {
        if (nome == "Cajado")
        {
            this.nomeDaArma = "Cajado";
            this.dano = (new Random().Next(19, 35));
            this.descricaoDaArma = "Cajado para os bruxão que se arrisca nos feitiços!";
        }
        if (nome == "Espada")
        {
            this.nomeDaArma = "Espada";
            this.dano = (new Random().Next(25, 28));
            this.descricaoDaArma = "Espada pra quem acha que magia é coisa de quem não se garante na porrada";
        }

        if (nome == "Arco")
        {
            this.nomeDaArma = "Arco";
            this.dano = (new Random().Next(10, 25));
            this.descricaoDaArma = "Arco para quem gosta de dar headshot";
        }

    }
    //Função "Atacar"
    /*
    -Calcula a taxa de critico com base na classe do personagem
    -Valida a taxa de critico para calcular o dano do ataque
    -Reduz a vida do inimigo com base no dano do ataque
    */
    public void Atacar(Player p, Inimigo i)
    {
        //Calcular Criticos
        if (p.classe.nomeDaClasse == "Arqueiro")
        {
            p.critcTax = new Random().Next(30, 100);
        }
        else if (p.classe.nomeDaClasse == "Mago Implacavel")
        {
            p.critcTax = new Random().Next(10, 100);
        }

        //Validar o tamnaho do critico
        if (p.critcTax >= 50)
        {
            this.dano *= 2;
        }

        //Dar o Dano
        if(i.protecao > this.dano){
            Console.WriteLine("Não surtiu efeito!");
        }
        else{
            i.vida -= this.dano - i.protecao;
        }
        
    }

}

