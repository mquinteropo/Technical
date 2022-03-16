using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHNICAL.BUSINESS.Services.TypeService;
using TECHNICAL.MODELS;

namespace TECHNICAL.BUSINESS.Services.PersonService
{
    public class PersonService : IPersonService
    {
        #region Fields
        private static string enviroment = System.Environment.CurrentDirectory;
        private static string filePath = enviroment + "\\Data\\Person.json";
        private ITypeService _typeService;
        #endregion

        #region Ctor
        public PersonService(ITypeService typeService)
        {
            _typeService = typeService;
        }
        #endregion

        #region Methods
        /// <inheritdoc/>
        public ResponsePersonsModel GetPersons()
        {
            ResponsePersonsModel result = new ResponsePersonsModel();

            List<PersonModel> list = new List<PersonModel>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string jsonString = r.ReadToEnd();

                try
                {
                    list = JsonConvert.DeserializeObject<List<PersonModel>>(jsonString);

                    result.success = true;
                    result.message = list.Count + " persons.";
                    result.data = list;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }

            return result;
        }
        /// <inheritdoc/>
        public ResponsePersonsModel Delete(int identification)
        {
            ResponsePersonsModel result = new ResponsePersonsModel()
            {
                message = "person doesn't exist"
            };

            try
            {
                List<PersonModel> list = GetPersons().data;
                if (list == null) return result;
                var person = list.Where(x => x.id == identification).FirstOrDefault();
                if (person != null)
                {
                    list.Remove(person);
                    UpdatedList(list);

                    result.success = true;
                    result.message = "Success";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// Update a list of persons 
        /// </summary>
        /// <param name="list">New list to be saved </param>
        private ResponsePersonsModel UpdatedList(List<PersonModel> list)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(filePath, json);

                return new ResponsePersonsModel()
                {
                    success = true,
                    message = "Success",
                    data = list
                };
            }
            catch (Exception ex)
            {
                return new ResponsePersonsModel() { message = ex.Message };
            }
        }
        /// <inheritdoc/>
        public ResponsePersonsModel UpdatePerson(PersonModel entity)
        {
            var response = new ResponsePersonsModel();


            try
            {
                List<PersonModel> list = GetPersons().data;
                if (list == null)
                {
                    response.message = "There aren't any persons.";
                }


                var find = list.Where(x => x.id == entity.id).FirstOrDefault();
                if (find != null)
                {
                    var types = _typeService.Validate(entity.type);
                    if (types.success)
                    {
                        entity.type = types.data.FirstOrDefault();
                        list.Remove(find);
                        list.Add(entity);

                        UpdatedList(list);


                        response.success = true;
                        response.message = "Success";
                        response.data = new List<PersonModel>() { entity };

                        return response;
                    }
                    else
                    {
                        response.message = types.message;
                    }
                }
                else
                {
                    response.message = "Candidate doesn't exist.";
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return response;
        }
        /// <inheritdoc/>
        public ResponsePersonsModel Create(PersonModel entity)
        {
            var response = new ResponsePersonsModel();

            List<PersonModel> list = GetPersons().data;
            if (list == null) list = new List<PersonModel>();

            var find = list.Where(x => x.id == entity.id).FirstOrDefault();
            if (find != null)
            {
                response.message = "Person already exist";
                return response;
            }


            var types = _typeService.Validate(entity.type);
            if (types.success)
            {
                entity.type = types.data.FirstOrDefault();
                list.Add(entity);
                UpdatedList(list);

                response.success = true;
                response.message = "Success";
                response.data = new List<PersonModel>() { entity };
            }
            else
            {
                response.message = types.message;
            }


            return response;
        }
        #endregion
    }
}
