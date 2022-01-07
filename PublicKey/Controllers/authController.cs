using lda_PublicKey.Application.Contracts;
using lda_PublicKey.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace lda_PublicKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        #region Properties
        private readonly IPublicKey _iPublicKey;


        #endregion

        #region Builders
        public authController(IPublicKey iPublicKey)
        {
            _iPublicKey = iPublicKey;
        }
        #endregion

        #region Methods
        [HttpGet("token/public-key")]
        public async Task<IActionResult> PublicKey()
        {
            try
            {
                ResultPublyKeyResponseMode response = await _iPublicKey.PostPublicKey();
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                ResultPublyKeyResponseMode response = new ResultPublyKeyResponseMode() { status = "ERROR", data = ex.Message.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, response );
            }

        }
        #endregion
    }
}
