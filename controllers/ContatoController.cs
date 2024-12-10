using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.context;
using MinhaPrimeiraApi.Entities;

[ApiController]
[Route("[controller]")]

public class ContatoController : ControllerBase
{
    private readonly AgendaContext _context;
    public ContatoController(AgendaContext context)
    {
        _context = context;
    }

    /* [HttpPost]
    public IActionResult Create(Contatos contato)
    {
        _context.Add(contato); // Adiciona o contato ao banco
        _context.SaveChanges(); // Salva as mudanças no banco
        return Ok(contato); // Retorna o contato criado
    }*/

    //Melharando o create
    [HttpPost]
    public IActionResult Create(Contatos contato)
    {
        _context.Add(contato);
        _context.SaveChanges();

        // Retorna o caminho do novo recurso criado
        return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
    }


    // Novo método para buscar um contato pelo ID
    [HttpGet("{id}")] // Define a rota com um parâmetro "id"
    public IActionResult ObterPorId(int id)
    {
        var contato = _context.Contatos.Find(id); // Busca o contato no banco pelo ID
        if (contato == null)
            return NotFound();  // Retorna um erro 404 (Não Encontrado)

        return Ok(contato); // Retorna o contato encontrado
    }

    [HttpPut("{id}")] // Define a rota com um parâmetro "id"

    public IActionResult Atualizar(int id, Contatos contato)
    {
        var contatoBanco = _context.Contatos.Find(id); // Busca o contato no banco pelo ID

        if (contatoBanco == null) // Verifica se o contato existe
            return NotFound(); // Retorna erro 404 (Não Encontrado)

        // Atualiza os dados do contato
        contatoBanco.Nome = contato.Nome;
        contatoBanco.Telefone = contato.Telefone;
        contatoBanco.Ativo = contato.Ativo;

        // Aplica as alterações no banco de dados
        _context.Contatos.Update(contatoBanco);
        _context.SaveChanges();

        return Ok(contatoBanco); // Retorna o contato atualizado
    }

    [HttpDelete("{id}")]

    public IActionResult Deletar(int id)
    {
        var contatoBanco = _context.Contatos.Find(id);

        if (contatoBanco == null)
            return NotFound();

        _context.Contatos.Remove(contatoBanco); // Remove o contato do banco
        _context.SaveChanges(); // Salva as alterações


        return NoContent(); // Retorna 204 (No Content)
    }

    [HttpGet("ObterPorNome")]
    public IActionResult ObterPorNome(string nome)
    {
        var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome)).ToList(); // Busca contatos com o nome que contém o termo informado
        if (contatos == null)
            return NotFound();


        return Ok(contatos); // Retorna a lista de contatos encontrados
    }




}


