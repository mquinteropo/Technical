using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHNICAL.MODELS;

namespace TECHNICAL.BUSINESS.Services.PersonService
{
    public interface IPersonService
    {
        /// <summary>
        /// Get a list of persons from json file
        /// </summary>
        public ResponsePersonsModel GetPersons();
        /// <summary>
        /// Delete a person by id from json file
        /// </summary>
        public ResponsePersonsModel Delete(int identification);
        /// <summary>
        /// Update a person by id from json file
        /// </summary>
        /// <param name="entity">Standar model for person.</param>
        public ResponsePersonsModel UpdatePerson(PersonModel entity);
        /// <summary>
        /// Create a new person 
        /// </summary>
        /// <param name="entity">Standar model for person.</param>
        public ResponsePersonsModel Create(PersonModel entity);
    }
}
