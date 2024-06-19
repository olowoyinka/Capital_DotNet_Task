using DynamicApplication.Service.DTOs.Requests;
using DynamicApplication.Service.DTOs.Responses;
using DynamicApplication.Service.Interfaces;
using DynamicApplication.Service.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DynamicApplication.API.Controllers
{
    [ApiController]
    [Route("application")]
    public class ApplicationProgramController : ControllerBase
    {
        private readonly IApplicationProgramService _applicationProgramService;

        public ApplicationProgramController(IApplicationProgramService applicationProgramService)
        {
            _applicationProgramService = applicationProgramService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(DataResponseDTO<List<ApplicationProgramMiniResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _applicationProgramService.AllGetApplicationProgram();

                if (result?.Error?.Code == HttpStatusCode.BadRequest)
                    return BadRequest(result?.Error);

                if (result?.Error?.Code == HttpStatusCode.NotFound)
                    return BadRequest(result?.Error);

                return Ok(result?.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = HttpStatusCode.BadRequest, message = AppConstants.ERRORMESSAGE });
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(DataResponseDTO<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] ApplicationProgramRequestDTO model)
        {
            try
            {
                var result = await _applicationProgramService.CreateApplicationProgram(model);

                if (result?.Error?.Code == HttpStatusCode.BadRequest)
                    return BadRequest(result?.Error);

                if (result?.Error?.Code == HttpStatusCode.NotFound)
                    return BadRequest(result?.Error);

                return Ok(result?.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = HttpStatusCode.BadRequest, message = ex.Message });
            }
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponseDTO<ApplicationProgramResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            try
            {
                var result = await _applicationProgramService.GetApplicationProgramById(Id);

                if (result?.Error?.Code == HttpStatusCode.BadRequest)
                    return BadRequest(result?.Error);

                if (result?.Error?.Code == HttpStatusCode.NotFound)
                    return BadRequest(result?.Error);

                return Ok(result?.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = HttpStatusCode.BadRequest, message = AppConstants.ERRORMESSAGE });
            }
        }


        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponseDTO<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] ApplicationProgramRequestDTO model)
        {
            try
            {
                var result = await _applicationProgramService.UpdateApplicationProgram(Id, model);

                if (result?.Error?.Code == HttpStatusCode.BadRequest)
                    return BadRequest(result?.Error);

                if (result?.Error?.Code == HttpStatusCode.NotFound)
                    return BadRequest(result?.Error);

                return Ok(result?.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = HttpStatusCode.BadRequest, message = AppConstants.ERRORMESSAGE });
            }
        }


        [HttpPost("user")]
        [ProducesResponseType(typeof(DataResponseDTO<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Submit([FromBody] UserApplicationProgramRequestDTO model) 
        {
            try
            {
                var result = await _applicationProgramService.CreateUserApplicationProgram(model);

                if (result?.Error?.Code == HttpStatusCode.BadRequest)
                    return BadRequest(result?.Error);

                if (result?.Error?.Code == HttpStatusCode.NotFound)
                    return BadRequest(result?.Error);

                return Ok(result?.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = HttpStatusCode.BadRequest, message = ex.Message });
            }
        }
    }
}