
using HealthSchedule.Domain;
using HealthSchedule.Domain.Entities.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace HealthSchedule.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService) 
        => _patientService = patientService;

    [HttpPost]
    [Route("Create")]
    public IActionResult Post ([FromBody] Patient patient)
    {
        _patientService.Insert(patient);
        return Ok(); 
    }

    [HttpGet]
    [Route("GetPacientByCpf/{cpf}")]
    public async Task<ActionResult<Patient>> GetPacientByCpf (string cpf)
    {
        var result = await _patientService.GetPacientByCpf(cpf);
        return result;
    }

    [HttpPut]
    [Route("Update")]
    public IActionResult Update ([FromBody]Patient patient)
    {
        _patientService.Update(patient);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public IActionResult Delete ([FromBody]string cpf)
    {
        _patientService.Delete(cpf);
        return Ok(); 
    }
}