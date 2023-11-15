namespace Teste1.Configurations
{
    public static class Appsettings
    {
        //Esse método foi criado para dizer qual chave deve ser consultada no arquivo appsettings.json que
        // está localizado logo abaixo da pasta views. facilitar a alteração da string de conexão
        // sem precisar recompilar o código.
        public static string getKeyConnectionString()
        {
            return "DefaultConnection";
        }
    }
}
