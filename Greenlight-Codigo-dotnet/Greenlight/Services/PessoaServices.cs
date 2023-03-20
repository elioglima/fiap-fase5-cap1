using Greenlight.Data.Contexts;
using Greenlight.Entitys;
using Greenlight.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Services
{
    public class PessoaServices : ServiceBase
    {
        private DbSet<Pessoa> pessoaRepository;
        private DbSet<PessoaFisica> pessoaFisicaRepository;
        private DbSet<PessoaJuridica> pessoaJuridicaRepository;

        public PessoaServices(DatabaseContext databaseContext) : base(databaseContext)
        {

            pessoaRepository = db.Pessoa;
            pessoaFisicaRepository = db.PessoaFisica;
            pessoaJuridicaRepository = db.PessoaJuridica;
        }

        internal async Task<PessoaServiceResposta> BuscarPorId(int Id)
        {
            try
            {
                var dados = await pessoaRepository.FindAsync(Id);
                if (dados is null)
                    return new PessoaServiceResposta(true, "PessoaServices :: Registro nao localizado");

                var pessoaFisica = await pessoaFisicaRepository.FindAsync(Id);
                if (pessoaFisica is not null)
                    dados.PessoaFisica = pessoaFisica;

                var pessoaJuridica = await pessoaJuridicaRepository.FindAsync(Id);
                if (pessoaJuridica is not null)
                    dados.PessoaJuridica = pessoaJuridica;

                return new PessoaServiceResposta(dados, "PessoaServices :: Processo de consulta concluido.");
            }
            catch (Exception)
            {
                return new PessoaServiceResposta(true, "PessoaServices :: Nao foi possivel consultar os dados.");
            }
        }

        internal async Task<PessoaServiceResposta> Adicionar(PessoaServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    pessoaRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new PessoaServiceResposta(dados, "PessoaServices :: Dados gravados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    Console.WriteLine(ex.Message);
                    return new PessoaServiceResposta(true, "PessoaServices :: Falha ao gravar os dados.");
                }
            }
        }

        internal async Task<PessoaFisicaServiceResposta> AdicionarPessoaFisica(PessoaFisicaServiceRequisicao dados)
        {

            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    dados.TipoPessoaId = 1;
                    pessoaRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new PessoaFisicaServiceResposta(dados, "PessoaServices :: Dados gravados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    Console.WriteLine(ex.Message);
                    return new PessoaFisicaServiceResposta(true, "PessoaServices :: Falha ao gravar os dados.");
                }
            }
        }

        internal async Task<PessoaJuridicaServiceResposta> AdicionarPessoaJuridica(PessoaJuridicaServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    dados.TipoPessoaId = 2;
                    pessoaRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new PessoaJuridicaServiceResposta(dados, "PessoaServices :: Dados gravados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    Console.WriteLine(ex.Message);
                    return new PessoaJuridicaServiceResposta(true, "PessoaServices :: Falha ao gravar os dados.");
                }
            }
        }

        internal async Task<PessoaServiceResposta> AtualizarPessoa(int id, PessoaServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    var registroLocalizado = await pessoaRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new PessoaServiceResposta(dados, "PessoaServices :: Pessoa nao localizada.");

                    registroLocalizado.AssociacaoId = dados.AssociacaoId;
                    registroLocalizado.TipoPessoaId = dados.TipoPessoaId;


                    var pessoaJuridicaLocalizado = await pessoaJuridicaRepository.FindAsync(id);
                    if (pessoaJuridicaLocalizado is not null)
                    {
                        registroLocalizado.PessoaJuridica = pessoaJuridicaLocalizado;
                        registroLocalizado.PessoaJuridica.RazaoSocial = dados.PessoaJuridica.RazaoSocial;
                        registroLocalizado.PessoaJuridica.CNPJ = dados.PessoaJuridica.CNPJ;
                        registroLocalizado.PessoaJuridica.IE = dados.PessoaJuridica.IE;
                        registroLocalizado.PessoaJuridica.DataAbertura = dados.PessoaJuridica.DataAbertura;

                    }

                    var pessoaFisicaLocalizado = await pessoaFisicaRepository.FindAsync(id);
                    if (pessoaFisicaLocalizado is not null)
                    {
                        registroLocalizado.PessoaFisica = pessoaFisicaLocalizado;
                        registroLocalizado.PessoaFisica.Nome = dados.PessoaFisica.Nome;
                        registroLocalizado.PessoaFisica.CPF = dados.PessoaFisica.CPF;
                        registroLocalizado.PessoaFisica.RG = dados.PessoaFisica.RG;
                        registroLocalizado.PessoaFisica.DataNascimento = dados.PessoaFisica.DataNascimento;

                    }


                    pessoaRepository.Update(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new PessoaServiceResposta(dados, "PessoaServices :: Dados Alterados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new PessoaServiceResposta(true, ex.Message);
                }
            }
        }

        internal async Task<PessoaServiceResposta> RemoverPessoa(int id)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await pessoaRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new PessoaServiceResposta(true, "PessoaServices :: Pessoa nao localizada.");

                    var pessoaFisicaLocalizado = await pessoaFisicaRepository.FindAsync(id);
                    if (pessoaFisicaLocalizado is not null)
                    {
                        pessoaFisicaRepository.Remove(pessoaFisicaLocalizado);
                        await db.SaveChangesAsync();
                    }

                    var pessoaJuridicaLocalizado = await pessoaJuridicaRepository.FindAsync(id);
                    if (pessoaJuridicaLocalizado is not null)
                    {
                        pessoaJuridicaRepository.Remove(pessoaJuridicaLocalizado);
                        await db.SaveChangesAsync();
                    }

                    pessoaRepository.Remove(registroLocalizado);
                    await db.SaveChangesAsync();

                    await db.Database.CommitTransactionAsync();
                    return new PessoaServiceResposta(registroLocalizado, "PessoaServices :: Dados apagado com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    Console.WriteLine(ex.Message);
                    return new PessoaServiceResposta(true, "PessoaServices :: Falha ao alterar os dados.");
                }
            }
        }

        internal async Task<PessoaServiceResposta> BuscarTodos()
        {
            try
            {
                var dados = await pessoaRepository.ToListAsync();
                if (dados is null)
                    return new PessoaServiceResposta(true, "AssociacaoService :: Registro nao localizado");

                return new PessoaServiceResposta(dados, "AssociacaoService :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new PessoaServiceResposta(true, "AssociacaoService :: Nao foi possivel consultar os dados.");
            }
        }

        internal async Task<PessoaFisicaServiceResposta> BuscarPessoaFisicaTodos()
        {
            try
            {
                var dados = await pessoaFisicaRepository.ToListAsync();
                if (dados is null)
                    return new PessoaFisicaServiceResposta(true, "AssociacaoService :: Registro nao localizado");

                return new PessoaFisicaServiceResposta(dados, "AssociacaoService :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new PessoaFisicaServiceResposta(true, "AssociacaoService :: Nao foi possivel consultar os dados.");
            }
        }

        internal async Task<PessoaJuridicaServiceResposta> BuscarPessoaJuridicaTodos()
        {
            try
            {
                var dados = await pessoaJuridicaRepository.ToListAsync();
                if (dados is null)
                    return new PessoaJuridicaServiceResposta(true, "AssociacaoService :: Registro nao localizado");

                return new PessoaJuridicaServiceResposta(dados, "AssociacaoService :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new PessoaJuridicaServiceResposta(true, "AssociacaoService :: Nao foi possivel consultar os dados.");
            }
        }
    }
}
