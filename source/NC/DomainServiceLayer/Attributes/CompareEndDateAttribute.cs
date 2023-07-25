using System.ComponentModel.DataAnnotations;
using Common.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace ServiceLayer.Attributes;

public class CompareEndDateAttribute : ValidationAttribute
{
    private readonly string _endDateTimeProperty;

    public CompareEndDateAttribute(string endDate)
    {
        _endDateTimeProperty = endDate;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var otherProperty = validationContext.ObjectType.GetProperty(_endDateTimeProperty);
        var otherValue = otherProperty!.GetValue(validationContext.ObjectInstance);

        if (otherValue is null)
        {
            return ValidationResult.Success;
        }

        if (value is DateTime startDateTime && otherValue is DateTime endDateTime)
        {
            if (endDateTime > startDateTime)
            {
                return ValidationResult.Success;
            }
        }

        var localizer = validationContext.GetRequiredService<IStringLocalizer<CompareEndDateAttribute>>();

        return new ValidationResult(localizer[ErrorMessageConst.Start_Date_Must_Be_Before_To_End_Date]);
    }

}