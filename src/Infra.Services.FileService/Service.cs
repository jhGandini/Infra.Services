
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Infra.Services.FileService;
public abstract class Service
{
    protected FileConf _fileConf;
    protected string ObterExtencao(string fileName) => Path.GetExtension(fileName).ToLowerInvariant();

    protected string MontarDiretorio(string pasta = "") => Path.Combine(_fileConf.DiretorioArquivos, pasta);

    protected string MontarDiretorio(string arquivo, string pasta = "")
    {
        return Path.Combine(_fileConf.DiretorioArquivos, pasta, arquivo);
    }

    protected string GerarNome(IFormFile arquivo, bool gerarNome = false)
    {
        var fileName = gerarNome
            ? string.Concat(Guid.NewGuid().ToString(), ObterExtencao(arquivo.FileName))
            : ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName;

        return fileName;
    }

    protected bool VerificarDiretorio(string caminho)
    {
        if (!Directory.Exists(caminho))
        {
            var a = Directory.CreateDirectory(caminho);
            return a.Exists ? true : false;
        }

        return true;
    }

    public string GetContentType(string arquivo, string pasta = "")
    {
        var path = MontarDiretorio(arquivo, pasta);
        var types = GetMimeTypes();
        var ext = Path.GetExtension(path).ToLowerInvariant();
        return types[ext];
    }

    public string GetContentType(string path)
    {
        var types = GetMimeTypes();
        var ext = Path.GetExtension(path).ToLowerInvariant();
        return types[ext];
    }

    protected virtual Dictionary<string, string> GetMimeTypes()
    {
        return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"},
            {".csv", "text/csv"}
        };
    }
}
