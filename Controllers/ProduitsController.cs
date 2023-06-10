using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Core.Mvc;
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