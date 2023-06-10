using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionProduitsAPI.Models;

namespace GestionProduitsAPI.Services
{
    public interface IProduitsService
    {
        Task<Enumerable<String>> GetProduits();
        Task<Produit> GetProduit(String id);
        Task CreateProduit(Produit produit);
        Task UpdateProduit(String id, Produit produit);
        Task DeleteProduit(String id);
    }
}