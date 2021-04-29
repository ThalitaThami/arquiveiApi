using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using arquivei_api.Context;
using arquivei_api.Models;
using arquivei_api.Services;

namespace arquivei_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NfesController : ControllerBase
    {
        private readonly ArquiveiContext _context;
        private ArquiveiService _arquiveiService;        

        public NfesController(ArquiveiContext context, ArquiveiService arquiveiService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _arquiveiService = arquiveiService ?? throw new ArgumentNullException(nameof(arquiveiService));
        }

        // GET: api/Nfes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nfe>>> GetNfes()
        {
            return await _context.Nfes.ToListAsync();
        }

        // GET: api/Nfes/accessKey
        [HttpGet("{accessKey}")]
        public async Task<ActionResult<string>> GetNfeAsync(string accessKey)
        {
            var nfe = await _arquiveiService.GetReceivedNFesByAccessKeyAsync(accessKey);

            if (nfe == null)
            {
                return NotFound(new {code = 404, message = "This register does not exist" });
            }

            return Ok(new { code = 200, message = nfe.Total });
        }
    }
}
