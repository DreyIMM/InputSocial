

using FluentValidation.Results;

namespace IPS.Core.Messages
{
    public class ResponseMessage : Message
    {
        //Alterar futuramente para ValidationResult, o tipo
        public bool ValidationResult { get; set; }

        public ResponseMessage(bool validationResult)
        {
            ValidationResult = validationResult;
        }

        public ResponseMessage()
        {
        }
    }
}
