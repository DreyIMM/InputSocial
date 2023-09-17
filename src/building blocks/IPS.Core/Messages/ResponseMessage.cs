using FluentValidation.Results;

namespace IPS.Core.Messages
{
    public class ResponseMessage : Message
    {
        //Alterar futuramente para ValidationResult, o tipo
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
