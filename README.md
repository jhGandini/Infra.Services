
# Infra.Services

Pacote de serviços de infraestrutura


## Stack utilizada

**Back-end:** C#
**Ver:** Net6


## Bind AppSettings
Exemplo de bindo utilizado para carregar os configs utilizando appsettings

```C#
var info = new OpenApiInfo();
builder.Configuration.Bind("swaggerInfo", info);  
```
## Progetos

- Infra.Services.EmailService
- Infra.Services.FileService



# Infra.Services.EmailService
#### EmailSettings 
Model de configuração para email service
#### BindEmailSettings 
Helper para a criação de EmailSettings utilizando bind do appsettings
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `appSettingsKey`      | `String` | Default 'Email' |

```json
    "Email": {
        "Remetente": "noreply@noreply.br",
        "Nome": "noreply",    
        "Smtp": "172.0.0.1",
        "smtpPorta": "1",
        "HeaderSender": "noreply"
    }
```
### EmailService
#### EnviarEmail 
 Envia e-mail para 1 ou mais destinos, aceitando opcionalmente anexos.

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `emails`      | `List<string>` | obrigatório |
| `titulo`      | `string` | Obrigatório |
| `corpo`      | `string` | Obrigatório |
| `atachment`      | `CorsSettings` | Default 'null' |
| `atachmentName`      | `CorsSettings` | Default 'null' |


### Settings
Classes de configurações utilizadas pelas extenções 
#### EmailSettings
# Infra.Services.FileService
#### FileConf 
Model de configuração para email service
#### BindFileConf
Helper para a criação de EmailSettings utilizando bind do appsettings
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `appSettingsKey`      | `String` | Default 'FileConf' |

```json
    "FileConf": {
        "DiretorioArquivos": "C:\\files",
        "Estencoes": ["jpg","txt"]
    }
```
### DownloadService
#### Download 
 Retona arquivo.

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `arquivo`      | `string` | obrigatório |
| `pasta`      | `string` | default '' |


#### View
Retona arquivo em formato de bites para ser exibido.
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `arquivo`      | `string` | obrigatório |
| `pasta`      | `string` | default '' |

### FileDownload
Modelo de retono de arquivo

| Atributo   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `FileName`      | `string` | Default 'null' |
| `ContentType`      | `string` | Default '0' |
| `Data` | `MemoryStream` | Default 'null' |


### Settings
Classes de configurações utilizadas pelas extenções 
#### FileConf