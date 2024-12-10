
namespace MinhaPrimeiraApi.Entities
{
    public class Contatos
    {
        public int Id {get; set;} // Identificador único da tabela
        public string Nome {get; set;}
        public string Telefone {get; set;}
        public bool Ativo {get;set;} //Representa se o contato está ativo ou inativo no sistema 
    }
}