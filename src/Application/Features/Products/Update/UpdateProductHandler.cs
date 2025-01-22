using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;

namespace Application.Features.Products.Update;

public class UpdateProductHandler : BaseProductCommandHandler, IRequestHandler<UpdateProductCommand, Response<int>>
{
    public UpdateProductHandler(IProductRepositoryAsync repository, IMapper mapper)
        : base(repository, mapper)
    { 
    }

    public async Task<Response<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var productToUpdate = await _repository.GetByIdAsync(command.Id);
        if (productToUpdate == null) return new Response<int>("Product not found");

        if (productToUpdate.CreatedByUserId != command.RequestUserId) return new Response<int>("Not authorized");

        var validator = new UpdateProductCommandValidator(_repository);
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            var errors = new List<string>();
            foreach(var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }
            var response = Response<int>.FailiorResponse;
            response.Errors = errors;
            return response;
        }

        productToUpdate.Name = command.Name;
        productToUpdate.ProduceDate = command.ProduceDate;
        productToUpdate.ManufactureEmail = command.ManufactureEmail;
        productToUpdate.ManufacturePhone = command.ManufacturePhone;
        productToUpdate.IsAvailable = command.IsAvailable;

        await _repository.UpdateAsync(productToUpdate);
        return Response<int>.SuccessResponse;
    }
}
