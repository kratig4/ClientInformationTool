using ClientInformationServices.Services;
using ClientInformationServices.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace ClientInformationTool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientInformationController : ControllerBase
    {

        private readonly IAudioToTextService _audioToTextService;
        private readonly IPdfToText _pdfToText;
        private readonly IImageToText _imageToText;

        public ClientInformationController(IAudioToTextService audioToTextService, IPdfToText pdfToText, IImageToText imageToText)
        {
            _audioToTextService = audioToTextService;
            _pdfToText = pdfToText;
            _imageToText = imageToText;
        }

        [HttpGet("{filePath}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClientInformation([FromRoute] string filePath)
        {
            try
            {

                 _audioToTextService.call(filePath);
                // _pdfToText.ExtractTextFromPdf();
                // _imageToText.call();


            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}