// ***********************************************************************
// Assembly         : SaraCms.Models
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="Validation.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Models
{
    using validationCodes = Enumerations.ValidationCodes;

    public class Validation
    {
        public bool IsValid { get; set; }
        
        public string Message { get; set; }
        
        public validationCodes Code { get; set; }
        
        public static Validation GetSuccessValidation(string message = "")
        {
            return new Validation { IsValid = true, Message = message, Code = validationCodes.Success };
        }
    }
}
