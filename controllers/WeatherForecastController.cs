using Microsoft.AspNetCore.Mvc; //importa a biblioteca 
//essencial para usar ApiController e Route

[ApiController] //indica que essa classe será o cotrolador da API
[Route("[controller]")] //Rota para o usuario usar a API
public class WeatherForecastController : ControllerBase //Definição de uma classe principal. WeatherForecastController - nome da classe. ControllerBase - classe especial do .NET
{
    [HttpGet] //este método será usado quando alguém quiser pegar informações da API
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
}
