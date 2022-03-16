using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHNICAL.MODELS;

namespace TECHNICAL.BUSINESS.Services.TypeService
{
    public interface ITypeService
    {
        /// <summary>
        /// Get a list of types from json file
        /// </summary>
        public ResponseTypesModel GetTypes();
        /// <summary>
        /// Create a new type 
        /// </summary>
        /// <param name="entity">Standar model for type of person.</param>
        public ResponseTypesModel Create(TypeModel entity);
        /// <summary>
        /// Validate if exist the TypeModel   
        /// </summary>
        /// <param name="entity">Standar model for type of person.</param>
        public ResponseTypesModel Validate(TypeModel entity);
    }
}
