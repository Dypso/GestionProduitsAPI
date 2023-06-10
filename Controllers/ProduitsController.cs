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
