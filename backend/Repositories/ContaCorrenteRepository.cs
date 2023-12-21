using backend.Interfaces.Repositories;
using backend.Models.Responses;

namespace backend.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        //private readonly IUnitOfWork _unitOfWork;
        public ContaCorrenteRepository() { }

        public async Task<bool> IncluirExtrato(ExtratoContaCorrenteRequest request)
        {
            var sql = @"
                        INSERT INTO EXTRATO 
                        (EXT_ID, EXT_DESCRICAO, EXT_DATA, EXT_VALOR, EXT_AVULSO, EXT_STATUS)
                        VALUES
                        ()
                       ";


            throw new NotImplementedException();
        }
    }
}
