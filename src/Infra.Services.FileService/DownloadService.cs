namespace Infra.Services.FileService;
public class DownloadService : Service
{    
    public DownloadService(FileConf fileConf)
    {
        _fileConf = fileConf;
    }

    public async Task<FileDownload> Download(string arquivo, string pasta = "")
    {
        var result = new FileServiceResult();

        if (arquivo != null)
            result.AddNotification("arquivo", "Nenhum arquivo informado!!");

        var path = MontarDiretorio(arquivo, pasta);
        var memory = new MemoryStream();
        using (var stream = new FileStream(path, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;
        return new FileDownload(Path.GetFileName(path), GetContentType(path), memory);
    }

    public async Task<Byte[]> View(string arquivo, string pasta = "")
    {
        var result = new FileServiceResult();

        if (arquivo != null)
            result.AddNotification("arquivo", "Nenhum arquivo informado");

        var path = MontarDiretorio(arquivo, pasta);

        var b = await File.ReadAllBytesAsync(path);
        return b;
    }
}
