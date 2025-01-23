using FluentValidation;
using Application.Interfaces;

namespace Application.Features.Products.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    private readonly IProductRepositoryAsync _repository;
    public UpdateProductCommandValidator(IProductRepositoryAsync repository)
    {
        _repository = repository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} max length is 100 characters");

        RuleFor(p => p.ProduceDate)
            .NotNull()
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("{PropertyName} must be in the past or now");

        RuleFor(p => p.ManufactureEmail)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(p => p.ManufacturePhone)
            .NotEmpty().WithMessage("{ProertyName} is required")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} maximum length is 20 characters");

        RuleFor(p => p.IsAvailable)
            .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(p => p)
            .MustAsync(IsUnique).WithMessage("Product must be unique by the combination of Name and ProduceDate");
    }

    private async Task<bool> IsUnique(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        return await _repository.IsUniqueAsync(command.Name, command.ProduceDate, command.Id);
    }
}
