namespace PointBlank___Machine
{
    public class Classe_Raiz
    {
        public bool flag = false, announce = true, Robô = false, BotLogin = false, guia = false, sussurro = false, chatflood = false;
        public string[] sussuro;
        public int Contas, PadraoRegion, PadraoClient = 0;
        static readonly Classe_Raiz INSTANCE = new Classe_Raiz();
        public static Classe_Raiz INTs() => INSTANCE;
    }
}
