using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionProduitsAPI.Models;
using GestionProduitsAPI.Services;

namespace GestionProduitsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduitsController : ControllerBase
    {
        private readonly ILogger<ProduitsController> _logger;
        private readonly IProduitsService _produitsService;

        public ProduitsController(ILogger<ProduitsController> logger, IProduitsService produitsService)
        {
            _logger = logger;
            _produitsService = produitsService;
        }


        [HttpGet]
        public async Task<Enumerable<Produit>> Get()
        {
            return await _produitsService.GetProduits();
        }

        [HttpGet("/id")]
        public async Task<ActionResult<Produit>> GetProduit(string id)
        {
            var produit = await_ produitsService.GetProduit(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

               [HttpPost]
        public async Task<ActionResult<Produit>> CreateProduit(Produit produit)
        {
            await _produitsService.CreateProduit(produit);

            return CreatedAtAction(nameof(GetProduit), new { id = produit.Id }, produit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduit(string id, Produit produitIn)
        {
            var produit = await _produitsService.GetProduit(id);

            if (produit == null)
            {
                return NotFound();
            }

            await _produitsService.UpdateProduit(id, produitIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(string id)
        {
            var produit = await _produitsService.GetProduit(id);

            if (produit == null)
            {
                return NotFound();
            }

            await _produitsService.DeleteProduit(produit.Id);

            return NoContent();
        }
    }
}
