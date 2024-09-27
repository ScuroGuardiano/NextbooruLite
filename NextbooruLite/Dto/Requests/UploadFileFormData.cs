using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace NextbooruLite.Dto.Requests;

public class UploadFileFormData
{
    [Required]
    public required IFormFile File { get; set; }
    
    /// <summary>
    /// Space separated tag list. I am doing file upload as form so to make it easier on frontend I'll just pass tags space separated.
    /// </summary>
    [Required]
    public required string Tags { get; set; }
    
    public string? Title { get; set; }
    
    public string? Source { get; set; }
    
    public bool Public { get; set; }

    public class UploadFileFormDataValidator : AbstractValidator<UploadFileFormData>
    {
        public UploadFileFormDataValidator()
        {
            RuleFor(x => x.File).NotNull();
            // No other tags validations here, it will be done by the parser.
            RuleFor(x => x.Tags).MaximumLength(4096).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(128);
            RuleFor(x => x.Source).MaximumLength(2048);
        }
    }
}