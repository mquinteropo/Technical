using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHNICAL.MODELS;

namespace TECHNICAL.BUSINESS.Services.TypeService
{
    public class TypeService : ITypeService
    {
        #region Fields
        private static string enviroment = System.Environment.CurrentDirectory;
        private static string filePath = enviroment + "\\Data\\Types.json";
        #endregion

        #region Ctor
        public TypeService()
        {

        }
        #endregion

        #region Methods
        /// <inheritdoc/>
        public ResponseTypesModel GetTypes()
        {
            ResponseTypesModel result = new ResponseTypesModel();

            List<TypeModel> list = new List<TypeModel>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string jsonString = r.ReadToEnd();

                try
                {
                    list = JsonConvert.DeserializeObject<List<TypeModel>>(jsonString);

                    result.success = true;
                    result.message = list.Count + " types.";
                    result.data = list;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }

            return result;
        }
        /// <summary>
        /// Update a list of types 
        /// </summary>
        /// <param name="list">New list to be saved </param>
        private ResponseTypesModel UpdatedList(List<TypeModel> list)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(filePath, json);

                return new ResponseTypesModel()
                {
                    success = true,
                    message = "Success",
                    data = list
                };
            }
            catch (Exception ex)
            {
                return new ResponseTypesModel() { message = ex.Message };
            }
        }
        /// <inheritdoc/>
        public ResponseTypesModel Create(TypeModel entity)
        {
            var response = new ResponseTypesModel();

            List<TypeModel> list = GetTypes().data;
            if (list == null) list = new List<TypeModel>();

            var find = list.Where(x => x.type == entity.type).FirstOrDefault();
            if (find != null)
            {
                response.message = "Type already exist";
                return response;
            }

            list.Add(entity);
            UpdatedList(list);

            response.success = true;
            response.message = "Success";
            response.data = new List<TypeModel>() { entity };

            return response;
        }
        /// <inheritdoc/>
        public ResponseTypesModel Validate(TypeModel entity)
        {
            var response = new ResponseTypesModel();

            List<TypeModel> list = GetTypes().data;
            if (list == null) list = new List<TypeModel>();

            var find = list.Where(x => x.type == entity.type).FirstOrDefault();
            if (find != null)
            {
                response.success = true;
                response.message = "Success";
                response.data = new List<TypeModel>() { find };
            }
            else
            {
                response.message = "Person type doesn't exist";
            }
            return response;
        }
        #endregion
    }
}
