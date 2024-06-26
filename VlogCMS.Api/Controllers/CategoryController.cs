﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(
    CategoryService categoryService,
    UserManager<IdentityUser> userManager) : BaseController(userManager)
{
    private readonly CategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<IEnumerable<Category>> Index()
    {
        try
        {
            return await _categoryService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<Category?> Get(int id)
    {
        try
        {
            return await _categoryService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] Category entity)
    {
        try
        {
            await _categoryService.UpsertAsync(entity);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Delete/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
