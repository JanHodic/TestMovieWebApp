﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestMovieWebApp.Server.Commons.Interfaces;

namespace TestMovieWebApp.Server.Presentations.Controllers
{
    /// <summary>
    ///     Files controller.
    /// </summary>
    [ApiController]
    [Route("files")]
    [Produces("application/json")]
    public class FileController
    {
        private readonly IFileReader _service;
        public FileController(IFileReader service)
        {
            _service = service;
        }

        public async Task<ICollection<object>> ReadFile()
        {
            var contents = await _service.ReadFile<object, object>();
            return contents;
        }
    }
}
