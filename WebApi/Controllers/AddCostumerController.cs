﻿using Domain.Contracts.UseCases.AddCustomer;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;
using WebApi.Models.Error;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCostumerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCase;
        private readonly IValidator<AddCustomerInput> _addCustomerInputValidator;
        public AddCostumerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> addCustomerInputValidator)
        {
            _addCustomerUseCase = addCustomerUseCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }

        [HttpPost]
        public IActionResult AddCustomer (AddCustomerInput input)
        {
            var validateResult = _addCustomerInputValidator.Validate(input);

            if(!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors.ToCustomValidationFailure());
            }

            var customer = new Customer(input.Name, input.Email, input.Document);

            _addCustomerUseCase.AddCustomer(customer);

            return Created("", customer);
        }
    }
}
