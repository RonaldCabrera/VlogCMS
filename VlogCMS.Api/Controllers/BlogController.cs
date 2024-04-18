﻿using Microsoft.AspNetCore.Mvc;
using VlogCMS.Api.Models;
using VlogCMS.Api.Services;

namespace VlogCMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController(BlogService blogService) : Controller
{
    private readonly BlogService _blogService = blogService;

    [HttpGet]
    public async Task<IEnumerable<Blog>> Index()
    {
        try
        {
            return await _blogService.GetAllAsync();
        }
        catch
        {
            return [];
        }
    }

    [HttpGet("{id}")]
    public async Task<Blog?> Get(int id)
    {
        try
        {
            return await _blogService.GetByIdAsync(id);
        }
        catch
        {
            return null;
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Blog entity)
    {
        try
        {
            await _blogService.UpsertAsync(entity);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _blogService.RemoveByIdAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}