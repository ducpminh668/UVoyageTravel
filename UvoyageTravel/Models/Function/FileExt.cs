﻿using System.ComponentModel.DataAnnotations;

namespace UvoyageTravel.Models.Function
{
    public class FileExt : ValidationAttribute
    {
        public string Allow;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string extension = ((System.Web.HttpPostedFileBase)value).FileName.Split('.')[1];
                if (Allow.Contains(extension))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(ErrorMessage);
            }
            else
                return ValidationResult.Success;
        }
    }
}