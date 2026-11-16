using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;
namespace ClinicaVeterinaria.Services;
public class CriptografiaService
{
    private readonly IDataProtector _protetor;
    public CriptografiaService(IDataProtectionProvider provider)
    {
        _protetor = provider.CreateProtector("CpfTutor.v1");
    }
    public string Criptografar(string texto) => _protetor.Protect(texto);
    public string Descriptografar(string valor) => _protetor.Unprotect(valor);
    public string DescriptografarOuIndisponivel(string valor)
    {
        try
        {
            return Descriptografar(valor);
        }
        catch (CryptographicException)
        {
            return "Indisponível (chave de criptografia ausente)";
        }
    }
}
