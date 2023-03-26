using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CountriesController : ControllerBase
	{
		private readonly DataContext _context;

		public CountriesController(DataContext context)
		{
			_context = context;
		}

		[HttpPost("ExamplePost")]//Si quito el ("ExamplePost") no hay problema porque saldria en el URL /api/Countries y si no se quita
		//saldria /api/Countries/ExamplePost
        public async Task<ActionResult> PostAsync(Country country)
		{
			_context.Add(country);
			await _context.SaveChangesAsync();
			return Ok(country);
		}

		[HttpGet("ExampleGet")]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _context.countries.ToListAsync());
		}
	}
}

