using Core.Classes;
using System;
using System.Collections.Generic;

namespace Core.Dominio
{
    public interface ITaskRepository
    {
        int GereCodigoAtividade();
        List<Task> ObtenhaTasksDoDia(DateTime dia);
        Task ObtenhaPorCodigo(int Codigo);
        void SalveNoBanco(Task task);
        void Exclua(Task task);
        void Altere(Task task);
    }
}
