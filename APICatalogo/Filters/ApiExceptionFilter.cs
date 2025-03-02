﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
                _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError("######################################");
            _logger.LogError("Ocorreu uma exceção não tratada: Status Code 500.");
            _logger.LogError("######################################");

            context.Result = new ObjectResult("Ocorreu um problema ao tratar sua solicitaçã: Status Code 500.")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
