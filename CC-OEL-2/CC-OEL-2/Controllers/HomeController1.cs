using Microsoft.AspNetCore.Mvc;

namespace SensitiveDataDetection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly SensitivityCheckService _sensitivityCheckService;

        public CaseController(SensitivityCheckService sensitivityCheckService)
        {
            _sensitivityCheckService = sensitivityCheckService;
        }

        [HttpPost("check-sensitivity")]
        public ActionResult<SensitivityStatus> CheckCaseSensitivity([FromBody] CaseInputModel caseInput)
        {
            if (caseInput == null)
            {
                return BadRequest("Invalid input.");
            }

            var caseNumberStatus = _sensitivityCheckService.CheckFieldSensitivity("Case Number", caseInput.CaseNumber);
            var referenceStatus = _sensitivityCheckService.CheckFieldSensitivity("Investigation Reference", caseInput.InvestigationReference);
            var informantStatus = _sensitivityCheckService.CheckFieldSensitivity("Informant ID", caseInput.InformantId);

            return Ok(new
            {
                CaseNumberStatus = caseNumberStatus,
                ReferenceStatus = referenceStatus,
                InformantStatus = informantStatus
            });
        }
    }
}




   
