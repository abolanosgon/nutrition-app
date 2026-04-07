using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    /// <summary>
    /// Servicio encargado de gestionar los registros de comidas.
    /// Actúa como intermediario entre los controladores y el repositorio de registros.
    /// </summary>
    public class MealRecordService
    {
        private readonly IMealRecordRepository mealRecordRepository;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de registros de comidas.
        /// </summary>
        /// <param name="mealRecordRepository">Repositorio utilizado para acceder a los datos de registros.</param>
        public MealRecordService(IMealRecordRepository mealRecordRepository)
        {
            this.mealRecordRepository = mealRecordRepository;
        }

        /// <summary>
        /// Agrega un nuevo registro de comida al sistema.
        /// </summary>
        /// <param name="record">Registro de comida que se desea guardar.</param>
        public void AddRecord(MealRecord record)
        {
            mealRecordRepository.Add(record);
        }

        /// <summary>
        /// Obtiene todos los registros de comidas almacenados.
        /// </summary>
        /// <returns>Lista completa de registros de comidas.</returns>
        public List<MealRecord> GetRecords()
        {
            return mealRecordRepository.GetAll();
        }

        /// <summary>
        /// Elimina un registro de comida según su identificador.
        /// </summary>
        /// <param name="recordId">Identificador del registro a eliminar.</param>
        public void DeleteRecord(int recordId)
        {
            mealRecordRepository.Delete(recordId);
        }

        /// <summary>
        /// Actualiza la información de un registro de comida existente.
        /// </summary>
        /// <param name="record">Registro de comida con los datos actualizados.</param>
        public void UpdateRecord(MealRecord record)
        {
            mealRecordRepository.Update(record);
        }
    }
}