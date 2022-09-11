
public class Armadura
{
    public string nomeDaArmadura = "";
    /*A Proteçao sera levada em conta
    na hora do calculo do dano
    */
    public int protecao;
    public string descricaoDaArmadura = "";
    
    //Constructor para definir os atributos das armaduras com base no nome
    /*Conscedera cada nome, proteção e descrição, com base no nome que sera dado
    pela criação da classe!
    */
    public Armadura(string nome)
    {
        if (nome == "Armadura Leve")
        {
            this.nomeDaArmadura = "Armadura Leve";
            this.protecao = 10;
            this.descricaoDaArmadura = "Uma armadura leve para não atrapalhar os movimentos daqueles que procuram agilidade";
        }
        
        
        if (nome == "Armadura Media")
        {
            this.nomeDaArmadura = "Armadura Media";
            this.protecao = 15;
            this.descricaoDaArmadura = "Uma armadura media para aqueles que buscam um pouco de defesa adcional!";
        }
        
        if (nome == "Armadura Pesada")
        {
            this.nomeDaArmadura = "Armadura Media";
            this.protecao = 20;
            this.descricaoDaArmadura = "Uma armadura pesada para quem sempre esta la linha de frente das batalhas";
        }
        
    }

}
