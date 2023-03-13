using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[Route("api/owner")]
[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repository;

    public OwnerController(ILoggerManager logger,IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllOwners(){
        try{
            var owners = _repository.Owner.GetAllOwners();
            _logger.LogInfo($"Retornando todos os owners do banco de dados.");
            return Ok(owners);
        }
        catch(Exception ex){
            _logger.LogError($"Ocorreu um erro no método GetAllOwners: {ex.Message}");
            return StatusCode(500,"Err Interno do Servidor");
        }
    }
}
