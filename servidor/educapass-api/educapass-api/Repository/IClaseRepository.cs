﻿using educapass_api.Models;

namespace educapass_api.Repository
{
    public interface IClaseRepository
    {
        List<ClaseModel> GetClases(int userId);
        ClaseModel ClaseById(int id);
        ClaseModel Adicionar(ClaseModel clase);
        bool Deletar(int id);
    }
}
