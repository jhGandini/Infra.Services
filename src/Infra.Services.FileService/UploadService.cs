using Microsoft.AspNetCore.Http;
using Serede.Core.Models.ViewModel;
using System.Net.Http.Headers;

namespace Infra.Services.FileService;
public class UploadService : Service
{    
    public UploadService(FileConf fileConf)
    {
        _fileConf = fileConf;
    }
    
    public virtual async Task<Result> Upload(IFormFile arquivo, bool gerarNome = false, string pasta = "", string[] estencoes = null)
    {
        var result = new ResultViewModel();

        if (arquivo == null)
            result.AddNotification("arquivo", "Nenhum arquivo recebido");

        if (estencoes != null && estencoes.Contains(ObterExtencao(arquivo.FileName)))
            result.AddNotification("arquivo", "Tipo de arquivo não suportado");

        try
        {
            if (result.IsValid)
            {
                var filePath = Path.GetTempFileName();
                var pathToSave = MontarDiretorio(pasta);
                var fileName = GerarNome(arquivo, gerarNome);
                var fullPatch = Path.Combine(pathToSave, fileName.Replace("\"", "").Trim());


                if (!VerificarDiretorio(pathToSave))
                    result.AddNotification("diretorio", "Diretório não existe e não pode ser criado");

                if (result.IsValid && arquivo?.Length > 0)
                {
                    using (var stream = new FileStream(fullPatch, FileMode.OpenOrCreate))
                    {
                        await arquivo.CopyToAsync(stream);
                    }

                    result.Data = fileName;
                }
            }
        }
        catch (Exception ex)
        {
            result.AddNotification("upload", "Ocorreu um erro ao realizar o upload");
            result.Data = ex;
        }

        return result;
    }
}

