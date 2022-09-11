
public class Inimigo
{
    public string nome = "";
    public int vida;
    public int dano;
    public int protecao;


    //Função "Atacar"
    /*
    Diminui a vida do player com base no dano do inimigo menos a
    proteção do player
    */
    public void Atacar(Player p)
    {
        p.vidaAtual -= this.dano - p.armaduraPlayer.protecao;
    }
}
