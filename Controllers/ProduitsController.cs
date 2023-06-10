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