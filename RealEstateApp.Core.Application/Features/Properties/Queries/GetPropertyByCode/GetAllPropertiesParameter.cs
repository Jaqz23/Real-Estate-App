using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;


namespace RealEstateApp.Core.Application.Features.Properties.Queries.GetPropertyByCode
{
    /// <summary>
    /// Parámetros para filtrar los tipos de propiedades
    /// </summary>  
    public class GetAllPropertiesParameter
    {
        /// <example>1</example>
        [SwaggerParameter(Description = "Colocar el codigo de la propiedad por la cual quiere filtrar")]
        [DefaultValue("1")]
        public int PropertyCode { get; set; }
    }
}
